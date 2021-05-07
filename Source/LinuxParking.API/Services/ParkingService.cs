using System;
using System.Threading.Tasks;
using LinuxParking.API.Domain.Interfaces.Repositories;
using LinuxParking.API.Domain.Interfaces.Services;
using LinuxParking.API.Domain.Models;
using LinuxParking.API.Domain.Repositories;
using LinuxParking.API.Domain.Response;

namespace LinuxParking.API.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IParkingRepository _parkingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ParkingService(IParkingRepository parkingRepository, IUnitOfWork unitOfWork)
        {
            _parkingRepository = parkingRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ParkingResponse> DeleteAsync(int stationId, int parkingId)
        {
            var existing = await _parkingRepository.FindByIdAsync(stationId, parkingId);

            if (existing == null)
                return new ParkingResponse($"Parking with {parkingId} not found.");

            try
            {
                _parkingRepository.Delete(existing);
                await _unitOfWork.CompleteAsync();

                return new ParkingResponse(existing);
            }
            catch (Exception ex)
            {
                return new ParkingResponse($"Error - Failed to delete parking with id {parkingId}: {ex.Message}");
            }
        }

        public async Task<ParkingResponse> FindByIdAsync(int stationId, int parkingId)
        {
            var parking = await _parkingRepository.FindByIdAsync(stationId, parkingId);

            if (parking == null)
                return new ParkingResponse($"Parking with id {parkingId} not found");

            return new ParkingResponse(parking);
        }

        public async Task<ParkingResponse> ListAsync(int stationId)
        {
            try
            {
                var parkingStatuses = await _parkingRepository.ListAsync(stationId);

                return new ParkingResponse(parkingStatuses);
            }
            catch (Exception ex)
            {
                return new ParkingResponse($"Failed to query all parkings: {ex.Message}");
            }
        }

        public async Task<ParkingResponse> SaveAsync(ParkingStatus parkingStatus)
        {
            try
            {
                parkingStatus.ArrivalTime = DateTime.Now;
                await _parkingRepository.AddAsync(parkingStatus);
                await _unitOfWork.CompleteAsync();

                return new ParkingResponse(parkingStatus);
            }
            catch (Exception ex)
            {
                return new ParkingResponse($"Error - Failed to save parking: {ex.Message}");
            }
        }

        public async Task<ParkingResponse> UpdateAsync(int stationId, int parkingId, ParkingStatus parking)
        {
            var existing = await _parkingRepository.FindByIdAsync(stationId, parkingId);

            if (existing == null)
                return new ParkingResponse($"Parking with id {parkingId} not found.");

            existing.CustomerID = parking.CustomerID;
            existing.SpotID = parking.SpotID;
            existing.ArrivalTime = DateTime.Now;

            try
            {
                _parkingRepository.Update(existing);
                await _unitOfWork.CompleteAsync();

                return new ParkingResponse(existing);
            }
            catch (Exception ex)
            {
                return new ParkingResponse($"Failed to update parking with id: {parkingId}, with error: ${ex.Message}");
            }
        }
    }
}