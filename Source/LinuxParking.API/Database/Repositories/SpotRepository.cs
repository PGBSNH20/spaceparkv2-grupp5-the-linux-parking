using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinuxParking.API.Database.Context;
using LinuxParking.API.Domain.Interfaces.Repositories;
using LinuxParking.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LinuxParking.API.Database.Repositories
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

        public async Task<IEnumerable<Spot>> ListAsync(int stationId)
        {
            return await _ctx.Spots.Where(spot => spot.StationId == stationId).ToListAsync();
        }

        public void Update(Spot spot)
        {
            _ctx.Spots.Update(spot);
        }
    }
}