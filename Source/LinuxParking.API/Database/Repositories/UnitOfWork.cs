using System.Threading.Tasks;
using LinuxParking.API.Database.Context;
using LinuxParking.API.Domain.Repositories;

namespace LinuxParking.API.Database.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _ctx;

        public UnitOfWork(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task CompleteAsync()
        {
            await _ctx.SaveChangesAsync(); ;
        }
    }
}