using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LinuxParking.Domain.Models;
using LinuxParking.Domain.Repositories;
using LinuxParking.Database.Context;

namespace LinuxParking.Database.Repositories
{
  public class StationRepository : BaseRepository, IStationRepository
  {
    public StationRepository(AppDbContext ctx) : base(ctx) {}
    public async Task<IEnumerable<Station>> ListAllAsync()
    {
      return await _ctx.Stations.ToListAsync();
    }
  }
}