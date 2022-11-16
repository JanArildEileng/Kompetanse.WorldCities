using Microsoft.AspNetCore.Mvc;
using WorldCities.WebApi.Models;
using WorldCities.WebApi.Services;
using System.Linq;

namespace WorldCities.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorldCitiesController : ControllerBase
    {
       
        private readonly ILogger<WorldCitiesController> _logger;

        public WorldCitiesController(ILogger<WorldCitiesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWorldCities")]
        public IEnumerable<City> GetWorldCities( [FromServices] ReadCitiesFromFileService readCitiesFromFileService, int takeNumber = 20)
        {

            var cities = readCitiesFromFileService.GetCities()
               .Take(takeNumber);

            return cities;
        }
    }
}