using System.Collections.Generic;
using System.Threading.Tasks;
using LinuxParking.Domain.Models;

namespace LinuxParking.Domain.Repositories
{
    public interface IStationRepository
    {
         Task<IEnumerable<Station>> ListAllAsync();

         Task AddAsync(Station station);
         Task<Station> FindByIdAsync(int id);
         void Update(Station station);
         void Delete(Station station);
    }
}