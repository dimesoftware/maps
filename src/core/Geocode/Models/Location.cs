using System.Text.Json.Serialization;

namespace TurtleRoute
{
    public class Location
    {
        [JsonConstructor]
        public Location(
            ReferencePosition referencePosition,
            RoadAccessPosition roadAccessPosition,
            Address address,
            string formattedAddress,
            string locationType,
            Quality quality
        )
        {
            ReferencePosition = referencePosition;
            RoadAccessPosition = roadAccessPosition;
            Address = address;
            FormattedAddress = formattedAddress;
            LocationType = locationType;
            Quality = quality;
        }

        [JsonPropertyName("referencePosition")]
        public ReferencePosition ReferencePosition { get; }

        [JsonPropertyName("roadAccessPosition")]
        public RoadAccessPosition RoadAccessPosition { get; }

        [JsonPropertyName("address")]
        public Address Address { get; }

        [JsonPropertyName("formattedAddress")]
        public string FormattedAddress { get; }

        [JsonPropertyName("locationType")]
        public string LocationType { get; }

        [JsonPropertyName("quality")]
        public Quality Quality { get; }
    }


}