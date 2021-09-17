using Medecin.Models;
using Medecin.WeatherRestClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Medecin.ServiceHandler
{
    public class WeatherServices
    {
        OpenWeatherMap<WeatherMainModel> _openWeatherRest = new OpenWeatherMap<WeatherMainModel>();
        public async Task<WeatherMainModel> GetWeatherDetails(string city)
        {
            var getWeatherDetails = await _openWeatherRest.GetAllWeathers(city);
            return getWeatherDetails;
        }
    }
}
