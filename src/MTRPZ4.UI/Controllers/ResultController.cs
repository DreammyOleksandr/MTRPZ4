using Humanizer;
using Microsoft.AspNetCore.Mvc;
using MTRPZ4.Application.DTO;
using MTRPZ4.Application.Services;
using MTRPZ4.Infrastructure.Repository;
using MTRPZ4.Infrastructure.Repository.IRepository;

namespace MTRPZ4.UI.Controllers
{
    public class ResultController : Controller
    {
        private const string GetCard = "card";
        private const string SaveChoice = "save-choice";

        private readonly ICardService _cardService;
        private readonly IUnitOfWork _unitOfWork;

        public ResultController(ICardService cardService, IUnitOfWork unitOfWork)
        {
          
            _cardService = cardService;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet(GetCard)]
        public async Task<IActionResult> GetRandomCards()
        {
            try
            {
                var response = await _cardService.GetRandomCards();
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet(SaveChoice)]
        public async Task<IActionResult> SaveChosedCard([FromQuery] ChosedCardDTO? choice)
        {
            try
            {
                await _cardService.SaveCardChoice(choice);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //remove latter
        [HttpGet("show-data")]
        public async Task<IActionResult> ShowData()
        {
            try
            {
                var response = await _unitOfWork.Colors.GetAll();
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}