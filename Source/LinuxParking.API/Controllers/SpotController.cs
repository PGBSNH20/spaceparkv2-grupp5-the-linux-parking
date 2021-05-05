using System;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LinuxParking.API.Extentions;
using LinuxParking.API.Domain.Resources;
using LinuxParking.API.Domain.Interfaces.Services;
using LinuxParking.API.Domain.Models;
using System.Collections.Generic;

namespace LinuxParking.API.Controllers
{
    [Route("/api/station/{stationId}/[controller]")]
    public class SpotController : Controller
    {
        private readonly ISpotService _spotService;
        private readonly IMapper _mapper;

        public SpotController(ISpotService spotService, IMapper mapper)
        {
            _spotService = spotService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateSpotResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var spot = _mapper.Map<CreateSpotResource, Spot>(resource);
            var res = await _spotService.SaveAsync(spot);

            if (!res.Success)
            {
                return BadRequest(res.Message);
            }

            var spotResource = _mapper.Map<Spot, SpotResource>(res.Spot);
            return Created("", spotResource);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _spotService.ListAsync();

            if (!res.Success)
            {
                return BadRequest(res.Message);
            }

            var spotResponse = _mapper.Map<IEnumerable<Spot>, IEnumerable<SpotResource>>(res.Spots);
            return Ok(spotResponse);
        }

        [HttpGet]
        [Route("{spotId}")]
        public async Task<IActionResult> GetAsync([FromRoute] string stationId, [FromRoute] string spotId)
        {
            var res = await _spotService.FindByIdAsync(stationId, spotId);
            if (!res.Success)
            {
                return BadRequest(res.Message);
            }

            var spotResponse = _mapper.Map<Spot, SpotResource>(res.Spot);
            return Ok(spotResponse);
        }

        [HttpPut]
        [Route("{spotId}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] CreateSpotResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var spot = _mapper.Map<CreateSpotResource, Spot>(resource);
            var res = await _spotService.UpdateAsync(id, spot);

            if (!res.Success)
            {
                return BadRequest(res.Message);
            }

            var spotResponse = _mapper.Map<Spot, SpotResource>(res.Spot);
            return Ok(spotResponse);
        }

        [HttpDelete]
        [Route("{spotId}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string spotId)
        {
            var res = await _spotService.DeleteAsync(spotId);

            if (!res.Success)
                return BadRequest(res.Message);

            var spotResource = _mapper.Map<Spot, SpotResource>(res.Spot);
            return Ok(spotResource);
        }
    }
}