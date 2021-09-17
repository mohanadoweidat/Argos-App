using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Medecin.WeatherRestClient
{
    public class OpenWeatherMap<T>
    {
        private const string OpenWeatherApi = "http://api.openweathermap.org/data/2.5/weather?q=";
        private const string Key = "679141089caeedfc5bd60a8e184b4c37";
        HttpClient _httpClient = new HttpClient();

        public async Task<T> GetAllWeathers(string city)
        {
            var json = await _httpClient.GetStringAsync(OpenWeatherApi + city + "&APPID=" + Key);
            var getWeatherModels = JsonConvert.DeserializeObject<T>(json);
            return getWeatherModels;
        }
    }
}
