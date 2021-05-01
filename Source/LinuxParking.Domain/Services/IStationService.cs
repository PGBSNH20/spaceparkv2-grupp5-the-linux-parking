using System.Collections.Generic;
using System.Threading.Tasks;
using LinuxParking.Domain.Models;

namespace LinuxParking.Domain.Services
{
    public interface IStationService
    {
         Task<IEnumerable<Station>> ListAllAsync();
    }
}