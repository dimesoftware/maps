using System.Text.Json.Serialization;

namespace TurtleRoute.Models
{
    public class AddressRequestData
    {
        [JsonConstructor]
        public AddressRequestData(
            string countryName,
            string state,
            string province,
            string postalCode,
            string city,
            string district,
            string subdistrict,
            string street,
            string houseNumber
        )
        {
            CountryName = countryName;
            State = state;
            Province = province;
            PostalCode = postalCode;
            City = city;
            District = district;
            Subdistrict = subdistrict;
            Street = street;
            HouseNumber = houseNumber;
        }

        [JsonPropertyName("countryName")]
        public string CountryName { get; }

        [JsonPropertyName("state")]
        public string State { get; }

        [JsonPropertyName("province")]
        public string Province { get; }

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; }

        [JsonPropertyName("city")]
        public string City { get; }

        [JsonPropertyName("district")]
        public string District { get; }

        [JsonPropertyName("subdistrict")]
        public string Subdistrict { get; }

        [JsonPropertyName("street")]
        public string Street { get; }

        [JsonPropertyName("houseNumber")]
        public string HouseNumber { get; }
    }
}