using Newtonsoft.Json;

namespace Dime.Maps
{
    /// <summary>
    /// Represents a request to the XLocate web api
    /// </summary>
    public class AddressByTextRequest
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressByTextRequest"/> class
        /// </summary>
        public AddressByTextRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressByTextRequest"/> class
        /// </summary>
        /// <param name="address">The address</param>
        /// <param name="country">The country</param>
        public AddressByTextRequest(string address, string country)
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
        public AddressByTextRequest(string address, string country, PtvRequestOption[] options)
            : this(address, country)
        {
            Options = options;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the additional fields
        /// </summary>
        [JsonProperty("additionalFields")]
        public object AdditionalFields { get; set; }

        /// <summary>
        /// Gets or sets the address
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the caller context
        /// </summary>
        [JsonProperty("callerContext")]
        public CallerContext CallerContext { get; set; }

        /// <summary>
        /// Gets or sets the country
        /// </summary>
        [JsonProperty("country")]
        public object Country { get; set; }

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
            DateParseHandling = DateParseHandling.None,
            NullValueHandling = NullValueHandling.Ignore
        };

        #endregion Properties

        #region Methods

        /// <summary>
        /// Deserializes the json into a populated address text request
        /// </summary>
        /// <param name="json">The json string to deserialize</param>
        /// <returns>A populated address text request</returns>
        public static AddressByTextRequest FromJson(string json) => JsonConvert.DeserializeObject<AddressByTextRequest>(json, Settings);

        /// <summary>
        /// Serializes the address text request
        /// </summary>
        /// <returns>A serialized string</returns>
        public string ToJson() => JsonConvert.SerializeObject(this, Settings);

        #endregion Methods
    }
}