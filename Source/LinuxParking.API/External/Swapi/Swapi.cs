using RestSharp;
using System.Threading.Tasks;
using System.Collections.Generic;
using LinuxParking.API.External.Swapi.Models;
using LinuxParking.API.External.Swapi.Response;

namespace LinuxParking.API.External.Swapi
{
    public static class Swapi
    {
        private static async Task<T> Request<T>(string req) {
            var client = new RestClient("https://swapi.dev/api");
            var request = new RestRequest(req, DataFormat.Json);
            return await client.GetAsync<T>(request);
        }

        public static async Task<Character> FetchCharacterByName(string name) {
            var res = await Request<CharacterResponse>($"people/?search={name}");
            if (res.Results == null)
                return null;

            return res.Results.Find(c => c.Name.ToLower() == name.ToLower());
        }
        public static async Task<SpaceShip> FetchSpaceShipByName(string name) {
            var res = await Request<SpaceShipResponse>($"starships/?search={name}");
            if (res.Results == null)
                return null;

            return res.Results.Find(c => c.Name.ToLower() == name.ToLower());
        }
    }
}