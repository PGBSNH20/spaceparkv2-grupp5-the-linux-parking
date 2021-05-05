using System.Threading.Tasks;
using LinuxParking.API.Domain.Models;
using LinuxParking.API.Domain.Response;

namespace LinuxParking.API.Domain.Interfaces.Services
{
    public interface ISpotService
    {
        Task<SpotResponse> ListAsync();
        Task<SpotResponse> FindByIdAsync(string stationId, string spotId);
        Task<SpotResponse> SaveAsync(Spot spot);
        Task<SpotResponse> UpdateAsync(string id, Spot spot);
        Task<SpotResponse> DeleteAsync(string id);
    }
}