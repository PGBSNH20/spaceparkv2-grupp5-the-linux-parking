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

    public async Task<StationResponse> DeleteAsync(int id)
    {
      var existing = await _stationRepository.FindByIdAsync(id);

      if (existing == null)
        return new StationResponse($"Station with {id} not found.");

      try
      {
          _stationRepository.Delete(existing);
          _unitOfWork.CompleteAsync();

          return new StationResponse(existing);
      }
      catch (Exception ex)
      {
          return new StationResponse($"Error - Failed to delete station {id}: {ex.Message}");
      }
    }

    public async Task<IEnumerable<Station>> ListAllAsync()
    {
      return await _stationRepository.ListAllAsync();
    }

    public async Task<StationResponse> SaveAsync(Station station)
    {
      try
      {
          await _stationRepository.AddAsync(station);
          await _unitOfWork.CompleteAsync();

          return new StationResponse(station);
      }
      catch (Exception ex)
      {
        return new StationResponse($"Error - Failed to save station: {ex.Message}");
      }
    }

    public async Task<StationResponse> UpdateAsync(int id, Station station)
    {
      var existing = await _stationRepository.FindByIdAsync(id);

      if (existing == null)
        return new StationResponse($"Station with {id} not found.");

      existing.Name = station.Name;

      try
      {
          _stationRepository.Update(existing);
          await _unitOfWork.CompleteAsync();

          return new StationResponse(existing);
      }
      catch (Exception ex)
      {
        return new StationResponse($"Failed to update station: {id}, with error: ${ex.Message}");
      }
    }
  }
}