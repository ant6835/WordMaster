using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WordMaster.Models;

namespace WordMaster.Controllers
{
    public class HomeController : Controller
    {
        GameContext context { get; set; }

        public HomeController(GameContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Play()
        {
            return RedirectToAction("Game", "Game");
        }
    }
}
