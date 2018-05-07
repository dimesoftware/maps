using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;

namespace Dime.Maps
{
    public class PtvApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PtvApi"/> class
        /// </summary>
        /// <param name="url">The base url</param>
        /// <param name="user">The user</param>
        /// <param name="token">The token</param>
        public PtvApi(string url, string user, string token)
        {
            if(string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            if (string.IsNullOrEmpty(user))
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException(nameof(token));

         
            Uri = url;
            AuthorizationCode = $"{user}:{token}".Base64Encode();
        }

        #region Properties

        private string Uri { get; }
        private string AuthorizationCode { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Finds the address using the fragmented fields
        /// </summary>
        /// <param name="street">The street</param>
        /// <param name="streetNo">The street number</param>
        /// <param name="zipCode">The zip code</param>
        /// <param name="city">The city</param>
        /// <param name="state">The state</param>
        /// <param name="country">The country</param>
        /// <returns>The coordinates of the requested address</returns>
        public async Task<Point> FindAddress(string street, string streetNo, string zipCode, string city, string state, string country)
        {
            AddressRequest addressRequest = new AddressRequest
            {
                Address = new Address(street, streetNo, zipCode, city, state, country),
                CallerContext = CallerContext.Default(),
                Options = GetCountryCode(country).ToArray()
            };

            IPtvApi ptvApi = RestService.For<IPtvApi>(Uri, new RefitSettings { });
            AddressReponse resp = await ptvApi.GetAddress(addressRequest, "Basic " + AuthorizationCode);
            return resp.GetCoordinates();
        }

        /// <summary>
        /// Finds the address using the full address
        /// </summary>
        /// <param name="address">The full address</param>
        /// <param name="country">The code</param>
        /// <returns>The coordinates of the requested address</returns>
        public async Task<Point> FindAddressByText(string address, string country)
        {
            AddressByTextRequest addressRequest = new AddressByTextRequest(address, country, GetCountryCode(country).ToArray());
            IPtvApi ptvApi = RestService.For<IPtvApi>(Uri, new RefitSettings { });
            AddressReponse resp = await ptvApi.GetAddressByText(addressRequest, "Basic " + AuthorizationCode);
            return resp.GetCoordinates();
        }

        /// <summary>
        /// Inspects the string and determines on the length which country code type to use in the PTV request
        /// </summary>
        /// <param name="country">The country string</param>
        /// <returns>A list of options to instruct PTV to override the default country code types</returns>
        private IEnumerable<PtvRequestOption> GetCountryCode(string country)
        {
            int countryCodeLength = (country ?? string.Empty).Length;
            if (countryCodeLength > 0)
            {
                // Pick ISO2 or ISO3 if they match the length - else use the country name at own risk
                CountryCodeType codeType = countryCodeLength == 2 ? CountryCodeType.Iso2 :
                    countryCodeLength == 3 ? CountryCodeType.Iso3 : CountryCodeType.CountryName;

                yield return new PtvRequestOption("COUNTRY_CODETYPE", ((int)codeType).ToString());
            }
        }

        #endregion Methods
    }
}