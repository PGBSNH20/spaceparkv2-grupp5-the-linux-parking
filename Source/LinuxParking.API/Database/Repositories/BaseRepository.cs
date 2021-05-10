using LinuxParking.API.Database.Context;

namespace LinuxParking.API.Database.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _ctx;

        protected BaseRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
    }
}