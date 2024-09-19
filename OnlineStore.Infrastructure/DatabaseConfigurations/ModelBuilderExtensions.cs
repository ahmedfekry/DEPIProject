using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities.Models.Auction;
using OnlineStore.Entities.Models.Authentication;
using OnlineStore.Entities.Models.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Infrastructure.DatabaseConfigurations
{
    public static class ModelBuilderExtensions
    {
        public static void ConfigureRelationships(this ModelBuilder modelBuilder)
        {
            // User-Country (One-to-Many)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Country)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CountryID);

            // User-Items (One-to-Many)
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Seller)
                .WithMany(u => u.Items)
                .HasForeignKey(i => i.SellerID);

            // Item-Category (One-to-Many)
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CategoryID);

            // Bid-Item (Many-to-One)
            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Item)
                .WithMany(i => i.Bids)
                .HasForeignKey(b => b.ItemID);

            // Bid-User (Many-to-One)
            modelBuilder.Entity<Bid>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bids)
                .HasForeignKey(b => b.UserID)
                .OnDelete(DeleteBehavior.NoAction); // Disable cascade on delete

            // Order-User (Many-to-One)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Buyer)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.BuyerID)
                .OnDelete(DeleteBehavior.NoAction); // Disable cascading delete

            // Order-Item (Many-to-One)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Item)
                .WithOne(i => i.Order)
                .HasForeignKey<Order>(o => o.ItemID);

            // Notification-User (Many-to-One)
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserID);

            modelBuilder.Entity<Bid>()
                .Property(b => b.BidAmount)
                .HasColumnType("decimal(18, 4)"); // Specify the column type

            modelBuilder.Entity<Item>()
                  .Property(b => b.CurrentPrice)
                  .HasColumnType("decimal(18, 4)"); // Specify the column type

            modelBuilder.Entity<Item>()
                  .Property(b => b.StartingPrice)
                  .HasColumnType("decimal(18, 4)"); // Specify the column type

            modelBuilder.Entity<Order>()
                  .Property(b => b.TotalAmount)
                  .HasColumnType("decimal(18, 4)"); // Specify the column type
        }
    }

}
