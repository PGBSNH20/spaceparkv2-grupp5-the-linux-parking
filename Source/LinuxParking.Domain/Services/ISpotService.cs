using System.Threading.Tasks;
using LinuxParking.Domain.Models;
using LinuxParking.Domain.Response;

namespace LinuxParking.Domain.Services
{
    public interface ISpotService
    {
        Task<SpotResponse> ListAsync();
        Task<SpotResponse> FindByIdAsync(int id);
        Task<SpotResponse> SaveAsync(Spot station);
        Task<SpotResponse> UpdateAsync(int id, Spot station);
        Task<SpotResponse> DeleteAsync(int id);
    }
}