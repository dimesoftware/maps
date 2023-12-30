using System.Text.Json.Serialization;

namespace TurtleRoute.Models
{
    public class AddressRequest
    {
        [JsonConstructor]
        public AddressRequest(
            AddressRequestData address,
            string formattedAddress
        )
        {
            Address = address;
            FormattedAddress = formattedAddress;
        }

        [JsonPropertyName("address")]
        public AddressRequestData Address { get; }

        [JsonPropertyName("formattedAddress")]
        public string FormattedAddress { get; }
    }
}