using Newtonsoft.Json;

namespace Dime.Maps
{
    /// <summary>
    /// Represents a request to the XLocate web api
    /// </summary>
    public class AddressRequest
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRequest"/> class
        /// </summary>
        public AddressRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRequest"/> class
        /// </summary>
        /// <param name="address">The address</param>
        /// <param name="callerContext">The caller context</param>
        public AddressRequest(Address address, CallerContext callerContext)
        {
            Address = address;
            CallerContext = callerContext;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the additional fields
        /// </summary>
        [JsonProperty("additionalFields")]
        public object[] AdditionalFields { get; set; }

        /// <summary>
        /// Gets or sets the address
        /// </summary>
        [JsonProperty("addr")]
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the caller context
        /// </summary>
        [JsonProperty("callerContext")]
        public CallerContext CallerContext { get; set; }

        /// <summary>
        /// Gets or sets the options
        /// </summary>
        [JsonProperty("options")]
        public PtvRequestOption[] Options { get; set; }

        /// <summary>
        /// Gets or sets the sorting
        /// </summary>
        [JsonProperty("sorting")]
        public object Sorting { get; set; }

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None
        };

        #endregion Properties

        #region Methods

        /// <summary>
        /// Deserializes the json into a populated address request
        /// </summary>
        /// <param name="json">The json string to deserialize</param>
        /// <returns>A populated address request</returns>
        public static AddressRequest FromJson(string json) => JsonConvert.DeserializeObject<AddressRequest>(json, Settings);

        /// <summary>
        /// Serializes the address request
        /// </summary>
        /// <returns>A serialized string</returns>
        public string ToJson() => JsonConvert.SerializeObject(this, Settings);

        #endregion Methods
    }
}