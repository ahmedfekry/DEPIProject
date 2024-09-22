using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Entities.Models.Authentication
{
    [Table("UserProfile")]
    public class UserProfile
    {
        public int Id { get; set; }
        public string Bio { get; set; }

        public string Address { get; set; }
        public string AddressNoTwo { get; set; }
        public string PostalCode { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
