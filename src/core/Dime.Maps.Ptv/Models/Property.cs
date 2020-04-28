using Newtonsoft.Json;

namespace Dime.Maps
{
    /// <summary>
    ///
    /// </summary>
    internal class Property
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Property"/> class
        /// </summary>
        internal Property()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Property"/> class
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        internal Property(string key, string value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("key")]
        internal string Key { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("value")]
        internal string Value { get; set; }
    }
}