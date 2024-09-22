using OnlineStore.Entities.Models.Authentication;
using OnlineStore.Entities.Models.GeneralLookups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Entities.Models.Auction
{
    public class Item
    {
        public int ID { get; set; }
        public int SellerID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal StartingPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImageURL { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual User Seller { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
        public virtual Order Order { get; set; }
    }

}
