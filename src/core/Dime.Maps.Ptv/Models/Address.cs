using Newtonsoft.Json;

namespace Dime.Maps
{
    /// <summary>
    /// Represents an address
    /// </summary>
    internal class Address
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class
        /// </summary>
        internal Address()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class
        /// </summary>
        /// <param name="street">The street name</param>
        /// <param name="houseNumber">The house number</param>
        /// <param name="postcode">The zip code</param>
        /// <param name="city">The city</param>
        internal Address(string street, string houseNumber, string postcode, string city)
        {
            Street = street;
            HouseNumber = houseNumber;
            City = city;
            PostCode = postcode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class
        /// </summary>
        /// <param name="street">The street name</param>
        /// <param name="houseNumber">The house number</param>
        /// <param name="postcode">The zip code</param>
        /// <param name="city">The citys</param>
        internal Address(string street, string houseNumber, string postcode, string city, string state, string country) : this(street, houseNumber, postcode, city)
        {
            State = state;
            Country = country;
        }

        /// <summary>
        /// Gets or sets the street
        /// </summary>
        [JsonProperty("street")]
        internal string Street { get; set; }

        /// <summary>
        /// Gets or sets the street
        /// </summary>
        [JsonProperty("houseNumber")]
        internal string HouseNumber { get; set; }

        /// <summary>
        /// Gets or sets the post code
        /// </summary>
        [JsonProperty("postCode")]
        internal string PostCode { get; set; }

        /// <summary>
        /// Gets or sets the city
        /// </summary>
        [JsonProperty("city")]
        internal string City { get; set; }

        /// <summary>
        /// Gets or sets the city 2 (PTV requirement)
        /// </summary>
        [JsonProperty("city2")]
        internal string City2 { get; set; }

        /// <summary>
        /// Gets or sets the state
        /// </summary>
        [JsonProperty("state")]
        internal string State { get; set; }

        /// <summary>
        /// Gets or sets the country
        /// </summary>
        [JsonProperty("country")]
        internal string Country { get; set; }
    }
}