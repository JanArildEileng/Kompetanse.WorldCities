using Microsoft.AspNetCore.Mvc;
using WorldCities.WebApi.Models;
using WorldCities.WebApi.Services;
using System.Linq;
using Geolocation;

namespace WorldCities.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistanceFromController : ControllerBase
    {
       
        private readonly ILogger<DistanceFromController> _logger;

        public DistanceFromController(ILogger<DistanceFromController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetDistanceFromTokyo")]
        public IEnumerable<Object> GetDistanceFrom( [FromServices] ReadCitiesFromFileService readCitiesFromFileService,string fromCityName= "Tokyo", int takeNumber = 20)
        {
            var cities = readCitiesFromFileService.GetCities().Take(takeNumber);


            var fromCity = cities.First(e => e.Name == fromCityName);
            Coordinate geoCoordinate = fromCity.Coordinate;

            var list = cities.Select(city => new
            {
                distance = GeoCalculator.GetDistance(city.Coordinate, fromCity.Coordinate, 0, DistanceUnit.Kilometers),
                city=city.Name

            }).OrderBy(e=>e.distance);


            return list;
        }
    }
}