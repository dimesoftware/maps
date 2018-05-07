using Newtonsoft.Json;

namespace Dime.Maps
{
    /// <summary>
    /// Represents a coordinate
    /// </summary>
    public class Point
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class
        /// </summary>
        public Point()
        {
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [JsonProperty("$type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the X - value (or the longitude)
        /// </summary>
        [JsonProperty("x")]
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the Y - value (or the latitude)
        /// </summary>
        [JsonProperty("y")]
        public double Y { get; set; }

        #endregion Properties
    }
}