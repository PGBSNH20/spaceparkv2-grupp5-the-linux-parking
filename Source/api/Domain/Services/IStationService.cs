using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Models;

namespace api.Domain.Services
{
    public interface IStationService
    {
         Task<IEnumerable<Station>> ListAllAsync();
    }
}