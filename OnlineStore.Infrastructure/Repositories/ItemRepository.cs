using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities.Interfaces.IRepositries;
using OnlineStore.Entities.Models.Auction;

namespace OnlineStore.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private ApplicationDbContext _applicationDbContext { get; }

        public ItemRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await _applicationDbContext.Items.ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetFeaturedItems()
        {
            return await _applicationDbContext.Items
                                              .Where(i => i.IsFeatured == true)
                                              .Take(3)
                                              .ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsByCategory(int categoryId)
        {
            return await _applicationDbContext.Items
                                              .Where(i => i.CategoryID == categoryId)
                                              .ToListAsync();
        }
    }
}
