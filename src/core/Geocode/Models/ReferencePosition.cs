using System.Text.Json.Serialization;

namespace TurtleRoute
{
    public class ReferencePosition
    {
        [JsonConstructor]
        public ReferencePosition(
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