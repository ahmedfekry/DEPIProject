using OnlineStore.Entities.Models.Auction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Entities.Models.GeneralLookups
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public bool IsFeatured { get; set; }

        // Navigation property
        public virtual ICollection<Item>? Items { get; set; }
    }

}
