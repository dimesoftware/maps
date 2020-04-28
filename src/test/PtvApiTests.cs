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
        public async Task PtvApi_GetAddress_CountryInISO2_ReturnsCorrectCoordinates()
        {
            PtvGeocoder api = new PtvGeocoder(_url, _user, _token);
            GeoCoordinate? address = await api.GeocodeAsync("Katwilgweg", "2", "2050", "Antwerpen", "", "BE");

            double x = 4.35;
            double y = 51.22;

            //Assert.IsTrue(address.Type == "PlainPoint");
            Assert.IsTrue(address?.Longitude > x * 0.9 && address?.Longitude < x * 1.1);
            Assert.IsTrue(address?.Latitude > y * 0.9 && address?.Latitude < y * 1.1);
        }

        [TestMethod]
        public async Task PtvApi_GetAddress_CountryInISO3_ReturnsCorrectCoordinates()
        {
            PtvGeocoder api = new PtvGeocoder(_url, _user, _token);
            GeoCoordinate? address = await api.GeocodeAsync("Katwilgweg", "2", "2050", "Antwerpen", "", "BEL");

            double x = 4.35;
            double y = 51.22;

            //Assert.IsTrue(address.Type == "PlainPoint");
            Assert.IsTrue(address?.Longitude > x * 0.9 && address?.Longitude < x * 1.1);
            Assert.IsTrue(address?.Latitude > y * 0.9 && address?.Latitude < y * 1.1);
        }

        [TestMethod]
        public async Task PtvApi_GetAddress_CountryInEnglish_ReturnsCorrectCoordinates()
        {
            PtvGeocoder api = new PtvGeocoder(_url, _user, _token);
            GeoCoordinate? address = await api.GeocodeAsync("Katwilgweg", "2", "2050", "Antwerpen", "", "Belgium");

            double x = 4.35;
            double y = 51.22;

            //Assert.IsTrue(address.Type == "PlainPoint");
            Assert.IsTrue(address?.Longitude > x * 0.9 && address?.Longitude < x * 1.1);
            Assert.IsTrue(address?.Latitude > y * 0.9 && address?.Latitude < y * 1.1);
        }

        [DataTestMethod]
        [DataRow("Katwilgweg 2, 2050 Antwerpen", "BE", 4.35, 51.22)]
        [TestCategory("Map")]
        public async Task PtvApi_GetAddressByText_CountryInISO2_ReturnsCorrectCoordinates(string street, string country, double x, double y)
        {
            PtvGeocoder api = new PtvGeocoder(_url, _user, _token);
            GeoCoordinate? address = await api.GeocodeAsync(street, country);

            //Assert.IsTrue(address.Type == "PlainPoint");
            Assert.IsTrue(address?.Longitude > x * 0.9 && address?.Longitude < x * 1.1);
            Assert.IsTrue(address?.Latitude > y * 0.9 && address?.Latitude < y * 1.1);
        }

        [DataTestMethod]
        [DataRow("Katwilgweg 2, 2050 Antwerpen", "BEL", 4.35, 51.22)]
        [TestCategory("Map")]
        public async Task PtvApi_GetAddressByText_AllAccurateParameters_ISO3_ReturnsCorrectCoordinates(string street, string country, double x, double y)
        {
            PtvGeocoder api = new PtvGeocoder(_url, _user, _token);
            GeoCoordinate? address = await api.GeocodeAsync(street, country);

            //Assert.IsTrue(address.Type == "PlainPoint");
            Assert.IsTrue(address?.Longitude > x * 0.9 && address?.Longitude < x * 1.1);
            Assert.IsTrue(address?.Latitude > y * 0.9 && address?.Latitude < y * 1.1);
        }

        [DataTestMethod]
        [DataRow("Katwilgweg 2, 2050 Antwerpen", "Belgium", 4.35, 51.22)]
        [DataRow("192 Market Square, , B27 4KT, Birmingham", "GB", 0, 0)]
        [TestCategory("Map")]
        public async Task PtvApi_GetAddressByText_CountryInEnglish_ReturnsCorrectCoordinates(string street, string country, double x, double y)
        {
            PtvGeocoder api = new PtvGeocoder(_url, _user, _token);
            GeoCoordinate? address = await api.GeocodeAsync(street, country);
        }

        [DataTestMethod]
        [DataRow("Maschstraße - K36, P. Nr. 1718067, 32120, Hiddenhausen", "DE")]
        [TestCategory("Map")]
        public async Task PtvApi_GetAddressByText(string address, string country)
        {
            PtvGeocoder api = new PtvGeocoder(_url, _user, _token);
            GeoCoordinate? result = await api.GeocodeAsync(address, country);
        }
    }
}