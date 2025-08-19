using DadJokesApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DadJokesApp.Services
{
    public class DadJokeApiService
    {
         private HttpClient _httpClient;

        public DadJokeApiService()
        {
            _httpClient = new HttpClient();
        }


        public async Task<DadJoke> GetDadJoke()
        {
            string apiUrl = "https://icanhazdadjoke.com/";

            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            string response = await _httpClient.GetStringAsync(apiUrl);

            DadJoke dadJoke = JsonConvert.DeserializeObject<DadJoke>(response);

            return dadJoke;

        }
    }
}
