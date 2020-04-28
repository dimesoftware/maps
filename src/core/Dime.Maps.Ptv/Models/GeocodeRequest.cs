using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dime.Maps
{
    /// <summary>
    /// Represents a request to geocode an item
    /// </summary>
    internal class GeocodeRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeocodeRequest"/> class
        /// </summary>
        internal GeocodeRequest()
        {
        }

        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        internal long? Id { get; set; }

        /// <summary>
        /// Gets or sets the flag whether to process them all
        /// </summary>
        internal bool GeocodeAll { get; set; }

        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        internal EntityType Type { get; set; }
    }
}