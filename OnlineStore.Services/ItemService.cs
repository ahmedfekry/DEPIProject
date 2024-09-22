﻿using OnlineStore.Entities.Interfaces.IRepositries;
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

        public async Task<IEnumerable<Item>> GetAllItemsAysnc()
        {
            return await itemRepository.GetAllItemsAsync();
        }

        public async Task<IEnumerable<Item>> GetFeaturedItemsAysnc()
        {
            return await itemRepository.GetFeaturedItemsAsync();
        }

        public async Task<Item> GetItemDetails(int itemId)
        {
            return await itemRepository.GetItemDetailsAsync(itemId);
        }

        public async Task<IEnumerable<Item>> GetItemsByCategoryAysnc(int categoryid)
        {
            return await itemRepository.GetItemsByCategoryAsync(categoryid);
        }
    }
}