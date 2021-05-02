using System.Collections.Generic;
using System.Threading.Tasks;
using LinuxParking.Domain.Models;
using LinuxParking.Domain.Response;

namespace LinuxParking.Domain.Services
{
    public interface IStationService
    {
         Task<IEnumerable<Station>> ListAllAsync();
         Task<CreateStationResponse> SaveAsync(Station station);
         Task<CreateStationResponse> UpdateAsync(int id, Station station);
    }
}