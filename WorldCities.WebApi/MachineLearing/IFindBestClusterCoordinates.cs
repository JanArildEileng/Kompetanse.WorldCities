using Geolocation;
using WorldCities.WebApi.Models;

namespace WorldCities.WebApi.MachineLearing;

public interface IFindBestClusterCoordinates
{
    List<Coordinate> FindClusterCenters(int numberOfClusters, List<City> cities);
}
