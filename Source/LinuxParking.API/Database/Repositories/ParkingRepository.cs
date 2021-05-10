using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinuxParking.API.Database.Context;
using LinuxParking.API.Domain.Interfaces.Repositories;
using LinuxParking.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LinuxParking.API.Database.Repositories
{
    public class ParkingRepository : BaseRepository, IParkingRepository
    {
        public ParkingRepository(AppDbContext ctx) : base(ctx) { }


        public async Task AddAsync(ParkingStatus parking)
        {
            await _ctx.ParkingStatuses.AddAsync(parking);
        }

        public void Delete(ParkingStatus parking)
        {
            _ctx.ParkingStatuses.Remove(parking);
        }

        public async Task<ParkingStatus> FindByIdAsync(int stationId, int parkingId)
        {
            return await _ctx.ParkingStatuses.FirstOrDefaultAsync(parking => parking.StationId == stationId && parking.Id == parkingId);
        }

        public async Task<IEnumerable<ParkingStatus>> ListAsync(int stationId)
        {
            return await _ctx.ParkingStatuses.Where(parking => parking.StationId == stationId).ToListAsync();
        }

        public void Update(ParkingStatus parking)
        {
            _ctx.ParkingStatuses.Update(parking);
        }
    }
}