using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MTRPZ4.Application.DTO;
using MTRPZ4.Application.Services;
using MTRPZ4.CoreDomain.Entities;
using MTRPZ4.Infrastructure;
using MTRPZ4.Infrastructure.Repository.IRepository;

namespace MTRPZ4.UI.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        private readonly UserManager<User> _userManager;
		private readonly ICardService _cardService;
		public TestController(UserManager<User> userManager, ICardService cardService)
        {
            _userManager = userManager;
            _cardService = cardService;
        }
        public async Task<IActionResult> Index()
        {
			var user = await _userManager.GetUserAsync(User);

			if (user is null || user.IfCompletedTest)
			{
				return RedirectToAction("Index", "Result");
			}
			else
			{
				IEnumerable<CardDTO> cards = await _cardService.GetRandomCards();
				List<CardDTO> cardsList = cards.ToList();

				return View(cardsList);
			}
		}

		[Route("Test/{ColorId}/{FontId}/{PriceId}")]
		public async Task<IActionResult> Index(ChosedCardDTO? choice)
		{
			var user = await _userManager.GetUserAsync(User);

			if (user is { } || !user.IfCompletedTest)
			{
				user.IfCompletedTest = true;
			}

			try
			{
				await _cardService.SaveCardChoice(choice);
				return RedirectToAction("Index", "Result");
			}
			catch (Exception)
			{
				throw;
			}
		}
    }
}
