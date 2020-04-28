using System.Threading.Tasks;

namespace Dime.Maps
{
    /// <summary>
    ///
    /// </summary>
    public interface IGeocoder
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="address"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        Task<GeoCoordinate?> GeocodeAsync(string address, string country);

        /// <summary>
        ///
        /// </summary>
        /// <param name="street"></param>
        /// <param name="streetNo"></param>
        /// <param name="zipCode"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        Task<GeoCoordinate?> GeocodeAsync(string street, string streetNo, string zipCode, string city, string state, string country);
    }
}