using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dime.Maps.RandomCoordinates
{
    public partial class GeocodeResponse
    {
        [JsonProperty("place_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long PlaceId { get; set; }

        [JsonProperty("licence")]
        public Uri Licence { get; set; }

        [JsonProperty("osm_type")]
        public string OsmType { get; set; }

        [JsonProperty("osm_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long OsmId { get; set; }

        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("lon")]
        public string Lon { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("boundingbox")]
        public List<string> Boundingbox { get; set; }
    }
}