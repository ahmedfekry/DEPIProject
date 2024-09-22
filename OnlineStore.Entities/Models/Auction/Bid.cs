using OnlineStore.Entities.Models.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Entities.Models.Auction
{
    public class Bid
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public int UserID { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime BidTime { get; set; }

        // Navigation properties
        public virtual Item Item { get; set; }
        public virtual User User { get; set; }
    }

}
