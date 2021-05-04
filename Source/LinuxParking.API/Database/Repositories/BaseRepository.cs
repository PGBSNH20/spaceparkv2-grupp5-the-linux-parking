using LinuxParking.Database.Context;

namespace LinuxParking.Database.Repositories
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