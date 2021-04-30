using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Models;

namespace api.Domain.Repositories
{
    public interface IStationRepository
    {
         Task<IEnumerable<Station>> ListAllAsync();
    }
}