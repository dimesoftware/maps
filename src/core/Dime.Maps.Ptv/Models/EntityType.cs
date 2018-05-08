using System.ComponentModel;

namespace Dime.Maps
{
    /// <summary>
    /// Represents a type of entity
    /// </summary>
    internal enum EntityType
    {
        [Description("RESOURCE")]
        Resource,

        [Description("JOB")]
        Job
    }
}