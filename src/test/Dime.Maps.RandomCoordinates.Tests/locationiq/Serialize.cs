using Dime.Maps.RandomCoordinates;
using Newtonsoft.Json;

namespace Dime.Maps.RandomCoordinates.Tests
{
    public static class Serialize
    {
        public static string ToJson(this GeocodeResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}