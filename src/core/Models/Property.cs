using Newtonsoft.Json;

namespace Dime.Maps
{
    /// <summary>
    ///
    /// </summary>
    public class Property
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Property"/> class
        /// </summary>
        public Property()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Property"/> class
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        public Property(string key, string value)
        {
            Key = key;
            Value = value;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        #endregion Properties
    }
}