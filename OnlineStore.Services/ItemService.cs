using OnlineStore.Entities.Interfaces.IRepositries;
using OnlineStore.Entities.Interfaces.IServices;
using OnlineStore.Entities.Models.Auction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await itemRepository.GetAllItems();
        }
    }
}
