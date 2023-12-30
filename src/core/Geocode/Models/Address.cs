using Refit;

namespace TurtleRoute
{
    public class Address
    {
        public Address(
            string countryName,
            string state,
            string postalCode,
            string city,
            string street,
            string houseNumber
        )
        {
            CountryName = countryName;
            State = state;
            PostalCode = postalCode;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        [AliasAs("country")]
        public string CountryName { get; }

        [AliasAs("state")]
        public string State { get; }

        [AliasAs("postalCode")]
        public string PostalCode { get; }

        [AliasAs("locality")]
        public string City { get; }

        [AliasAs("street")]
        public string Street { get; }

        [AliasAs("houseNumber")]
        public string HouseNumber { get; }
    }
}