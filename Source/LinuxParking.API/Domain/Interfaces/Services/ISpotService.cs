using System.Threading.Tasks;
using LinuxParking.API.Domain.Models;
using LinuxParking.API.Domain.Response;

namespace LinuxParking.API.Domain.Interfaces.Services
{
    public interface ISpotService
    {
        Task<SpotResponse> ListAsync();
        Task<SpotResponse> FindByIdAsync(int id);
        Task<SpotResponse> SaveAsync(Spot spot);
        Task<SpotResponse> UpdateAsync(int id, Spot spot);
        Task<SpotResponse> DeleteAsync(int id);
    }
}