using System.Collections.Generic;
using System.Threading.Tasks;
using LinuxParking.API.Domain.Interfaces.Repositories;
using LinuxParking.API.Domain.Models;
using LinuxParking.Database.Context;
using LinuxParking.Database.Repositories;

namespace LinuxParking.API.Database.Repositories
{
    public class ParkingRepository : BaseRepository, IParkingRepository
    {
        public ParkingRepository(AppDbContext ctx) : base(ctx) { }

        public Task AddAsync(ParkingStatus parking)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(ParkingStatus parking)
        {
            throw new System.NotImplementedException();
        }

        public Task<ParkingStatus> FindByIdAsync(int stationId, int parkingId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ParkingStatus>> ListAsync(int stationId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ParkingStatus parking)
        {
            throw new System.NotImplementedException();
        }
    }
}