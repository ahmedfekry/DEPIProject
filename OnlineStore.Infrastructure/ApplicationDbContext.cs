using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities;
using OnlineStore.Entities.Models.Auction;
using OnlineStore.Entities.Models.Authentication;
using OnlineStore.Entities.Models.GeneralLookups;
using OnlineStore.Entities.Models.Notifications;
using OnlineStore.Infrastructure.DatabaseConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<User,IdentityRole<int>,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category() { Id=1, CategoryName = "Clothes",Description = "This is Clothes Category"},
                    new Category() { Id=2, CategoryName = "Cars", Description = "Thie is Cars Category" }
                );

            modelBuilder.Entity<Country>().HasData(
                    new Country() { Id=1, CountryName = "Egypt" },
                    new Country() { Id = 2, CountryName = "United Arab Emirates" }
                );

            modelBuilder.ConfigureRelationships();
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
    }
}