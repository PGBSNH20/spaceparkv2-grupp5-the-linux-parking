using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using api.Domain.Services;
using api.Domain.Models;
using System.Threading.Tasks;

namespace api.Controllers
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
       public async Task<IEnumerable<Station>> GetAllAsync() {
           return await _stationService.ListAllAsync();
       }
    }
}