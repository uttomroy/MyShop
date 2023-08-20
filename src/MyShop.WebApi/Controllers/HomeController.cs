using Microsoft.AspNetCore.Mvc;
using MyShop.WebApi.Models;
using System.Diagnostics;
using MyShop.Core.Models;

namespace MyShop.WebApi.Controllers
{
    [Route("/{*suffix}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var ss = new Token();
            return View();
        }
    }
}