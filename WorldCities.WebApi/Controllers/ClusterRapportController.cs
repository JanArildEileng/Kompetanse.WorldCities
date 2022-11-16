using Microsoft.AspNetCore.Mvc;
using WorldCities.WebApi.Models;
using WorldCities.WebApi.Services;
using Geolocation;
using WorldCities.WebApi.MachineLearing;

namespace WorldCities.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClusterRapportController : ControllerBase
{
    private readonly BuildClustersService buildClustersService;
    private readonly ReadCitiesFromFileService readCitiesFromFileService;

    public ClusterRapportController(BuildClustersService buildClustersService, ReadCitiesFromFileService readCitiesFromFileService)
    {
        this.buildClustersService = buildClustersService;
        this.readCitiesFromFileService = readCitiesFromFileService;
    }

    [HttpGet(Name = "GetClusterRapport")]
    public ClusterPapport GetClusterRapport([FromServices] IFindBestClusterCoordinates findBestClusterCoordinates,int numberOfClusters=5, int learnFromNumberOfCities = 20,int includeNumberOfCities=20)
    {
        var cities = readCitiesFromFileService.GetCities();

        //find best clusterCenters
        List<Coordinate> clusterCenters = findBestClusterCoordinates.FindClusterCenters(numberOfClusters, cities.Take(learnFromNumberOfCities).ToList());

        //build clusters
        List<Cluster> clusters = buildClustersService.BuildClusters(includeNumberOfCities, clusterCenters, cities);

        return new ClusterPapport(numberOfClusters, learnFromNumberOfCities, includeNumberOfCities, clusters);
    }
}