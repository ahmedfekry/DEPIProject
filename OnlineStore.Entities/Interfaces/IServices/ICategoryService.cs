using OnlineStore.Entities.Models.GeneralLookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Entities.Interfaces.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task<Category> GetCategoryDetailsAsync(int id);

        Task AddCategoryAsync(Category category);

        Task DeleteCategoryAsync(int id);

        Task UpdateCategoryAsync(Category category);

        Task<IEnumerable<Category>> GetFeaturedCategoriesAsync();
    }
}
