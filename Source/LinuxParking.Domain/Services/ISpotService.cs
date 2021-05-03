using System.Threading.Tasks;
using LinuxParking.Domain.Models;
using LinuxParking.Domain.Response;

namespace LinuxParking.Domain.Services
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