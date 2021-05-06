using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinuxParking.API.Domain.Models;
using LinuxParking.API.Domain.Repositories;

namespace LinuxParking.API.Test.Services.Repositories
{
    public class TestStationRepository : IStationRepository
    {
        public Station Station;
        public IEnumerable<Station> Stations;

        public TestStationRepository()
        {
            Stations = new List<Station>();
            Station = null;
        }
        
        public Task<IEnumerable<Station>> ListAsync()
        {
            return Task.FromResult(Stations);
        }

        public Task AddAsync(Station station)
        {
            station.Id = station.Id + (Stations.Count() + 1);
            return Task.FromResult(Stations = Stations.Append(station));
        }

        public Task<Station> FindByIdAsync(int id)
        {
            return Task.FromResult(Stations.FirstOrDefault(s => s.Id == id));
        }

        public void Update(Station station)
        {
            var oldStation = Stations.First(s => s.Id == station.Id);
            oldStation = station;
            Stations.Append(oldStation);
        }

        public void Delete(Station station)
        {
            Stations = Stations.Where(s => s.Id != station.Id);
        }
    }
}