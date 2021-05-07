using System.Collections.Generic;
using System.Linq;
using LinuxParking.API.Domain.Models;
using LinuxParking.API.Domain.Repositories;
using LinuxParking.API.Domain.Services;
using LinuxParking.API.Services;
using LinuxParking.API.Test.Services.Repositories;
using Xunit;

namespace LinuxParking.API.Test.Services
{
    public class StationServiceTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStationRepository _repository;
        private readonly IStationService _service;

        public StationServiceTest()
        {
            _repository = new TestStationRepository();
            _unitOfWork = new TestIUnitOfWork();
            _service = new StationService(_repository, _unitOfWork);
        }
        
        [Fact]
        public async void SaveAsync_WithValidModel_CreatesNewStation()
        {
            Station station = new Station();
            station.Name = "TestStation";
            var res = await _service.SaveAsync(station);
            Assert.Equal(station.Name, res.Station.Name);
            Assert.True(res.Success);
        }

        [Fact]
        public async void FindByIdAsync_WithExistingStations_ReturnsSpecifedStation()
        {
            List<string> names = new List<string>{"Station1", "station2", "Station3"};
            foreach (var name in names)
            {
                var station = new Station();
                station.Name = name;
                await _service.SaveAsync(station);
            }

            var res = await _service.FindByIdAsync(2);
            Assert.Equal(names[1], res.Station.Name);
        }
        [Fact]
        public async void DeleteAsync_WithExistionStations_DeletesStations()
        {
            var deleteId = 2;
            List<string> names = new List<string>{"Station1", "station2", "Station3"};
            foreach (var name in names)
            {
                var station = new Station();
                station.Name = name;
                await _service.SaveAsync(station);
            }

            await _service.DeleteAsync(deleteId);
            var resAllStations = await _service.ListAsync();
            var resDeletedStation = await _service.FindByIdAsync(deleteId);
            Assert.Equal(2, resAllStations.Stations.Count());
            Assert.Null(resDeletedStation.Station);
        }

        [Fact]
        public async void UpdateAsync_WithValidModel_UpdatesModel()
        {
            var newName = "newName";
            var station = new Station();
            station.Name = "Testing";
            await _service.SaveAsync(station);

            var res = await _service.FindByIdAsync(1);
            station.Id = res.Station.Id;
            station.Name = newName;

            await _service.UpdateAsync(station.Id, station);
            var updatedRes = await _service.FindByIdAsync(1);
            Assert.Equal(newName, updatedRes.Station.Name);
        }
    }
}
