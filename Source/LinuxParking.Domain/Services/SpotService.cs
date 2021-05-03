using System;
using System.Threading.Tasks;
using LinuxParking.Domain.Models;
using LinuxParking.Domain.Repositories;
using LinuxParking.Domain.Response;

namespace LinuxParking.Domain.Services
{
    public class SpotService : ISpotService
    {
        private readonly ISpotRepository _spotRepository;
        private readonly IUnitOfWork _unitOfWork;

        public async Task<SpotResponse> DeleteAsync(int id)
        {
            var resultSpot = await _spotRepository.FindByIdAsync(id);

            if (resultSpot == null)
            {
                return new SpotResponse($"Spot with id: {id} not found!");
            }

            try
            {
                _spotRepository.Delete(resultSpot);
                await _unitOfWork.CompleteAsync();

                return new SpotResponse(resultSpot);
            }
            catch (Exception e)
            {
                return new SpotResponse($"Error - Failed to delete spot with id {id}: {e.Message}!");
            }
        }

        public async Task<SpotResponse> FindByIdAsync(int id)
        {
            var spot = await _spotRepository.FindByIdAsync(id);

            if (spot == null)
            {
                return new SpotResponse($"Spot with id {id} not found!");
            }

            return new SpotResponse(spot);
        }

        public async Task<SpotResponse> ListAsync()
        {
            try
            {
                var spots = await _spotRepository.ListAsync();
                return new SpotResponse(spots);
            }
            catch (Exception e)
            {
                return new SpotResponse($"Failed to query spots: {e.Message}!");
            }
        }

        public async Task<SpotResponse> SaveAsync(Spot spot)
        {
            try
            {
                await _spotRepository.AddAsync(spot);
                await _unitOfWork.CompleteAsync();

                return new SpotResponse(spot);
            }
            catch (Exception ex)
            {
                return new SpotResponse($"Error - Failed to save spot: {ex.Message}");
            }
        }

        public async Task<SpotResponse> UpdateAsync(int id, Spot spot)
        {
            var resultSpot = await _spotRepository.FindByIdAsync(id);

            if (resultSpot == null)
            {
                return new SpotResponse($"Spot with {id} not found.");
            }

            resultSpot.Station = spot.Station;

            try
            {
                _spotRepository.Update(resultSpot);
                await _unitOfWork.CompleteAsync();

                return new SpotResponse(resultSpot);
            }
            catch (Exception ex)
            {
                return new SpotResponse($"Failed to update spot with id {id}, with error: ${ex.Message}");
            }
        }
    }
}