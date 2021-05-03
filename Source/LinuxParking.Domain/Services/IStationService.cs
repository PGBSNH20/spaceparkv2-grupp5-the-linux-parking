using System.Threading.Tasks;
using LinuxParking.Domain.Models;
using LinuxParking.Domain.Response;

namespace LinuxParking.Domain.Services
{
    public interface IStationService
    {
        Task<StationResponse> ListAsync();
        Task<StationResponse> FindByIdAsync(int id);
        Task<StationResponse> SaveAsync(Station station);
        Task<StationResponse> UpdateAsync(int id, Station station);
        Task<StationResponse> DeleteAsync(int id);
    }
}