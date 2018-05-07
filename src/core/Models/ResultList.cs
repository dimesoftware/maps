using Newtonsoft.Json;

namespace Dime.Maps
{
    /// <summary>
    /// Represents the content bit in the response from the XLocate web api
    /// </summary>
    public class ResultList
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultList"/> class
        /// </summary>
        public ResultList()
        {
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the additional fields
        /// </summary>
        [JsonProperty("additionalFields")]
        public object[] AdditionalFields { get; set; }

        /// <summary>
        /// Gets or sets the administrative region
        /// </summary>
        [JsonProperty("adminRegion")]
        public string AdminRegion { get; set; }

        /// <summary>
        /// Gets or sets the appendix
        /// </summary>
        [JsonProperty("appendix")]
        public string Appendix { get; set; }

        /// <summary>
        /// Gets or sets the city
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the appendix of the city
        /// </summary>
        [JsonProperty("city2")]
        public string City2 { get; set; }

        /// <summary>
        /// Gets or sets the classification description (e.g. UNIQUE)
        /// </summary>
        [JsonProperty("classificationDescription")]
        public string ClassificationDescription { get; set; }

        /// <summary>
        /// Gets or sets the coordinates
        /// </summary>
        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }

        /// <summary>
        /// Gets or sets the country
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the country's capital
        /// </summary>
        [JsonProperty("countryCapital")]
        public string CountryCapital { get; set; }

        /// <summary>
        /// Gets or sets the detailed level description
        /// </summary>
        [JsonProperty("detailLevelDescription")]
        public string DetailLevelDescription { get; set; }

        /// <summary>
        /// Gets or sets the house number
        /// </summary>
        [JsonProperty("houseNumber")]
        public string HouseNumber { get; set; }

        /// <summary>
        /// Gets or sts the zip code
        /// </summary>
        [JsonProperty("postCode")]
        public string PostCode { get; set; }

        /// <summary>
        /// Gets or sets the state
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the street
        /// </summary>
        [JsonProperty("street")]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the total score
        /// </summary>
        [JsonProperty("totalScore")]
        public long TotalScore { get; set; }

        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [JsonProperty("$type")]
        public string Type { get; set; }

        #endregion Properties
    }
}