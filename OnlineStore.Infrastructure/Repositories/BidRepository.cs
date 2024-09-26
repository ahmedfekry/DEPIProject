using OnlineStore.Entities.Interfaces.IRepositries;
using OnlineStore.Entities.Models.Auction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Infrastructure.Repositories
{
    public class BidRepository : IBidRepository
    {
        public BidRepository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public ApplicationDbContext ApplicationDbContext { get; }

        public async Task AddAsync(Bid bid)
        {
            await ApplicationDbContext.Bids.AddAsync(bid);

            await ApplicationDbContext.SaveChangesAsync();
        }
    }
}
