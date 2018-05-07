using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dime.Maps.Tests
{
    [TestClass]
    public class PtvApiTests
    {
        private readonly string _token = "980CF3CC-02CC-47CE-BD4E-BC434E92A3F7";
        private readonly string _user = "xtok";
        private readonly string _url = "https://api-eu-test.cloud.ptvgroup.com";

        [TestMethod]
        public void PtvApi_Constructor_InvalidParameter_Url_ThrowsArgumentNullException()
            => Assert.ThrowsException<ArgumentNullException>(() => new PtvApi(string.Empty, _user, _token));

        [TestMethod]
        public void PtvApi_Constructor_InvalidParameter_User_ThrowsArgumentNullException()
            => Assert.ThrowsException<ArgumentNullException>(() => new PtvApi(_url, string.Empty, _token));

        [TestMethod]
        public void PtvApi_Constructor_InvalidParameter_Token_ThrowsArgumentNullException()
            => Assert.ThrowsException<ArgumentNullException>(() => new PtvApi(_url, _user, string.Empty));

        [TestMethod]
        public async Task PtvApi_GetAddress_CountryInISO2_ReturnsCorrectCoordinates()
        {
            PtvApi api = new PtvApi(_url, _user, _token);
            var address = await api.FindAddress("Katwilgweg", "2", "2050", "Antwerpen", "", "BE");

            double x = 4.35;
            double y = 51.22;

            //Assert.IsTrue(address.Type == "PlainPoint");
            Assert.IsTrue(address.X > x * 0.9 && address.X < x * 1.1);
            Assert.IsTrue(address.Y > y * 0.9 && address.Y < y * 1.1);
        }

        [TestMethod]
        public async Task PtvApi_GetAddress_CountryInISO3_ReturnsCorrectCoordinates()
        {
            PtvApi api = new PtvApi(_url, _user, _token);
            var address = await api.FindAddress("Katwilgweg", "2", "2050", "Antwerpen", "", "BEL");

            double x = 4.35;
            double y = 51.22;

            //Assert.IsTrue(address.Type == "PlainPoint");
            Assert.IsTrue(address.X > x * 0.9 && address.X < x * 1.1);
            Assert.IsTrue(address.Y > y * 0.9 && address.Y < y * 1.1);
        }

        [TestMethod]
        public async Task PtvApi_GetAddress_CountryInEnglish_ReturnsCorrectCoordinates()
        {
            PtvApi api = new PtvApi(_url, _user, _token);
            var address = await api.FindAddress("Katwilgweg", "2", "2050", "Antwerpen", "", "Belgium");

            double x = 4.35;
            double y = 51.22;

            //Assert.IsTrue(address.Type == "PlainPoint");
            Assert.IsTrue(address.X > x * 0.9 && address.X < x * 1.1);
            Assert.IsTrue(address.Y > y * 0.9 && address.Y < y * 1.1);
        }

        [DataTestMethod]
        [DataRow("Katwilgweg 2, 2050 Antwerpen", "BE", 4.35, 51.22)]
        [TestCategory("Map")]
        public async Task PtvApi_GetAddressByText_CountryInISO2_ReturnsCorrectCoordinates(string street, string country, double x, double y)
        {
            PtvApi api = new PtvApi(_url, _user, _token);
            Point address = await api.FindAddressByText(street, country);

            Assert.IsTrue(address != null);
            //Assert.IsTrue(address.Type == "PlainPoint");
            Assert.IsTrue(address.X > x * 0.9 && address.X < x * 1.1);
            Assert.IsTrue(address.Y > y * 0.9 && address.Y < y * 1.1);
        }

        [DataTestMethod]
        [DataRow("Katwilgweg 2, 2050 Antwerpen", "BEL", 4.35, 51.22)]
        [TestCategory("Map")]
        public async Task PtvApi_GetAddressByText_AllAccurateParameters_ISO3_ReturnsCorrectCoordinates(string street, string country, double x, double y)
        {
            PtvApi api = new PtvApi(_url, _user, _token);
            Point address = await api.FindAddressByText(street, country);

            Assert.IsTrue(address != null);
            //Assert.IsTrue(address.Type == "PlainPoint");
            Assert.IsTrue(address.X > x * 0.9 && address.X < x * 1.1);
            Assert.IsTrue(address.Y > y * 0.9 && address.Y < y * 1.1);
        }

        [DataTestMethod]
        [DataRow("Katwilgweg 2, 2050 Antwerpen", "België", 4.35, 51.22)]
        [TestCategory("Map")]
        public async Task PtvApi_GetAddressByText_CountryInEnglish_ReturnsCorrectCoordinates(string street, string country, double x, double y)
        {
            PtvApi api = new PtvApi(_url, _user, _token);
            Point address = await api.FindAddressByText(street, country);

            Assert.IsTrue(address == null);
        }
    }
}
