using Newtonsoft.Json;
using System.Threading.Tasks;
using EbaySdkLib.Models;

namespace EbaySdkLib
{
    public class GetAccessTokenService
    {
        public GetAccessTokenService()
        {            
        }

        //public async Task<EbayAccessToken> InsertToken(string AuthToken)
        //{
        //    RestHelper helper = new RestHelper("");
        //    var response = await helper.GetToken(AuthToken).ConfigureAwait(false);
        //    return response;
        //}
        public async Task<EbayAccessToken>GetToken(string AuthToken)
        {            
            RestHelper helper = new RestHelper("");
            var response = await helper.GetToken(AuthToken).ConfigureAwait(false);            
            return response;
        }

        public async Task<EbayAccessToken> GetRefreshToken(string ExpiredAccessToken)
        {
            RestHelper helper = new RestHelper("");
            var response = await helper.GetRefreshToken(ExpiredAccessToken).ConfigureAwait(false) ;            
            return response;
        }
    }
}
