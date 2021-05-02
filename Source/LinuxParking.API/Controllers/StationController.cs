using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LinuxParking.Domain.Services;
using LinuxParking.API.Resources;
using LinuxParking.API.Extentions;
using LinuxParking.Domain.Models;
namespace LinuxParking.API.Controllers
{
    [Route("/api/[controller]")]
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
        public async Task<IActionResult> Create([FromBody] CreateStationResource resource) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var station = _mapper.Map<CreateStationResource, Station>(resource);
            var res = await _stationService.SaveAsync(station);

            if (!res.Success)
                return BadRequest(res.Message);

            var stationResource = _mapper.Map<Station, StationResource>(res.Station);
            return Ok(stationResource);
        }

        [HttpGet]
        public async Task<IEnumerable<StationResource>> GetAllAsync()
        {
            var stations = await _stationService.ListAllAsync();
            return _mapper.Map<IEnumerable<Station>, IEnumerable<StationResource>>(stations);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<StationResource> GetAsync([FromRoute] string id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task UpdateAsync([FromRoute] string id, [FromBody] CreateStationResource resource)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync([FromRoute] string id) {
            throw new NotImplementedException();
        }
    }
}
