using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LinuxParking.API.Services;

namespace LinuxParking.API.Controllers
{
    [Route("/api/station/{stationId}/[controller]")]
    public class SpotController : Controller
    {
        private readonly ISpotService _spotService;

        public SpotController(ISpotService spotService, )
        {
            
        }

        [HttpPost]
        public async Task CreateAsync([FromRoute] string stationId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task GetAllAsync([FromRoute] string stationId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{spotId}")]
        public async Task GetAsync([FromRoute] string stationId, [FromRoute] string spotId)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("{spotId}")]
        public async Task UpdateAsync([FromRoute] string stationId, [FromRoute] string spotId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{spotId}")]
        public async Task DeleteAsync([FromRoute] string stationId, [FromRoute] string spotId)
        {
            throw new NotImplementedException();
        }
    }
}