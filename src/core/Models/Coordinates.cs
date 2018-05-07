using Newtonsoft.Json;

namespace Dime.Maps
{
    /// <summary>
    /// Represents a wrapper around the coordinate to include the type
    /// </summary>
    public class Coordinates
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates"/> class
        /// </summary>
        public Coordinates()
        {
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the coordinate
        /// </summary>
        [JsonProperty("point")]
        public Point Point { get; set; }

        /// <summary>
        /// Gets or sets the coordinate
        /// </summary>
        [JsonProperty("$type")]
        public string Type { get; set; }

        #endregion Properties
    }
}