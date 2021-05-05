using System.Collections.Generic;

namespace LinuxParking.API.External.Swapi.Models
{
    public class Character
    {
        public string Name { get; set; }
        public List<string> SpaceShips { get; set; }
    }
}