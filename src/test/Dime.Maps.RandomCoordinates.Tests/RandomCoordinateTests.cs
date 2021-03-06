using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using RestSharp;
using Xunit;

namespace Dime.Maps.RandomCoordinates.Tests
{
    public class RandomCoordinateTests
    {
        private CoordinateTestSettings TestSettings { get; }

        public RandomCoordinateTests()
        {
            TestSettings = new CoordinateTestSettings();
            InitializeTests();
        }

        private void InitializeTests()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddUserSecrets<CoordinateTestSettings>()
                .Build();

            configuration.GetSection("test").Bind(TestSettings);
        }

        [Theory]
        [InlineData(40.758675, -73.985291, "United States of America")] // Times Square
        [InlineData(-33.858063, 151.214817, "Australia")] // Sydney Opera House
        [InlineData(-33.996379, 18.537121, "South Africa")] // Cape Point
        public void RandomCoordinate_Next_ShouldGenerateValidCoordinate(double lat, double lng, string country)
        {
            Coordinate coordinate = RandomCoordinate.Next(new Coordinate(lat, lng), 1000);

            Assert.True(coordinate.Latitude >= -90 && coordinate.Latitude <= 90);
            Assert.True(coordinate.Longitude >= -180 && coordinate.Longitude <= 180);

            string requestUri = $"https://eu1.locationiq.com/v1/reverse.php" +
                                $"?key={TestSettings.LocationIqKey}" +
                                $"&lat={coordinate.Latitude.ToString(CultureInfo.InvariantCulture)}" +
                                $"&lon={coordinate.Longitude.ToString(CultureInfo.InvariantCulture)}" +
                                $"&format=json";

            RestClient client = new();
            RestRequest request = new(requestUri, DataFormat.Json);

            IRestResponse<GeocodeResponse> response = client.Get<GeocodeResponse>(request);
            GeocodeResponse responseData = response.Data;

            if (responseData.Address != null)
                Assert.True(responseData.Address.Country == country);
        }

        [Theory]
        [InlineData(40.758675, -73.985291, "United States of America")] // Times Square
        [InlineData(-33.858063, 151.214817, "Australia")] // Sydney Opera House
        [InlineData(-33.996379, 18.537121, "South Africa")] // Cape Point
        public void RandomCoordinate_Next_Multi_ShouldGenerateValidCoordinate(double lat, double lng, string country)
        {
            RandomCoordinate randomCoordinate = new();
            IEnumerable<Coordinate> coordinates = RandomCoordinate.Next(new Coordinate(lat, lng), 1000, 5);

            foreach (Coordinate coordinate in coordinates)
            {
                Assert.True(coordinate.Latitude >= -90 && coordinate.Latitude <= 90);
                Assert.True(coordinate.Longitude >= -180 && coordinate.Longitude <= 180);

                string requestUri = $"https://eu1.locationiq.com/v1/reverse.php" +
                                    $"?key={TestSettings.LocationIqKey}" +
                                    $"&lat={coordinate.Latitude.ToString(CultureInfo.InvariantCulture)}" +
                                    $"&lon={coordinate.Longitude.ToString(CultureInfo.InvariantCulture)}" +
                                    $"&format=json";

                RestClient client = new();
                RestRequest request = new(requestUri, DataFormat.Json);

                IRestResponse<GeocodeResponse> response = client.Get<GeocodeResponse>(request);
                GeocodeResponse responseData = response.Data;

                if (responseData.Address != null)
                    Assert.True(responseData.Address.Country == country);
            }
        }
    }
}