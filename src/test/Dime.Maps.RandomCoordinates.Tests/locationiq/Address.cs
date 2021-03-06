using Newtonsoft.Json;

namespace Dime.Maps.RandomCoordinates
{
    public partial class Address
    {
        [JsonProperty("footway")]
        public string Footway { get; set; }

        [JsonProperty("residential")]
        public string Residential { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
    }
}