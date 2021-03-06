using System.Collections.Generic;
using System.Threading.Tasks;
using LinuxParking.API.Database.Context;
using LinuxParking.API.Domain.Models;
using LinuxParking.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LinuxParking.API.Database.Repositories
{
    public class StationRepository : BaseRepository, IStationRepository
    {
        public StationRepository(AppDbContext ctx) : base(ctx) { }

        public async Task AddAsync(Station station)
        {
            await _ctx.Stations.AddAsync(station); ;
        }

        public void Delete(Station station)
        {
            _ctx.Stations.Remove(station);
        }

        public async Task<Station> FindByIdAsync(int id)
        {
            return await _ctx.Stations.FindAsync(id); ;
        }

        public async Task<IEnumerable<Station>> ListAsync()
        {
            return await _ctx.Stations.ToListAsync(); ;
        }

        public void Update(Station station)
        {
            _ctx.Stations.Update(station);
        }
    }
}