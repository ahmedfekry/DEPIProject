using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities.Interfaces.IRepositries;
using OnlineStore.Entities.Models.GeneralLookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        public ApplicationDbContext _applicationDbContext { get; }
        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public async Task AddCategoryAsync(Category category)
        {
            await _applicationDbContext.Categories.AddAsync(category);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            Category category = await _applicationDbContext.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (category != null)
            {
                _applicationDbContext.Categories.Remove(category);
                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _applicationDbContext.Categories.ToListAsync();

        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _applicationDbContext.Categories.Include(c => c.Items)
                                            .Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _applicationDbContext.Categories.Update(category);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetFeaturedCategories()
        {
            var categories = await _applicationDbContext.Categories
                                    .Where(c => c.IsFeatured == true)
                                    .Take(4)
                                    .ToListAsync();

            return categories;
        }
    }
}
