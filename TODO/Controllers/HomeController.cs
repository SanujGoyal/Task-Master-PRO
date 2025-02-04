using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TODO.Models;
using TODO.Repositories.Interfaces;

namespace TODO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoriesRepository categoriesRepository;

        public HomeController(ILogger<HomeController> logger, ICategoriesRepository categoriesRepository)
        {
            _logger = logger;
            this.categoriesRepository = categoriesRepository;
        }

        public async Task<IActionResult> Index()
        {
            //var data = await categoriesRepository.GetAllCategoriesAsync();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
