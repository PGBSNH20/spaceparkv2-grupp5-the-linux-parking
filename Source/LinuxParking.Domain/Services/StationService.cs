using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinuxParking.Domain.Models;
using LinuxParking.Domain.Repositories;
using LinuxParking.Domain.Services;

namespace LinuxParking.Domain.Services
{
  public class StationService : IStationService
  {
    private readonly IStationRepository _stationRepository;

    public StationService(IStationRepository stationRepository)
    {
        _stationRepository = stationRepository;
    }
    public async Task<IEnumerable<Station>> ListAllAsync()
    {
      return await _stationRepository.ListAllAsync();
    }
  }
}