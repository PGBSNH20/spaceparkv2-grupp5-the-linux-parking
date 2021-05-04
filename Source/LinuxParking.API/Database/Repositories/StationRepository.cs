using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LinuxParking.API.Domain.Models;
using LinuxParking.API.Domain.Repositories;
using LinuxParking.Database.Context;

namespace LinuxParking.Database.Repositories
{
    public class StationRepository : BaseRepository, IStationRepository
    {
        public StationRepository(AppDbContext ctx) : base(ctx) { }

        public async Task AddAsync(Station station)
        {
            await _ctx.Stations.AddAsync(station).ConfigureAwait(false);
        }

        public void Delete(Station station)
        {
            _ctx.Stations.Remove(station);
        }

        public async Task<Station> FindByIdAsync(int id)
        {
            return await _ctx.Stations.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Station>> ListAsync()
        {
            return await _ctx.Stations.ToListAsync().ConfigureAwait(false);
        }

        public void Update(Station station)
        {
            _ctx.Stations.Update(station);
        }
    }
}