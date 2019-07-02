using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Spend_It.Models;

namespace Spend_It.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}


        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<SavedLocation> SavedLocations { get; set; }
        public DbSet<LocationType> LocationTypes { get; set; }
        public DbSet<PaymentTypeLocation> PaymentTypeLocations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().ToTable("Location");
            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser");
            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<LocationType>().ToTable("LocationType");
            modelBuilder.Entity<PaymentType>().ToTable("PaymentType");
            modelBuilder.Entity<PaymentTypeLocation>().ToTable("PaymentTypeLocation");
            modelBuilder.Entity<SavedLocation>().ToTable("SavedLocation");


            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<Location>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<PaymentTypeLocation>()
                .HasKey(c => new { c.PaymentTypeId, c.LocationId });

        }
    }
}
