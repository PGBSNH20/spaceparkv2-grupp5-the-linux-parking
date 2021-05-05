using System;
using System.Threading.Tasks;
using LinuxParking.API.Domain.Interfaces.Repositories;
using LinuxParking.API.Domain.Interfaces.Services;
using LinuxParking.API.Domain.Models;
using LinuxParking.API.Domain.Repositories;
using LinuxParking.API.Domain.Response;

namespace LinuxParking.API.Services
{
    public class SpotService : ISpotService
    {
        private readonly ISpotRepository _spotRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SpotService(ISpotRepository spotRepository, IUnitOfWork unitOfWork)
        {
            _spotRepository = spotRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SpotResponse> DeleteAsync(int id)
        {
            var existing = await _spotRepository.FindByIdAsync(id);

            if (existing == null)
                return new SpotResponse($"Spot with {id} not found.");

            try
            {
                _spotRepository.Delete(existing);
                await _unitOfWork.CompleteAsync();

                return new SpotResponse(existing);
            }
            catch (Exception ex)
            {
                return new SpotResponse($"Error - Failed to delete spot with id {id}: {ex.Message}");
            }
        }

        public async Task<SpotResponse> FindByIdAsync(int id)
        {
            var spot = await _spotRepository.FindByIdAsync(id);

            if (spot == null)
                return new SpotResponse($"Spot with id {id} not found");

            return new SpotResponse(spot);
        }

        public async Task<SpotResponse> ListAsync()
        {
            try
            {
                var spots = await _spotRepository.ListAsync();

                return new SpotResponse(spots);
            }
            catch (Exception ex)
            {
                return new SpotResponse($"Failed to query all spots: {ex.Message}");
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
            var existing = await _spotRepository.FindByIdAsync(id);

            if (existing == null)
                return new SpotResponse($"Spot with {id} not found.");

            existing.Price = spot.Price;
            existing.Size = spot.Size;

            try
            {
                _spotRepository.Update(existing);
                await _unitOfWork.CompleteAsync();

                return new SpotResponse(existing);
            }
            catch (Exception ex)
            {
                return new SpotResponse($"Failed to update spot with id: {id}, with error: ${ex.Message}");
            }
        }
    }
}