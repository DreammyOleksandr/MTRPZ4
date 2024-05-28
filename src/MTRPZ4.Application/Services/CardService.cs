using MTRPZ4.Application.DTO;
using MTRPZ4.CoreDomain.Entities;
using MTRPZ4.Infrastructure;
using MTRPZ4.Infrastructure.Repository;
using MTRPZ4.Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace MTRPZ4.Application.Services
{
    public class CardService : ICardService
    {
        private readonly int _cardElementsCount = 3;
        private readonly int _cardsCount = 6;
        private readonly IUnitOfWork _unitOfWork;
        public CardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CardDTO>> GetRandomCards()
        {
            var cards = new List<CardDTO>();
            var random = new Random();
            var tasks = new List<Task<CardDTO>>();

            for (int i = 0; i < _cardsCount; i++)
            {
                tasks.Add(CreateRandomCardAsync(random));
            }

            var cardResults = await Task.WhenAll(tasks);
            cards.AddRange(cardResults);

            return cards;
        }

        public async Task SaveCardChoice(ChosedCardDTO? card)
        {
            if (card is null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            try
            {
                await IncrementCountAsync(card.ColorId, _unitOfWork.Colors.GetById, _unitOfWork.Colors.Update);
                await IncrementCountAsync(card.FontId, _unitOfWork.Fonts.GetById, _unitOfWork.Fonts.Update);
                await IncrementCountAsync(card.PriceId, _unitOfWork.Prices.GetById, _unitOfWork.Prices.Update);

                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while saving the card choice.", ex);
            }
        }

        private async Task<CardDTO> CreateRandomCardAsync(Random random)
        {
            try
            {
                var colorTask = _unitOfWork.Colors.GetById(random.Next(1, _cardElementsCount + 1));
                var fontTask = _unitOfWork.Fonts.GetById(random.Next(1, _cardElementsCount + 1));
                var priceTask = _unitOfWork.Prices.GetById(random.Next(1, _cardElementsCount + 1));

                await Task.WhenAll(colorTask, fontTask, priceTask);

                var color = await colorTask;
                var font = await fontTask;
                var price = await priceTask;

                if (color == null || font == null || price == null)
                {
                    throw new InvalidOperationException("One of the card elements is null.");
                }

                return new CardDTO
                {
                    Color = new CardElementDTO { Id = color.Id, Value = color.Pigment },
                    Font = new CardElementDTO { Id = font.Id, Value = font.Type },
                    Price = new CardElementDTO { Id = price.Id, Value = Convert.ToString(price.Value) }
                };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while creating a random card.", ex);
            }
        }

        private async Task IncrementCountAsync<TEntity>(int id, Func<int?, Task<TEntity>> getById, 
            Action<TEntity> update) where TEntity : class
        {
            var entity = await getById(id);
            if (entity == null)
            {
                throw new InvalidOperationException($"Entity with ID {id} not found.");
            }

            var countProperty = entity.GetType().GetProperty("Count");
            if (countProperty == null || !countProperty.CanWrite)
            {
                throw new InvalidOperationException($"Entity does not have a writable 'Count' property.");
            }

            var currentCount = (int)countProperty.GetValue(entity);
            countProperty.SetValue(entity, currentCount + 1);

            update(entity);
        }
    }
}
