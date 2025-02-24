using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TurtleRoute.Tests
{
    [TestClass]
    public class RouterTests
    {
        private string _token;

        [TestInitialize]
        public void Setup()
        {
            IConfigurationRoot settings = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile("appsettings.development.json", true)
                .AddJsonFile("appsettings.test.json", true)
                .Build();

            foreach ((string key, string value) in settings.AsEnumerable())
            {
                switch (key)
                {
                    case "token":
                        _token = value;
                        break;

                    default:
                        continue;
                }
            }
        }

        [TestMethod]
        public async Task Router_Directions_ShouldGetDrivingDirections()
        {
            Router api = new(_token);

            GeoCoordinate start = new(51.219501, 4.359231);
            GeoCoordinate end = new(51.214625, 4.382112);

            IEnumerable<GeoCoordinate> directions = await api.GetDirectionsAsync(start, end);
        }

        private void AssertCoordinates(GeoCoordinate address, double x, double y)
            => Assert.IsTrue(GetDistance(address.Longitude, address.Latitude, x, y) <= 1);

        private double GetDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const int radius = 6371; // Radius of the earth in km
            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = radius * c;  // Distance in km
            return d;
        }

        private double ToRadians(double deg) => deg * (Math.PI / 180);
    }
}