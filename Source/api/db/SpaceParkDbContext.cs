using api.db.Models;
using Microsoft.EntityFrameworkCore;

namespace api.db
{
    public class SpaceParkDbContext : DbContext
    {
        private readonly string connectionString = "host=localhost;port=5432;database=linuxpark;user id=root;password=secret";
        public DbSet<Ship> Ship { get; set; }
        public DbSet<Spot> Spot { get; set; }
        public DbSet<ParkingStatus> ParkingStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Ship>().HasData(new Ship { ID = 1, Name = "Ship 1", Plate = "ABC123" });
            //builder.Entity<Spot>().HasData(new Spot { ID = 1, Size = 100, Price = 25 });
        }
    }
}