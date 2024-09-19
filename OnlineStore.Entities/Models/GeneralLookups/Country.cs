using OnlineStore.Entities.Models.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Entities.Models.GeneralLookups
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string CountryName { get; set; }

        // Navigation property
        public ICollection<User> Users { get; set; }
    }

}
