using OnlineStore.Entities.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Entities.Models.Auction
{
    public class Order
    {
        public int ID { get; set; }
        public int BuyerID { get; set; }
        public int ItemID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Navigation properties
        public virtual User Buyer { get; set; }
        public virtual Item Item { get; set; }
    }

}
