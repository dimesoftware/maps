using Newtonsoft.Json;
using System.Collections.Generic;

namespace Dime.Maps
{
    /// <summary>
    /// Represents a placeholder to include instructions to the request
    /// </summary>
    internal class CallerContext
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CallerContext"/> class
        /// </summary>
        internal CallerContext()
        {
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the properties
        /// </summary>
        [JsonProperty("properties")]
        internal Property[] Properties { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Short-hand method for constructng an instance of <see cref="CallerContext"/> with default properties
        /// </summary>
        /// <returns>An instance with default properties</returns>
        internal static CallerContext Default() => new CallerContext
        {
            Properties = new List<Property>
            {
                new Property("CoordFormat","OG_GEODECIMAL")
            }.ToArray()
        };

        #endregion Methods
    }
}