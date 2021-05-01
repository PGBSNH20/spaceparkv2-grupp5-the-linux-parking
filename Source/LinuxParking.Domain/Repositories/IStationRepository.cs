using System.Collections.Generic;
using System.Threading.Tasks;
using LinuxParking.Domain.Models;

namespace LinuxParking.Domain.Repositories
{
    public interface IStationRepository
    {
         Task<IEnumerable<Station>> ListAllAsync();
    }
}