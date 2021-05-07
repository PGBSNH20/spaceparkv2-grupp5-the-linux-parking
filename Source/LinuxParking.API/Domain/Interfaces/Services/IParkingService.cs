using System.Threading.Tasks;
using LinuxParking.API.Domain.Models;
using LinuxParking.API.Domain.Response;

namespace LinuxParking.API.Domain.Interfaces.Services
{
    public interface IParkingService
    {
        Task<ParkingResponse> ListAsync(int stationId);
        Task<ParkingResponse> FindByIdAsync(int stationId, int parkingId);
        Task<ParkingResponse> SaveAsync(ParkingStatus parking);
        Task<ParkingResponse> UpdateAsync(int stationId, int parkingId, ParkingStatus parking);
        Task<ParkingResponse> DeleteAsync(int stationId, int parkingId);
    }
}