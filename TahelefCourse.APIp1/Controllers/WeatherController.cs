using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tahelef.Core.DTO;

namespace TahelefCourse.APIp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {

        [HttpGet("weather/{city}")]
        public async Task<Weather> City(string city)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=511ba00e6b1fdebcf7456541e7a16390");
                var stringResult = await response.Content.ReadAsStringAsync();
                var weatherResult = JsonConvert.DeserializeObject<Weather>(stringResult);
                return weatherResult;
            }
           
        }
    }
} 
    
