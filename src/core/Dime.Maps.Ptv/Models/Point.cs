using Newtonsoft.Json;

namespace Dime.Maps
{
    /// <summary>
    /// Represents a coordinate
    /// </summary>
    internal class Point
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class
        /// </summary>
        internal Point()
        {
        }

        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [JsonProperty("$type")]
        internal string Type { get; set; }

        /// <summary>
        /// Gets or sets the X - value (or the longitude)
        /// </summary>
        [JsonProperty("x")]
        internal double X { get; set; }

        /// <summary>
        /// Gets or sets the Y - value (or the latitude)
        /// </summary>
        [JsonProperty("y")]
        internal double Y { get; set; }
    }
}