using System.Collections.Generic;
using LinuxParking.API.External.Swapi.Models;
namespace LinuxParking.API.External.Swapi.Response
{
    public class CharacterResponse
    {
        public List<Character> Results { get; set; }
    }
}