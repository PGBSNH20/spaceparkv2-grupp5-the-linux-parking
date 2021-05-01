using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LinuxParking.Domain.Services;
using LinuxParking.Domain.Models;

namespace LinuxParking.API.Controllers
{
    [Route("/api/[controller]")]
    public class StationController : Controller
    {
        private readonly IStationService _stationService;

        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }

        [HttpGet]
        public async Task<IEnumerable<Station>> GetAllAsync()
        {
            return await _stationService.ListAllAsync();
        }
    }
}
