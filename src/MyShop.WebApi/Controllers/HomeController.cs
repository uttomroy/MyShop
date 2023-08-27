using Microsoft.AspNetCore.Mvc;
using MyShop.WebApi.Models;
using System.Diagnostics;
using MyShop.Core.Models;
using MyShop.Core.Services.FileService;

namespace MyShop.WebApi.Controllers
{
    [Route("/{*suffix}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IIndexFileService _indexFileService;

        public HomeController(ILogger<HomeController> logger, IIndexFileService indexFileService)
        {
            _logger = logger;
            _indexFileService = indexFileService;
        }

        public IActionResult Index()
        {
            var ss = new Token();
            var model = new IndexModel()
            {
                Asset = _indexFileService.GetIndexFileDetails()
            };
            return View(model);
        }
    }
}