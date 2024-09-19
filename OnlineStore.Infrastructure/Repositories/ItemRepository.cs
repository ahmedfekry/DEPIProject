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
    }
}
