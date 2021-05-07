using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LinuxParking.API.Domain.Interfaces.Services;
using LinuxParking.API.Domain.Models;
using LinuxParking.API.Domain.Resources;
using LinuxParking.API.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LinuxParking.API.Controllers
{
    [Route("/api/parking/{stationId}/[controller]")]
    public class ParkingController : Controller
    {
        private readonly IParkingService _parkingService;
        private readonly IMapper _mapper;

        public ParkingController(IParkingService parkingService, IMapper mapper)
        {
            _parkingService = parkingService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromRoute] int stationId, [FromBody] CreateParkingResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var parking = _mapper.Map<CreateParkingResource, ParkingStatus>(resource);
            parking.StationId = stationId;
            var res = await _parkingService.SaveAsync(parking);

            if (!res.Success)
            {
                return BadRequest(res.Message);
            }

            var parkingResource = _mapper.Map<ParkingStatus, ParkingResource>(res.ParkingStatus);
            return Created("", parkingResource);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromRoute] int stationId)
        {
            var res = await _parkingService.ListAsync(stationId);

            if (!res.Success)
            {
                return BadRequest(res.Message);
            }

            var parkingResponse = _mapper.Map<IEnumerable<ParkingStatus>, IEnumerable<ParkingResource>>(res.ParkingStatuses);
            return Ok(parkingResponse);
        }

        [HttpGet("{parkingId}")]
        public async Task<IActionResult> GetAsync([FromRoute] int stationId, [FromRoute] int parkingId)
        {
            var res = await _parkingService.FindByIdAsync(stationId, parkingId);
            if (!res.Success)
            {
                return BadRequest(res.Message);
            }

            var parkingResponse = _mapper.Map<ParkingStatus, ParkingResource>(res.ParkingStatus);
            return Ok(parkingResponse);
        }

        [HttpPut]
        [Route("{parkingId}")]
        public async Task<IActionResult> UpdateAsync(int stationId, int parkingId, [FromBody] CreateParkingResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var parking = _mapper.Map<CreateParkingResource, ParkingStatus>(resource);
            var res = await _parkingService.UpdateAsync(stationId, parkingId, parking);

            if (!res.Success)
            {
                return BadRequest(res.Message);
            }

            var parkingResponse = _mapper.Map<ParkingStatus, ParkingResource>(res.ParkingStatus);
            return Ok(parkingResponse);
        }

        [HttpDelete]
        [Route("{parkingId}")]
        public async Task<IActionResult> DeleteAsync(int stationId, [FromRoute] int parkingId)
        {
            var res = await _parkingService.DeleteAsync(stationId, parkingId);

            if (!res.Success)
                return BadRequest(res.Message);

            var parkingResource = _mapper.Map<ParkingStatus, ParkingResource>(res.ParkingStatus);
            return Ok(parkingResource);
        }
    }
}