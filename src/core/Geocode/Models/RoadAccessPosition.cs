using System.Text.Json.Serialization;

namespace TurtleRoute
{
    public class RoadAccessPosition
    {
        [JsonConstructor]
        public RoadAccessPosition(
            double latitude,
            double longitude
        )
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        [JsonPropertyName("latitude")]
        public double Latitude { get; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; }
    }


}