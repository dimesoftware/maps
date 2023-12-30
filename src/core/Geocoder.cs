using System;
using System.Linq;
using System.Threading.Tasks;
using Refit;

namespace TurtleRoute
{
    public class Geocoder
    {
        public Geocoder(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException(nameof(token));

            Token = token;
        }

        private string Token { get; }

        public async Task<GeoCoordinate?> GeocodeAsync(string street, string streetNo, string zipCode, string city, string state, string country)
        {
            Address address = new(country, state, zipCode, city, street, streetNo);

            IGeocodingApi ptvApi = RestService.For<IGeocodingApi>("https://api.myptv.com");
            AddressResponse resp = await ptvApi.GetAddress(address, Token);

            if (resp.Locations.Count == 0)
                return null;

            ReferencePosition position = resp.Locations.OrderByDescending(x => x.Quality.TotalScore).FirstOrDefault()?.ReferencePosition;
            return new GeoCoordinate(position.Latitude, position.Longitude);
        }

        public async Task<GeoCoordinate?> GeocodeAsync(string address, string countryFilter)
        {
            IGeocodingApi ptvApi = RestService.For<IGeocodingApi>("https://api.myptv.com");
            AddressResponse resp = await ptvApi.GetAddressByText(address, countryFilter, Token);

            if (resp.Locations.Count == 0)
                return null;

            ReferencePosition position = resp.Locations.OrderByDescending(x => x.Quality.TotalScore).FirstOrDefault()?.ReferencePosition;
            return new GeoCoordinate(position.Latitude, position.Longitude);
        }
    }
}