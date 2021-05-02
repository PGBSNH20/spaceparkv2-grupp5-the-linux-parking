using System.Threading.Tasks;
using LinuxParking.Domain.Repositories;
using LinuxParking.Database.Context;

namespace LinuxParking.Database.Repositories
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
        await _ctx.SaveChangesAsync();
    }
  }
}