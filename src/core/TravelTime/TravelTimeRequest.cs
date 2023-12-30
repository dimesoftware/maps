using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TurtleRoute.TravelTime
{
    public partial class TravelTimeRequest
    {
        [JsonPropertyName("origins")]
        public List<Coordinate> Origins { get; set; } = new List<Coordinate>();
    }
}