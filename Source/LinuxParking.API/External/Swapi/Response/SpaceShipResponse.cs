using System.Collections.Generic;
using LinuxParking.API.External.Swapi.Models;
namespace LinuxParking.API.External.Swapi.Response
{
    public class SpaceShipResponse
    {
        public List<SpaceShip> Results { get; set; }
    }
}