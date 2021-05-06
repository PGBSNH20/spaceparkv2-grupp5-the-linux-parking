using System.Collections.Generic;
using System.Linq;
using LinuxParking.API.Domain.Models;
using LinuxParking.API.Domain.Repositories;
using LinuxParking.API.Services;
using LinuxParking.API.Test.Services.Repositories;
using Xunit;

namespace LinuxParking.API.Test.Services
{
    public class StationServiceTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStationRepository _repository;

        public StationServiceTest()
        {
            _repository = new TestStationRepository();
            _unitOfWork = new TestIUnitOfWork();
        }
        
        [Fact]
        public async void SaveAsync_WithValidModel_CreatesNewStation()
        {
            var stationService = new StationService(_repository, _unitOfWork);
            Station station = new Station();
            station.Name = "TestStation";
            var res = await stationService.SaveAsync(station);
            Assert.Equal(station.Name, res.Station.Name);
            Assert.True(res.Success);
        }
    }
}