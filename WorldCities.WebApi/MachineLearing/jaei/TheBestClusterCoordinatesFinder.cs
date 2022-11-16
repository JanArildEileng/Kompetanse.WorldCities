using Geolocation;
using WorldCities.WebApi.Models;

namespace WorldCities.WebApi.MachineLearing.jaei;

public class TheBestClusterCoordinatesFinder : IFindBestClusterCoordinates
{
    public List<Coordinate> FindClusterCenters(int numberOfClusters, List<City> cities)
    {
        List<Coordinate> coordinates = new();

        for (int i = 0; i < numberOfClusters; i++)
        {
            coordinates.Add(cities[i].Coordinate);
        }
        return coordinates;
    }
}
