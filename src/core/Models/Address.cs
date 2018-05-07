using Newtonsoft.Json;

namespace Dime.Maps
{
    /// <summary>
    /// Represents an address
    /// </summary>
    public class Address
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class
        /// </summary>
        public Address()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class
        /// </summary>
        /// <param name="street">The street name</param>
        /// <param name="houseNumber">The house number</param>
        /// <param name="postcode">The zip code</param>
        /// <param name="city">The city</param>
        public Address(string street, string houseNumber, string postcode, string city)
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
        public Address(string street, string houseNumber, string postcode, string city, string state, string country) : this(street, houseNumber, postcode, city)
        {
            State = state;
            Country = country;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the street
        /// </summary>
        [JsonProperty("street")]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the street
        /// </summary>
        [JsonProperty("houseNumber")]
        public string HouseNumber { get; set; }

        /// <summary>
        /// Gets or sets the post code
        /// </summary>
        [JsonProperty("postCode")]
        public string PostCode { get; set; }

        /// <summary>
        /// Gets or sets the city
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the city 2 (PTV requirement)
        /// </summary>
        [JsonProperty("city2")]
        public string City2 { get; set; }

        /// <summary>
        /// Gets or sets the state
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the country
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        #endregion Properties
    }
}