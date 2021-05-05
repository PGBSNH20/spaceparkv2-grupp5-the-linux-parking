using System.Threading.Tasks;
using LinuxParking.API.Domain.Models;
using LinuxParking.API.Domain.Response;

namespace LinuxParking.API.Domain.Interfaces.Services
{
    public interface ISpotService
    {
        Task<SpotResponse> ListAsync();
        Task<SpotResponse> FindByIdAsync(int stationId, int spotId);
        Task<SpotResponse> SaveAsync(Spot spot);
        Task<SpotResponse> UpdateAsync(int stationId, int spotId, Spot spot);
        Task<SpotResponse> DeleteAsync(int stationId, int spotId);
    }
}