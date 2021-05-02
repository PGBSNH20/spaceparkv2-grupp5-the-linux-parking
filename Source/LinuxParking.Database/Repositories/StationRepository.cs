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

    public async Task AddAsync(Station station)
    {
      await _ctx.Stations.AddAsync(station);
    }

    public async Task<Station> FindByIdAsync(int id)
    {
      return await _ctx.Stations.FindAsync(id);
    }

    public async Task<IEnumerable<Station>> ListAllAsync()
    {
      return await _ctx.Stations.ToListAsync();
    }

    public void Update(Station station)
    {
      _ctx.Stations.Update(station);
    }
  }
}