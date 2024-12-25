using ANGEL_Store.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ANGEL_Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //https://localhost:7111/Customer/Items
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Items", new { area = "Customer" });

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
