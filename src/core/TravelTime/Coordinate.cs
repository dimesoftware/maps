using System.Text.Json.Serialization;

namespace TurtleRoute.TravelTime
{
    public class Coordinate
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; }

        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}