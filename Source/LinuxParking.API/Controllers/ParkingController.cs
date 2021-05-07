using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using LinuxParking.API.Domain.Interfaces.Services;
using LinuxParking.API.Domain.Models;
using LinuxParking.API.Domain.Resources;
using LinuxParking.API.Extensions;
using LinuxParking.API.Utils;
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

            parking.CustomerID = HttpContext.User.Claims.First(h => h.Type == "Id").Value;
            parking.ArrivalTime = DateTime.Now;
            parking.SpotID = resource.SpotId;
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

        [HttpGet("{spotId}")]
        public async Task<IActionResult> GetAsync([FromRoute] int stationId, [FromRoute] int spotId)
        {
            var res = await _parkingService.FindByIdAsync(stationId, spotId);
            if (!res.Success)
            {
                return BadRequest(res.Message);
            }

            var parkingResponse = _mapper.Map<ParkingStatus, ParkingResource>(res.ParkingStatus);
            return Ok(parkingResponse);
        }

        [HttpPut("{spotId}")]
        public async Task<IActionResult> UpdateAsync(int stationId, int spotId, [FromBody] CreateParkingResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var parking = _mapper.Map<CreateParkingResource, ParkingStatus>(resource);
            var res = await _parkingService.UpdateAsync(stationId, spotId, parking);

            if (!res.Success)
            {
                return BadRequest(res.Message);
            }

            var parkingResponse = _mapper.Map<ParkingStatus, ParkingResource>(res.ParkingStatus);
            return Ok(parkingResponse);
        }

        [HttpDelete("{spotId}")]
        public async Task<IActionResult> DeleteAsync(int stationId, [FromRoute] int spotId)
        {
            var res = await _parkingService.DeleteAsync(stationId, spotId);

            if (!res.Success)
                return BadRequest(res.Message);

            var parkingResource = _mapper.Map<ParkingStatus, ParkingResource>(res.ParkingStatus);
            return Ok(parkingResource);
        }
    }
}