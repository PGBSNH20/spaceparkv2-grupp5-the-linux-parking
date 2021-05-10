using System.Collections.Generic;
using System.Threading.Tasks;
using LinuxParking.API.Domain.Models;

namespace LinuxParking.API.Domain.Interfaces.Repositories
{
    public interface IParkingRepository
    {
        Task<IEnumerable<ParkingStatus>> ListAsync(int stationId);
        Task AddAsync(ParkingStatus parking);
        Task<ParkingStatus> FindByIdAsync(int stationId, int parkingId);
        void Update(ParkingStatus parking);
        void Delete(ParkingStatus parking);
    }
}