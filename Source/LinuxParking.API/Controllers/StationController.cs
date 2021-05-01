using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LinuxParking.Domain.Services;
using LinuxParking.API.Resources;
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

        [HttpGet]
        public async Task<IEnumerable<StationResource>> GetAllAsync()
        {
            var stations = await _stationService.ListAllAsync();
            return _mapper.Map<IEnumerable<Station>, IEnumerable<StationResource>>(stations);
        }
    }
}
