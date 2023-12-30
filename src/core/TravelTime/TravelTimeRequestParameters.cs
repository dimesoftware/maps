using System.Collections.Generic;

namespace TurtleRoute.TravelTime
{
    public class TravelTimeRequestParameters
    {
        public IEnumerable<long> Appointments { get; set; }
    }
}