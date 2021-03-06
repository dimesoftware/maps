using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dime.Maps.Tests
{
    [TestClass]
    public class PtvApiTests
    {
        private string _token;
        private string _user;
        private string _url;

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
                    case "user":
                        _user = value;
                        break;
                    case "url":
                        _url = value;
                        break;
                    default:
                        continue;
                }
            }
        }

        [TestMethod]
        public void PtvApi_Constructor_InvalidParameter_Url_ThrowsArgumentNullException()
            => Assert.ThrowsException<ArgumentNullException>(() => new PtvGeocoder(string.Empty, _user, _token));

        [TestMethod]
        public void PtvApi_Constructor_InvalidParameter_User_ThrowsArgumentNullException()
            => Assert.ThrowsException<ArgumentNullException>(() => new PtvGeocoder(_url, string.Empty, _token));

        [TestMethod]
        public void PtvApi_Constructor_InvalidParameter_Token_ThrowsArgumentNullException()
            => Assert.ThrowsException<ArgumentNullException>(() => new PtvGeocoder(_url, _user, string.Empty));

        [TestMethod]
        public async Task PtvApi_GetAddress_CountryInISO2_ShouldReturnCorrectCoordinates()
        {
            PtvGeocoder api = new PtvGeocoder(_url, _user, _token);
            GeoCoordinate? address = await api.GeocodeAsync("Katwilgweg", "2", "2050", "Antwerpen", "", "BE");

            AssertCoordinates(address.GetValueOrDefault(), 4.359231, 51.219501);
        }

        [TestMethod]
        public async Task PtvApi_GetAddress_CountryInISO3_ShouldReturnCorrectCoordinates()
        {
            PtvGeocoder api = new PtvGeocoder(_url, _user, _token);
            GeoCoordinate? address = await api.GeocodeAsync("Katwilgweg", "2", "2050", "Antwerpen", "", "BEL");

            AssertCoordinates(address.GetValueOrDefault(), 4.359231, 51.219501);
        }

        [TestMethod]
        public async Task PtvApi_GetAddress_CountryInEnglish_ShouldReturnCorrectCoordinates()
        {
            PtvGeocoder api = new PtvGeocoder(_url, _user, _token);
            GeoCoordinate? address = await api.GeocodeAsync("Katwilgweg", "2", "2050", "Antwerpen", "", "Belgium");

            AssertCoordinates(address.GetValueOrDefault(), 4.359231, 51.219501);
        }

        [DataTestMethod]
        [DataRow("Katwilgweg 2, 2050 Antwerpen", "BE", 4.359231, 51.219501)]
        [TestCategory("Map")]
        public async Task PtvApi_GetAddressByText_CountryInISO2_ShouldReturnCorrectCoordinates(string street, string country, double x, double y)
        {
            PtvGeocoder api = new PtvGeocoder(_url, _user, _token);
            GeoCoordinate? address = await api.GeocodeAsync(street, country);

            AssertCoordinates(address.GetValueOrDefault(), x, y);
        }

        [DataTestMethod]
        [DataRow("Katwilgweg 2, 2050 Antwerpen", "BEL", 4.359231, 51.219501)]
        [TestCategory("Map")]
        public async Task PtvApi_GetAddressByText_AllAccurateParameters_ISO3_ShouldReturnCorrectCoordinates(string street, string country, double x, double y)
        {
            PtvGeocoder api = new PtvGeocoder(_url, _user, _token);
            GeoCoordinate? address = await api.GeocodeAsync(street, country);

            AssertCoordinates(address.GetValueOrDefault(), x, y);
        }

        [DataTestMethod]
        [DataRow("Katwilgweg 2, 2050 Antwerpen", "Belgium", 4.359231, 51.219501)]
        [DataRow("192 Market Square, , B27 4KT, Birmingham", "GB", -1.82313, 52.45387)]
        [TestCategory("Map")]
        public async Task PtvApi_GetAddressByText_CountryInEnglish_ShouldReturnCorrectCoordinates(string street, string country, double x, double y)
        {
            PtvGeocoder api = new PtvGeocoder(_url, _user, _token);
            GeoCoordinate? address = await api.GeocodeAsync(street, country);

            AssertCoordinates(address.GetValueOrDefault(), x, y);
        }

        [DataTestMethod]
        [DataRow("Maschstraße - K36, P. Nr. 1718067, 32120, Hiddenhausen", "DE", 8.616735, 52.171363)]
        [DataRow("1 Avenue du Château, 62124, Vélu", "FR", 2.972791, 50.104375)]
        [DataRow("62124, Vélu, 1 Avenue du Château", "FR", 2.972791, 50.104375)]
        [DataRow("62124, 1 Avenue du Château, Vélu", "FR", 2.972791, 50.104375)]
        [DataRow("1 Avenue du Château, Vélu, 62124", "FR", 2.972791, 50.104375)]
        [TestCategory("Map")]
        public async Task PtvApi_GetAddressByText_ShouldReturnCorrectCoordinates(string address, string country, double x, double y)
        {
            PtvGeocoder api = new PtvGeocoder(_url, _user, _token);
            GeoCoordinate? result = await api.GeocodeAsync(address, country);

            AssertCoordinates(result.GetValueOrDefault(), x, y);
        }

        private void AssertCoordinates(GeoCoordinate address, double x, double y)
            => Assert.IsTrue(GetDistance(address.Longitude, address.Latitude, x, y) <= 1);

        private double GetDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const int radius = 6371; // Radius of the earth in km
            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);
            double a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = radius * c;  // Distance in km
            return d;
        }

        private double ToRadians(double deg) => deg * (Math.PI / 180);
    }
}