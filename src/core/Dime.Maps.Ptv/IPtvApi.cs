using System.Threading.Tasks;
using Refit;

namespace Dime.Maps
{
    /// <summary>
    /// Defines the api that PTV exposes
    /// </summary>
    internal interface IPtvApi
    {
        [Post("/xlocate/rs/XLocate/findAddress")]
        [Headers("cache-control: no-cache, content-type: application/json")]
        Task<AddressReponse> GetAddress([Body]AddressRequest address, [Header("authorization")] string authorization);

        [Post("/xlocate/rs/XLocate/findAddressByText")]
        [Headers("cache-control: no-cache, content-type: application/json")]
        Task<AddressReponse> GetAddressByText([Body]AddressByTextRequest address, [Header("authorization")] string authorization);
    }
}