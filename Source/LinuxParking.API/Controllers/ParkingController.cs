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
    }
}