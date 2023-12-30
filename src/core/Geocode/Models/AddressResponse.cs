using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TurtleRoute
{
    public class AddressResponse
    {
        [JsonConstructor]
        public AddressResponse()
        {
        }

        public AddressResponse(List<Location> locations)
        {
            Locations = locations;
        }

        [JsonPropertyName("locations")]
        public IReadOnlyList<Location> Locations { get; set; }
    }
}