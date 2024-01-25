using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {

        public List<CityWeather> weathers { get; set; }
        public WeatherController()
        {
            weathers = WeatherData.GetData();
        }
        [Route("/")]
        [Route("/weather")]
        public IActionResult Index()
        {
            return View(weathers);
        }
        [Route("/weather/{cityCode}")]
        public IActionResult Details([FromRoute]string cityCode)
        {
            CityWeather weather = weathers.FirstOrDefault(w => w.CityUniqueCode == cityCode);
            if(weather == null)
            {
                return View("ErrorMessage");
            }
            return View(weather);
        }
    }
    public static class WeatherData
    {
        public static List<CityWeather> GetData()
        {
            List<CityWeather> cityWeathers = new List<CityWeather>
            {
                new CityWeather() {
                    CityUniqueCode = "LDN", CityName = "London", DateAndTime = new DateTime(2030, 01, 01, 8, 00, 00),  TemperatureFahrenheit = 33
                },
                new CityWeather() {
                    CityUniqueCode = "NYC", CityName = "New York", DateAndTime = new DateTime(2030, 01, 01, 3, 00, 00),  TemperatureFahrenheit = 60
                },
                new CityWeather() {
                    CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = new DateTime(2030, 01, 01, 9, 00, 00),  TemperatureFahrenheit = 82
                }
            };
            return cityWeathers;
        }
    }
}
