using Geolocation;

namespace WorldCities.WebApi.Models
{
    public class Cluster
    {
        public record CityDistance(String Name, double Distance);
   
        private List<CityDistance> listeOfCityDistance = new();
        public Coordinate coordinate { get; set; }
        public double Cost => Math.Sqrt(listeOfCityDistance.Sum(e => e.Distance * e.Distance));

        public IReadOnlyList<CityDistance> CityWithDistances => listeOfCityDistance.OrderBy(e => e.Distance).ToList();
      
        internal void AddCityDistance(City city, double minDistance)
        {
            listeOfCityDistance.Add(new CityDistance(city.Name,minDistance));
        }
    }


}
