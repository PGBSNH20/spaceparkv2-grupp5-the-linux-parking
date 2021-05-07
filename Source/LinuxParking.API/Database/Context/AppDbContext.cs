using Microsoft.EntityFrameworkCore;
using LinuxParking.API.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LinuxParking.Database.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Station> Stations { get; set; }
        public DbSet<Spot> Spots { get; set; }
        public DbSet<ParkingStatus> ParkingStatuses { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Station>().HasKey(p => p.Id);
            builder.Entity<Station>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Station>().Property(p => p.Name).IsRequired();
            builder.Entity<Station>().HasMany(p => p.Spots).WithOne(p => p.Station).HasForeignKey(p => p.StationId);

            builder.Entity<ParkingStatus>().HasKey(p => p.Id);
            builder.Entity<ParkingStatus>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Entity<Customer>().HasKey(p => p.Id);
            builder.Entity<Customer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Entity<Spot>().HasKey(p => p.Id);
            builder.Entity<Spot>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Spot>().Property(p => p.Price).IsRequired();
            builder.Entity<Spot>().Property(p => p.Size).IsRequired();
        }
    }
}