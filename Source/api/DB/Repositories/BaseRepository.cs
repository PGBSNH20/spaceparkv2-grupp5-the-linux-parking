using api.DB.Context;

namespace api.DB.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _ctx;

        public BaseRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
    }
}