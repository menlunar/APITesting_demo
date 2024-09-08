using DemoAPI.Interfaces;
using RestSharp;
using System.Threading;
using DemoAPI.Models;
using System.Text.Json;

namespace DemoAPI.API
{
    public class CharacterAPI : ICharacterAPI
    {
        public string GetCharacterFromAPI(int id)
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest($"people/{id}");
            var response = client.Execute(request);
            return response.Content;

        }
    }
}
