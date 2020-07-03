using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Dime.Maps
{
    /// <summary>
    /// Represents the content bit in the response from the XLocate web api
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class ResultList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultList"/> class
        /// </summary>
        internal ResultList()
        {
        }

        /// <summary>
        /// Gets or sets the additional fields
        /// </summary>
        [JsonProperty("additionalFields")]
        internal object[] AdditionalFields { get; set; }

        /// <summary>
        /// Gets or sets the administrative region
        /// </summary>
        [JsonProperty("adminRegion")]
        internal string AdminRegion { get; set; }

        /// <summary>
        /// Gets or sets the appendix
        /// </summary>
        [JsonProperty("appendix")]
        internal string Appendix { get; set; }

        /// <summary>
        /// Gets or sets the city
        /// </summary>
        [JsonProperty("city")]
        internal string City { get; set; }

        /// <summary>
        /// Gets or sets the appendix of the city
        /// </summary>
        [JsonProperty("city2")]
        internal string City2 { get; set; }

        /// <summary>
        /// Gets or sets the classification description (e.g. UNIQUE)
        /// </summary>
        [JsonProperty("classificationDescription")]
        internal string ClassificationDescription { get; set; }

        /// <summary>
        /// Gets or sets the coordinates
        /// </summary>
        [JsonProperty("coordinates")]
        internal Coordinates Coordinates { get; set; }

        /// <summary>
        /// Gets or sets the country
        /// </summary>
        [JsonProperty("country")]
        internal string Country { get; set; }

        /// <summary>
        /// Gets or sets the country's capital
        /// </summary>
        [JsonProperty("countryCapital")]
        internal string CountryCapital { get; set; }

        /// <summary>
        /// Gets or sets the detailed level description
        /// </summary>
        [JsonProperty("detailLevelDescription")]
        internal string DetailLevelDescription { get; set; }

        /// <summary>
        /// Gets or sets the house number
        /// </summary>
        [JsonProperty("houseNumber")]
        internal string HouseNumber { get; set; }

        /// <summary>
        /// Gets or sts the zip code
        /// </summary>
        [JsonProperty("postCode")]
        internal string PostCode { get; set; }

        /// <summary>
        /// Gets or sets the state
        /// </summary>
        [JsonProperty("state")]
        internal string State { get; set; }

        /// <summary>
        /// Gets or sets the street
        /// </summary>
        [JsonProperty("street")]
        internal string Street { get; set; }

        /// <summary>
        /// Gets or sets the total score
        /// </summary>
        [JsonProperty("totalScore")]
        internal long TotalScore { get; set; }

        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [JsonProperty("$type")]
        internal string Type { get; set; }
    }
}