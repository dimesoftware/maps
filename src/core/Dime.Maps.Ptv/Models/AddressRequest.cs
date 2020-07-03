using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Dime.Maps
{
    /// <summary>
    /// Represents a request to the XLocate web api
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class AddressRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRequest"/> class
        /// </summary>
        internal AddressRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRequest"/> class
        /// </summary>
        /// <param name="address">The address</param>
        /// <param name="callerContext">The caller context</param>
        internal AddressRequest(Address address, CallerContext callerContext)
        {
            Address = address;
            CallerContext = callerContext;
        }

        /// <summary>
        /// Gets or sets the additional fields
        /// </summary>
        [JsonProperty("additionalFields")]
        internal object[] AdditionalFields { get; set; }

        /// <summary>
        /// Gets or sets the address
        /// </summary>
        [JsonProperty("addr")]
        internal Address Address { get; set; }

        /// <summary>
        /// Gets or sets the caller context
        /// </summary>
        [JsonProperty("callerContext")]
        internal CallerContext CallerContext { get; set; }

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
            DateParseHandling = DateParseHandling.None
        };

        /// <summary>
        /// Deserializes the json into a populated address request
        /// </summary>
        /// <param name="json">The json string to deserialize</param>
        /// <returns>A populated address request</returns>
        internal static AddressRequest FromJson(string json) => JsonConvert.DeserializeObject<AddressRequest>(json, Settings);

        /// <summary>
        /// Serializes the address request
        /// </summary>
        /// <returns>A serialized string</returns>
        internal string ToJson() => JsonConvert.SerializeObject(this, Settings);
    }
}