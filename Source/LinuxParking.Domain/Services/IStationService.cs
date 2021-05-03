using System.Collections.Generic;
using System.Threading.Tasks;
using LinuxParking.Domain.Models;
using LinuxParking.Domain.Response;

namespace LinuxParking.Domain.Services
{
    public interface IStationService
    {
         Task<IEnumerable<Station>> ListAsync();
         Task<StationResponse> SaveAsync(Station station);
         Task<StationResponse> UpdateAsync(int id, Station station);
         Task<StationResponse> DeleteAsync(int id);
    }
}