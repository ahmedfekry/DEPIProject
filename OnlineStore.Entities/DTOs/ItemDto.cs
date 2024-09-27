using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Entities.DTOs
{
    public class ItemDto
    {
        public int SellerID { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDateDate { get; set; }

        [Required]
        public decimal StartingPrice { get; set; }
    }
}
