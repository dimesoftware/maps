using Newtonsoft.Json;

namespace Dime.Maps
{
    /// <summary>
    /// Represents extra options that go in the request
    /// </summary>
    public class PtvRequestOption
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PtvRequestOption"/> class
        /// </summary>
        public PtvRequestOption()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PtvRequestOption"/> class
        /// </summary>
        /// <param name="param"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        public PtvRequestOption(string param, string value)
        {
            Param = param;
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PtvRequestOption"/> class
        /// </summary>
        /// <param name="param"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        public PtvRequestOption(string param, string value, string type) : this(param, value)
        {
            Type = type;
        }

        #endregion Constructor

        #region Properties

        [JsonProperty("$type")]
        public string Type { get; set; } = "SearchOption";

        [JsonProperty("param")]
        public string Param { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        #endregion Properties
    }
}