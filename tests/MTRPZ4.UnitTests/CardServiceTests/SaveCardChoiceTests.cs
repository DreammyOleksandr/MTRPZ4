using Moq;
using MTRPZ4.Application.DTO;
using MTRPZ4.Application.Services;
using MTRPZ4.CoreDomain.Entities;
using MTRPZ4.Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTRPZ4.UnitTests.CardServiceTests
{
    public class SaveCardChoiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CardService _cardService;

        public SaveCardChoiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _cardService = new CardService(_mockUnitOfWork.Object);
        }

        [Fact]
        public async Task SaveCardChoice_ShouldThrowArgumentNullException_WhenCardIsNull()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _cardService.SaveCardChoice(null));
        }

        [Fact]
        public async Task SaveCardChoice_ShouldThrowInvalidOperationException_WhenColorNotFound()
        {
            var card = new ChosedCardDTO { ColorId = 1, FontId = 1, PriceId = 1 };
            _mockUnitOfWork.Setup(u => u.Colors.GetById(It.IsAny<int>())).ReturnsAsync((Color?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _cardService.SaveCardChoice(card));
        }

        [Fact]
        public async Task SaveCardChoice_ShouldThrowInvalidOperationException_WhenFontNotFound()
        {
            var card = new ChosedCardDTO { ColorId = 1, FontId = 1, PriceId = 1 };
            _mockUnitOfWork.Setup(u => u.Colors.GetById(It.IsAny<int>())).ReturnsAsync(new Color { Id = 1, Count = 0 });
            _mockUnitOfWork.Setup(u => u.Fonts.GetById(It.IsAny<int>())).ReturnsAsync((Font?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _cardService.SaveCardChoice(card));
        }

        [Fact]
        public async Task SaveCardChoice_ShouldThrowInvalidOperationException_WhenPriceNotFound()
        {
            var card = new ChosedCardDTO { ColorId = 1, FontId = 1, PriceId = 1 };
            _mockUnitOfWork.Setup(u => u.Colors.GetById(It.IsAny<int>())).ReturnsAsync(new Color { Id = 1, Count = 0 });
            _mockUnitOfWork.Setup(u => u.Fonts.GetById(It.IsAny<int>())).ReturnsAsync(new Font { Id = 1, Count = 0 });
            _mockUnitOfWork.Setup(u => u.Prices.GetById(It.IsAny<int>())).ReturnsAsync((Price?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _cardService.SaveCardChoice(card));
        }

        [Fact]
        public async Task SaveCardChoice_ShouldIncrementCountsAndSaveChanges_WhenCardIsValid()
        {
            var card = new ChosedCardDTO { ColorId = 1, FontId = 1, PriceId = 1 };
            var color = new Color { Id = 1, Count = 0 };
            var font = new Font { Id = 1, Count = 0 };
            var price = new Price { Id = 1, Count = 0 };

            _mockUnitOfWork.Setup(u => u.Colors.GetById(It.IsAny<int>())).ReturnsAsync(color);
            _mockUnitOfWork.Setup(u => u.Fonts.GetById(It.IsAny<int>())).ReturnsAsync(font);
            _mockUnitOfWork.Setup(u => u.Prices.GetById(It.IsAny<int>())).ReturnsAsync(price);

            await _cardService.SaveCardChoice(card);

            _mockUnitOfWork.Verify(u => u.Colors.Update(It.Is<Color>(c => c.Count == 1)), Times.Once);
            _mockUnitOfWork.Verify(u => u.Fonts.Update(It.Is<Font>(f => f.Count == 1)), Times.Once);
            _mockUnitOfWork.Verify(u => u.Prices.Update(It.Is<Price>(p => p.Count == 1)), Times.Once);
            _mockUnitOfWork.Verify(u => u.SaveChanges(), Times.Once);
        }
    }
}
