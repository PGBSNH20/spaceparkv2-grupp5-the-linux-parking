using System.Collections.Generic;
using System.Threading.Tasks;
using LinuxParking.API.Domain.Models;
using LinuxParking.API.Domain.Response;

namespace LinuxParking.API.Domain.Services
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