using OnlineStore.Entities.Interfaces.IRepositries;
using OnlineStore.Entities.Interfaces.IServices;
using OnlineStore.Entities.Models.GeneralLookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Services
{
    public class CategoryService : ICategoryService
    {
        public ICategoryRepository _categoryRepository { get; }

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        public async Task<Category> GetCategoryDetailsAsync(int id)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);  
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateCategoryAsync(category);
        }

        public async Task<IEnumerable<Category>> GetFeaturedCategoriesAsync()
        {
            return await _categoryRepository.GetFeaturedCategories();
        }
    }
}
