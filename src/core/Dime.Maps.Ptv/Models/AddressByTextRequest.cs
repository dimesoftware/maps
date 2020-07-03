using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Dime.Maps
{
    /// <summary>
    /// Represents a request to the XLocate web api
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class AddressByTextRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressByTextRequest"/> class
        /// </summary>
        internal AddressByTextRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressByTextRequest"/> class
        /// </summary>
        /// <param name="address">The address</param>
        /// <param name="country">The country</param>
        internal AddressByTextRequest(string address, string country)
        {
            Address = address;
            Country = country;
            CallerContext = CallerContext.Default();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressByTextRequest"/> class
        /// </summary>
        /// <param name="address">The address</param>
        /// <param name="country">The country</param>
        /// <param name="options">The options</param>
        internal AddressByTextRequest(string address, string country, PtvRequestOption[] options)
            : this(address, country)
        {
            Options = options;
        }

        /// <summary>
        /// Gets or sets the additional fields
        /// </summary>
        [JsonProperty("additionalFields")]
        internal object AdditionalFields { get; set; }

        /// <summary>
        /// Gets or sets the address
        /// </summary>
        [JsonProperty("address")]
        internal string Address { get; set; }

        /// <summary>
        /// Gets or sets the caller context
        /// </summary>
        [JsonProperty("callerContext")]
        internal CallerContext CallerContext { get; set; }

        /// <summary>
        /// Gets or sets the country
        /// </summary>
        [JsonProperty("country")]
        internal object Country { get; set; }

        /// <summary>
        /// Gets or sets the options
        /// </summary>
        [JsonProperty("options")]
        internal PtvRequestOption[] Options { get; set; }

        /// <summary>
        /// Gets or sets the sorting
        /// </summary>
        [JsonProperty("sorting")]
        internal object Sorting { get; set; }

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            NullValueHandling = NullValueHandling.Ignore
        };

        /// <summary>
        /// Deserializes the json into a populated address text request
        /// </summary>
        /// <param name="json">The json string to deserialize</param>
        /// <returns>A populated address text request</returns>
        internal static AddressByTextRequest FromJson(string json) => JsonConvert.DeserializeObject<AddressByTextRequest>(json, Settings);

        /// <summary>
        /// Serializes the address text request
        /// </summary>
        /// <returns>A serialized string</returns>
        internal string ToJson() => JsonConvert.SerializeObject(this, Settings);
    }
}