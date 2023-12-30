using System.Threading.Tasks;
using Refit;

namespace TurtleRoute
{
    /// <summary>
    /// Defines the api that PTV exposes
    /// </summary>
    internal interface IGeocodingApi
    {
        [Get("/geocoding/v1/locations/by-address")]
        [Headers("cache-control: no-cache")]
        Task<AddressResponse> GetAddress([Query("&")] Address address, [Header("apiKey")] string authorization);

        [Get("/geocoding/v1/locations/by-text")]
        [Headers("cache-control: no-cache")]
        Task<AddressResponse> GetAddressByText([Query("&")] string searchText, [Query("&")] string countryFilter, [Header("apiKey")] string authorization);
    }
}