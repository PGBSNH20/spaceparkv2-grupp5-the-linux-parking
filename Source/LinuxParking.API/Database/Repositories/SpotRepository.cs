using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LinuxParking.API.Domain.Models;
using LinuxParking.Database.Context;
using LinuxParking.API.Domain.Interfaces.Repositories;

namespace LinuxParking.Database.Repositories
{
    public class SpotRepository : BaseRepository, ISpotRepository
    {
        public SpotRepository(AppDbContext ctx) : base(ctx) { }

        public async Task AddAsync(Spot spot)
        {
            await _ctx.Spots.AddAsync(spot);
        }

        public void Delete(Spot spot)
        {
            _ctx.Spots.Remove(spot);
        }

        public async Task<Spot> FindByIdAsync(int stationId, int spotId)
        {
            return await _ctx.Spots.FirstOrDefaultAsync(spot => spot.StationId == stationId && spot.Id == spotId);
        }

        public async Task<IEnumerable<Spot>> ListAsync()
        {
            return await _ctx.Spots.ToListAsync();
        }

        public void Update(Spot spot)
        {
            _ctx.Spots.Update(spot);
        }
    }
}