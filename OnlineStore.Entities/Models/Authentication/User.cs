﻿using OnlineStore.Entities.Models.Auction;
using OnlineStore.Entities.Models.GeneralLookups;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using OnlineStore.Entities.Models.Notifications;
using Microsoft.AspNetCore.Identity;


namespace OnlineStore.Entities.Models.Authentication
{
    public class User : IdentityUser<int>
    {
        public string Status { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string? PostalCode { get; set; }
        public int CountryID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual Country Country { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }

}
