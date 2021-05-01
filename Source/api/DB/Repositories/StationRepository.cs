using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Domain.Models;
using api.Domain.Repositories;
using api.DB.Context;

namespace api.DB.Repositories
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