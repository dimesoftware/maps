using System.Threading.Tasks;

namespace Dime.Maps
{
    public interface IGeocoder
    {
        Task<GeoCoordinate?> GeocodeAsync(string address, string country);
        Task<GeoCoordinate?> GeocodeAsync(string street, string streetNo, string zipCode, string city, string state, string country);
    }
}