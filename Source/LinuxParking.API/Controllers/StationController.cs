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

            //var station = _mapper.Map<CreateStationResource, Station>(resource);
            return BadRequest();
        }

        [HttpGet]
        public async Task<IEnumerable<StationResource>> GetAllAsync()
        {
            var stations = await _stationService.ListAllAsync();
            return _mapper.Map<IEnumerable<Station>, IEnumerable<StationResource>>(stations);
        }
    }
}
