using Microsoft.IdentityModel.Tokens;
using OnlineStore.Entities.Interfaces.IRepositries;
using OnlineStore.Entities.Models.Auction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Services
{
    public class BidService
    {
        public BidService(IBidRepository bidRepository)
        {
            BidRepository = bidRepository;
        }

        public IBidRepository BidRepository { get; }
        
        public async Task AddAsync(int userid,decimal amount,int ItemId)
        {
            Bid bid = new Bid();
            bid.UserID = userid;
            bid.BidAmount = amount;
            bid.ItemID = ItemId;
            bid.BidTime = DateTime.Now;

            await BidRepository.AddAsync(bid);    
        }
    }
}
