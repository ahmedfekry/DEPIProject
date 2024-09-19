using OnlineStore.Entities.Models.Auction;
using OnlineStore.Entities.Models.GeneralLookups;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using OnlineStore.Entities.Models.Notifications;

namespace OnlineStore.Entities.Models.Authentication
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Status { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int CountryID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public Country Country { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<Bid> Bids { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }

}
