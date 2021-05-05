using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using LinuxParking.API.Domain.Services;
using LinuxParking.API.Extensions;
using LinuxParking.API.Domain.Resources;
using LinuxParking.API.Domain.Models;
namespace LinuxParking.API.Controllers
{
    [Route("/api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StationController : Controller
    {
        private readonly IStationService _stationService;

        private readonly IMapper _mapper;

        public StationController(IStationService stationService, IMapper mapper)
        {
            _stationService = stationService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateStationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var station = _mapper.Map<CreateStationResource, Station>(resource);
            var res = await _stationService.SaveAsync(station);

            if (!res.Success)
                return BadRequest(res.Message);

            var stationResource = _mapper.Map<Station, StationResource>(res.Station);
            return Created("", stationResource);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _stationService.ListAsync();

            if (!res.Success)
                return BadRequest(res.Message);

            var stationsResponse = _mapper.Map<IEnumerable<Station>, IEnumerable<StationResource>>(res.Stations);
            return Ok(stationsResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var res = await _stationService.FindByIdAsync(id);

            if (!res.Success)
                return BadRequest(res.Message);

            var stationResponse = _mapper.Map<Station, StationResource>(res.Station);
            return Ok(stationResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CreateStationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var station = _mapper.Map<CreateStationResource, Station>(resource);
            var res = await _stationService.UpdateAsync(id, station);

            if (!res.Success)
                return BadRequest(res.Message);

            var stationResponse = _mapper.Map<Station, StationResource>(res.Station);
            return Ok(stationResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var res = await _stationService.DeleteAsync(id);

            if (!res.Success)
                return BadRequest(res.Message);

            var stationResource = _mapper.Map<Station, StationResource>(res.Station);
            return Ok(stationResource);
        }
    }
}
