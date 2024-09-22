using Microsoft.AspNetCore.Mvc;
using OnlineStore.Entities.Interfaces.IServices;

namespace OnlineStore.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        public ICategoryService _categoryService { get; }
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            
            return View(categories);
        }
    }
}
