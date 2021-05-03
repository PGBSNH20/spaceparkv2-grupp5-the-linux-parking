using System;
using System.Threading.Tasks;
using LinuxParking.API.Domain.Models;
using LinuxParking.API.Domain.Repositories;
using LinuxParking.API.Domain.Response;
using LinuxParking.API.Domain.Services;

namespace LinuxParking.API.Services
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
        await _unitOfWork.CompleteAsync();

        return new StationResponse(existing);
      }
      catch (Exception ex)
      {
        return new StationResponse($"Error - Failed to delete station {id}: {ex.Message}");
      }
    }

    public async Task<StationResponse> FindByIdAsync(int id)
    {
      var station = await _stationRepository.FindByIdAsync(id);

      if (station == null)
        return new StationResponse($"Station {id} not found");

      return new StationResponse(station);
    }

    public async Task<StationResponse> ListAsync()
    {
      try
      {
        var stations = await _stationRepository.ListAsync();

        return new StationResponse(stations);
      }
      catch (Exception ex)
      {
        return new StationResponse($"Failed to query all stations: {ex.Message}");
      }
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