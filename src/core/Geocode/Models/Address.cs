using Refit;

namespace TurtleRoute
{
    public class Address(string countryName, string state, string postalCode, string city, string street, string houseNumber)
    {
        [AliasAs("country")]
        public string CountryName { get; } = countryName;

        [AliasAs("state")]
        public string State { get; } = state;

        [AliasAs("postalCode")]
        public string PostalCode { get; } = postalCode;

        [AliasAs("locality")]
        public string City { get; } = city;

        [AliasAs("street")]
        public string Street { get; } = street;

        [AliasAs("houseNumber")]
        public string HouseNumber { get; } = houseNumber;

        public virtual bool Validate()
            => (CountryName + State + PostalCode + City + Street + HouseNumber).Replace(" ", "").Replace(",", "").Length > 0;
    }
}