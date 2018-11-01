using EbaySdkLib.Constants;
using EbaySdkLib.Messages;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
namespace EbaySdkLib
{
    public class SalesTaxService
    {
        private string Token;

        public SalesTaxService(string Token)
            {
        // TODO: Complete member initialization
        this.Token = Token;
            }
       
        public async Task<Tuple<CreateOrReplaceSalesTaxResponse,HttpStatusCode>>CreateorReplaceSalesTax(CreateOrReplaceSalesTaxRequest createOrReplaceSalesTaxRequest, string countryCode, string jurisdictionId)
        {
            var body = JsonConvert.SerializeObject(createOrReplaceSalesTaxRequest);

            RestHelper helper = new RestHelper(ApplicationConstants.SALESTAX_URL + countryCode + "/" + jurisdictionId);
            var response = await helper.Put(body, Token);

            CreateOrReplaceSalesTaxResponse createOrReplaceSalesTaxResponse = JsonConvert.DeserializeObject<CreateOrReplaceSalesTaxResponse>(response.Item1);
         return new Tuple<CreateOrReplaceSalesTaxResponse, HttpStatusCode>(createOrReplaceSalesTaxResponse, response.Item2);
        }
        public async Task<Tuple<DeleteSalesTaxResponse,HttpStatusCode>>   DeleteSalesTax(string countryCode,string jurisdictionId )
        {
        RestHelper helper = new RestHelper(ApplicationConstants.SALESTAX_URL + countryCode + "/" + jurisdictionId);
            var response = await helper.Delete(countryCode, Token);
            DeleteSalesTaxResponse deleteSalesTaxResponse = JsonConvert.DeserializeObject<DeleteSalesTaxResponse>(response.Item1);
            return new Tuple<DeleteSalesTaxResponse, HttpStatusCode>(deleteSalesTaxResponse, response.Item2);
        }
        public async Task<Tuple<GetSalesTaxResponse,HttpStatusCode>>GetSalesTax(string countryCode, string jurisdictionId)
        {
        RestHelper helper = new RestHelper(ApplicationConstants.SALESTAX_URL + countryCode + "/" + jurisdictionId);
            var response = await helper.Get(Token);
            GetSalesTaxResponse getSalesTaxResponse = JsonConvert.DeserializeObject<GetSalesTaxResponse>(response.Item1);
            return new Tuple<GetSalesTaxResponse, HttpStatusCode>(getSalesTaxResponse, response.Item2);
        }
        public async Task<Tuple<GetSalesTaxesResponse,HttpStatusCode>>    GetSalesTaxes(string countryCode)
        {
        RestHelper helper = new RestHelper(ApplicationConstants.SALESTAX_URL + "?country_code=" + countryCode);
            var response = await helper.Get(Token);
            GetSalesTaxesResponse getSalesTaxesResponse = JsonConvert.DeserializeObject<GetSalesTaxesResponse> (response.Item1);
         return new Tuple<GetSalesTaxesResponse, HttpStatusCode>(getSalesTaxesResponse, response.Item2);
        }
    }
}
