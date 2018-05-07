using System.ComponentModel;

namespace Dime.Maps
{
    /// <summary>
    /// Represents a type of entity
    /// </summary>
    public enum EntityType
    {
        [Description("RESOURCE")]
        Resource,

        [Description("JOB")]
        Job
    }
}