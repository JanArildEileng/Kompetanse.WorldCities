using Geolocation;
using WorldCities.WebApi.Models;

namespace WorldCities.WebApi.Services;

public class BuildClustersService
{
    public List<Cluster> BuildClusters(int includeNumberOfCities, List<Coordinate> clusterCenters, List<City> cities)
    {
        //Create Clusters 
        List<Cluster> clusters = clusterCenters.Select(e => new Cluster
        {
            coordinate = e
        }).ToList();


        foreach (var city in cities.Take(includeNumberOfCities))
        {
            double minDistance = double.MaxValue;
            Cluster? closestCluster = null;

            //find closest cluster
            foreach (var cluster in clusters)
            {
                double distance = GeoCalculator.GetDistance(city.Coordinate, cluster.coordinate, 0, DistanceUnit.Kilometers);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestCluster = cluster;
                }
            }
            closestCluster!.AddCityDistance(city, minDistance);
        }

        return clusters;
    }

}
