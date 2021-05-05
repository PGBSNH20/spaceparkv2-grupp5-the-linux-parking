using System.Collections.Generic;
using System.Threading.Tasks;
using LinuxParking.API.Domain.Models;

namespace LinuxParking.API.Domain.Interfaces.Repositories
{
    public interface ISpotRepository
    {
        Task<IEnumerable<Spot>> ListAsync();
        Task AddAsync(Spot spot);
        Task<Spot> FindByIdAsync(int id);
        void Update(Spot spot);
        void Delete(Spot spot);
    }
}