using System.Collections.Generic;
using System.Threading.Tasks;
using LinuxParking.API.Domain.Models;

namespace LinuxParking.API.Domain.Interfaces.Repositories
{
    public interface ISpotRepository
    {
        Task<IEnumerable<Spot>> ListAsync(int stationId);
        Task AddAsync(Spot spot);
        Task<Spot> FindByIdAsync(int stationId, int spotId);
        void Update(Spot spot);
        void Delete(Spot spot);
    }
}