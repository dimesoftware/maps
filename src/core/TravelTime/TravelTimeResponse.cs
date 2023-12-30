using System.Text.Json.Serialization;

namespace TurtleRoute.TravelTime
{
    public partial class TravelTimeResponse
    {
        [JsonPropertyName("travelTimes")]
        public int[] TravelTimes { get; set; }
    }
}