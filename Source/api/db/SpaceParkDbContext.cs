using api.db.Models;
using Microsoft.EntityFrameworkCore;

namespace api.db
{
    public class SpaceParkDbContext : DbContext
    {
        private readonly string connectionString = "host=localhost;port=5432;database=linuxpark;user id=admin;password=secret";
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}