using Microsoft.EntityFrameworkCore;
using api.Domain.Models;
namespace api.DB.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Station> Stations { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<Station>().HasKey(p => p.ID);
            builder.Entity<Station>().Property(p => p.ID).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Station>().Property(p => p.Name).IsRequired();
        }
    }
}