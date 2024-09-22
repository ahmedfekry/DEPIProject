using OnlineStore.Entities.Models.Auction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Entities.Interfaces.IRepositries
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<IEnumerable<Item>> GetFeaturedItemsAsync();
        Task<IEnumerable<Item>> GetItemsByCategoryAsync(int categoryId);
        Task<Item> GetItemDetailsAsync(int itemId);
    }
}
