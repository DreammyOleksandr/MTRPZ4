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
        public IActionResult Index()
        {
            return View();
        }
    }
}