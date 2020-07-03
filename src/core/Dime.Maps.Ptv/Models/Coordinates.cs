using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Dime.Maps
{
    /// <summary>
    /// Represents a wrapper around the coordinate to include the type
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class Coordinates
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates"/> class
        /// </summary>
        internal Coordinates()
        {
        }

        /// <summary>
        /// Gets or sets the coordinate
        /// </summary>
        [JsonProperty("point")]
        internal Point Point { get; set; }

        /// <summary>
        /// Gets or sets the coordinate
        /// </summary>
        [JsonProperty("$type")]
        internal string Type { get; set; }
    }
}