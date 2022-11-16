using WorldCities.WebApi.Models;

namespace WorldCities.WebApi.Services;

public class ReadCitiesFromFileService 
{
    public List<City> GetCities()
    {
        List<City> cities = new();

        using (var stream = File.OpenText(@".\DataFiles\100Cities.csv"))
        {
            stream.ReadLine(); //skip header
            string line=stream.ReadLine();
            while (line != null)
            {
                var splitted = line.Split("\",");
                try
                {
                    City city = new City(
                    
                        splitted[0].Replace('"', ' ').Trim(),
                        splitted[4].Replace('"', ' ').Trim(),
                        new Geolocation.Coordinate(
                            double.Parse(splitted[2].Replace('"', ' ').Replace('.', ',')),
                            double.Parse(splitted[3].Replace('"', ' ').Replace('.', ','))
                        ),
                        long.Parse(splitted[9].Replace('"', ' '))
                    );
                    cities.Add(city);
                }
                catch (Exception)
                {
                }

               line = stream.ReadLine();
            }
        }
        return cities.OrderByDescending(e=>e.Population).ToList();
    }
}
