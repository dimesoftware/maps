using System.Text.Json.Serialization;

namespace TurtleRoute
{
    [method: JsonConstructor]
    public class Location(ReferencePosition referencePosition, RoadAccessPosition roadAccessPosition, Address address, string formattedAddress, string locationType, Quality quality)
    {
        [JsonPropertyName("referencePosition")]
        public ReferencePosition ReferencePosition { get; } = referencePosition;

        [JsonPropertyName("roadAccessPosition")]
        public RoadAccessPosition RoadAccessPosition { get; } = roadAccessPosition;

        [JsonPropertyName("address")]
        public Address Address { get; } = address;

        [JsonPropertyName("formattedAddress")]
        public string FormattedAddress { get; } = formattedAddress;

        [JsonPropertyName("locationType")]
        public string LocationType { get; } = locationType;

        [JsonPropertyName("quality")]
        public Quality Quality { get; } = quality;
    }
}