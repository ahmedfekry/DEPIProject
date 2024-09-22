using OnlineStore.Entities.Models.Auction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Entities.Interfaces.IServices
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllItemsAysnc();

        Task<IEnumerable<Item>> GetItemsByCategoryAysnc(int categoryid);

        Task<IEnumerable<Item>> GetFeaturedItemsAysnc(); 
    }
}
