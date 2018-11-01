using EbaySdkLib.Constants;
using EbaySdkLib.Messages;
using EbaySdkLib.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace EbaySdkLib
{
    public class FulfilmentPolicyService
    {
        private string Token;

        public FulfilmentPolicyService(string Token)
            {
        // TODO: Complete member initialization
        this.Token = Token;
            }


        public async Task<Tuple<CreateFulfillmentResponse,HttpStatusCode>> CreateFulfillmentPolicy(CreateFulfillmentRequest createFulfillmentRequest)
        {
            var body = JsonConvert.SerializeObject(createFulfillmentRequest);

            RestHelper helper = new RestHelper(ApplicationConstants.FULFILMENT_URL);
            var response = await helper.Post( body, Token);

            CreateFulfillmentResponse createFulfillmentResponse = JsonConvert.DeserializeObject<CreateFulfillmentResponse>(response.Item1);
            return new Tuple<CreateFulfillmentResponse, HttpStatusCode>(createFulfillmentResponse, response.Item2);
        }



        public async Task<Tuple<DeleteFulfillmentPolicyResponse, HttpStatusCode>> DeleteFulfillmentPolicy(string fulfillmentPolicyId)
        {
            //  var body = JsonConvert.SerializeObject(fulfillmentPolicyId);

           RestHelper helper = new RestHelper(ApplicationConstants.FULFILMENT_URL + fulfillmentPolicyId);
            var response = await helper.Delete(fulfillmentPolicyId, Token);

            DeleteFulfillmentPolicyResponse deleteFulfillmentPolicyResponse = JsonConvert.DeserializeObject<DeleteFulfillmentPolicyResponse>(response.Item1);
            return new Tuple<DeleteFulfillmentPolicyResponse, HttpStatusCode>(deleteFulfillmentPolicyResponse, response.Item2);

        }



        public async Task<Tuple<GetFulfilmentPoliciesResponse, HttpStatusCode>> GetFulfilmentPolicies(string marketplaceId)
        {
            

            RestHelper helper = new RestHelper(ApplicationConstants.FULFILMENT_URL+"?marketplace_id=" + marketplaceId);
            var response = await helper.Get(Token).ConfigureAwait(false);

            GetFulfilmentPoliciesResponse getFulfillmentResponse = JsonConvert.DeserializeObject<GetFulfilmentPoliciesResponse>(response.Item1);
            return new Tuple<GetFulfilmentPoliciesResponse, HttpStatusCode>(getFulfillmentResponse, response.Item2);

        }



        public async Task<Tuple<GetFulfillmentpolicyByNameResponse, HttpStatusCode>> GetFulfillmentPolicyByName(string name, string marketplaceId)
        {
           // var body = JsonConvert.SerializeObject(name);

            RestHelper helper = new RestHelper(ApplicationConstants.FULFILMENT_URL+"/?name="+name  + "marketplace_id="+  marketplaceId);
            var response = await helper.Get(Token);

            GetFulfillmentpolicyByNameResponse getFulfillmentPolicyByNameResponse = JsonConvert.DeserializeObject<GetFulfillmentpolicyByNameResponse>(response.Item1);
            return new Tuple<GetFulfillmentpolicyByNameResponse, HttpStatusCode>(getFulfillmentPolicyByNameResponse, response.Item2);

        }

        public async Task<Tuple<UpdateFulfillmentPolicyResponse, HttpStatusCode>> UpdateFulfillmentPolicy(string fulfillmentPolicyId)
        {
            
           // var body = JsonConvert.SerializeObject(fulfillmentPolicyId);

            RestHelper helper = new RestHelper(ApplicationConstants.FULFILMENT_URL+"/Fulfillpolicyid=" + fulfillmentPolicyId);
            var response = await helper.Put(fulfillmentPolicyId, Token);

            UpdateFulfillmentPolicyResponse updateFulfillmentPolicyResponse = JsonConvert.DeserializeObject<UpdateFulfillmentPolicyResponse>(response.Item1);
            return new Tuple<UpdateFulfillmentPolicyResponse, HttpStatusCode>(updateFulfillmentPolicyResponse, response.Item2);

        }

        public async Task<Tuple<GetFulfillmentPolicyResponse, HttpStatusCode>> GetFulfillmentPolicy(string fulfillmentPolicyId)
        {

            RestHelper helper = new RestHelper(ApplicationConstants.FULFILMENT_URL+"/Fulfillpolicyid=" + fulfillmentPolicyId);
            var response = await helper.Get(Token);

            GetFulfillmentPolicyResponse getFulfillmentPolicyResponse = JsonConvert.DeserializeObject<GetFulfillmentPolicyResponse>(response.Item1);
            return new Tuple<GetFulfillmentPolicyResponse, HttpStatusCode>(getFulfillmentPolicyResponse, response.Item2);

        }

    }
}
