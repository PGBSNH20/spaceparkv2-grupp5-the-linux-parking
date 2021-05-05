using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace LinuxParking.API.Controllers
{
    [Route("/api/station/{stationId}/[controller]")]
    public class SpotController : Controller
    {
        public SpotController()
        {
            // TODO: Dependecy injections
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