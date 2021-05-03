using System.Collections.Generic;
using System.Threading.Tasks;
using LinuxParking.API.Domain.Models;

namespace LinuxParking.API.Domain.Repositories
{
  public interface IStationRepository
  {
    Task<IEnumerable<Station>> ListAsync();

    Task AddAsync(Station station);
    Task<Station> FindByIdAsync(int id);
    void Update(Station station);
    void Delete(Station station);
  }
}