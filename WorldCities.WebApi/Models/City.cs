using Geolocation;

namespace WorldCities.WebApi.Models;

public  record  City(string Name, string Country, Coordinate Coordinate, long Population);
