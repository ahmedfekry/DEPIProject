using Microsoft.AspNetCore.Mvc;
using OnlineStore.Entities.Interfaces.IServices;
using OnlineStore.WebApp.Models;
using System.Diagnostics;

namespace OnlineStore.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IItemService itemService;

        public HomeController(ILogger<HomeController> logger, 
                              ICategoryService categoryService,
                              IItemService itemService
                              )
        {
            _logger = logger;
            this._categoryService = categoryService;
            this.itemService = itemService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await itemService.GetAllItems();
            var categories = await _categoryService.GetAllCategoriesAsync();

            //ViewBag => to pass the data from the controller to the view / current request
            //ViewData => to pass data from the controller to the view / current request
            //TempData => to pass data between the actions / two requests

            ViewBag.Items = items;
            ViewBag.Categories = categories;    

            return View(categories);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
