using OnlineStore.Entities.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Entities.Models.Notifications
{
    public class Notification
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property
        public virtual User User { get; set; }
    }

}
