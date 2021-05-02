using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinuxParking.Domain.Models;
using LinuxParking.Domain.Repositories;
using LinuxParking.Domain.Response;
using LinuxParking.Domain.Services;

namespace LinuxParking.Domain.Services
{
  public class StationService : IStationService
  {
    private readonly IStationRepository _stationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public StationService(IStationRepository stationRepository, IUnitOfWork unitOfWork)
    {
        _stationRepository = stationRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Station>> ListAllAsync()
    {
      return await _stationRepository.ListAllAsync();
    }

    public async Task<CreateStationResponse> SaveAsync(Station station)
    {
      try
      {
          await _stationRepository.AddAsync(station);
          await _unitOfWork.CompleteAsync();

          return new CreateStationResponse(station);
      }
      catch (Exception ex)
      {
        return new CreateStationResponse($"Error - Failed to save station: {ex.Message}");
      }
    }
  }
}