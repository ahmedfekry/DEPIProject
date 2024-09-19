using Microsoft.AspNetCore.Mvc;
using OnlineStore.Entities.Interfaces.IServices;
using OnlineStore.Entities.Models.GeneralLookups;
using OnlineStore.Services;

namespace OnlineStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryService _categoryService { get; }
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<List<Category>> Index()
        {
            List<Category> categories = new List<Category>();

            var result = await _categoryService.GetAllCategoriesAsync();
            
            categories = result.ToList();

            return categories;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Details(int id)
        {
            var category = await _categoryService.GetCategoryDetailsAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }


        [HttpPost]
        public async Task<ActionResult> Create(Category category)
        {
            await _categoryService.AddCategoryAsync(category);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id,Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            await _categoryService.UpdateCategoryAsync(category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }

    }
}
