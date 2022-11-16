namespace WorldCities.WebApi.Models
{
    public class ClusterPapport
    {
        public ClusterPapport(int numberOfClusters, int learnFromNumberOfCities, int includeNumberOfCities, List<Cluster> clusters)
        {
            header = new ClusterPapportHeader(numberOfClusters, learnFromNumberOfCities, includeNumberOfCities, (long)clusters.Sum(e => e.Cost));
            details = new ClusterPapportDetails(clusters);
        }

        public ClusterPapportHeader header { get; init; }
        public ClusterPapportDetails details { get; init; }
    }

    public record ClusterPapportHeader(int numberOfClusters, int learnFromNumberOfCities, int includeNumberOfCities, long TotalCost);

    public record ClusterPapportDetails(List<Cluster> clusters);


}
