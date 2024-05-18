using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MTRPZ4.CoreDomain.Entities;
using MTRPZ4.Infrastructure;

namespace MTRPZ4.UI.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<User> _userManager;
        public TestController(ApplicationDBContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
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
                return View();
            }

        }
        public async Task<IActionResult> CompleteTest()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user is { } || !user.IfCompletedTest)
            {
                user.IfCompletedTest = true;
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction("Index", "Result");

        }
    }
}
