using System.Text.Json.Serialization;

namespace TurtleRoute
{
    [method: JsonConstructor]
    public class RoadAccessPosition(double latitude, double longitude)
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; } = latitude;

        [JsonPropertyName("longitude")]
        public double Longitude { get; } = longitude;
    }
}