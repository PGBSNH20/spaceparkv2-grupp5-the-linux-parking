using System.Collections.Generic;
using System.Threading.Tasks;
using LinuxParking.Domain.Models;

namespace LinuxParking.Domain.Repositories
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