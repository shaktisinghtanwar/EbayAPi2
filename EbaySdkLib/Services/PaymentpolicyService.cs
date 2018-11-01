using EbaySdkLib.Constants;
using EbaySdkLib.Messages;
using EbaySdkLib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Services
    {
    public class PaymentpolicyService
        {
        private string Token;

        public PaymentpolicyService()
            {

            }

        public PaymentpolicyService(string Token)
            {
        // TODO: Complete member initialization
        this.Token = Token;
            }

        public async Task<Tuple<GetPaymentpolicyresponse,HttpStatusCode>> getPaymentpolicyService(string policyId)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.PaymentPolicy_Url + policyId);
            var response = await helper.Get(Token);
            GetPaymentpolicyresponse getPaymentpolicyResponse = JsonConvert.DeserializeObject<GetPaymentpolicyresponse>(response.Item1);
                        return new Tuple<GetPaymentpolicyresponse, HttpStatusCode>(getPaymentpolicyResponse, response.Item2); 
            }

        public async Task<Tuple<GetPaymentpoliciesResponse,HttpStatusCode>> getPaymentpoliciesService(string marketplaceId)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.PaymentPolicy_Url+"?marketplace_id=" + marketplaceId );
            var response = await helper.Get(Token).ConfigureAwait(false);
            GetPaymentpoliciesResponse getPaymentpoliciesResponse = JsonConvert.DeserializeObject<GetPaymentpoliciesResponse>(response.Item1);
                        return new Tuple<GetPaymentpoliciesResponse, HttpStatusCode>(getPaymentpoliciesResponse, response.Item2); 
            }

        public async Task<Tuple<GetPaymentpolicyByNameresponse,HttpStatusCode>> getPaymentPolicyByNameService(string name, string marketplaceId)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.PaymentPolicy_Url + "get_by_policy_name?name=" + name + "&marketplace_id=" + marketplaceId);
            var response = await helper.Get(Token);
            GetPaymentpolicyByNameresponse getPaymentpolicyByNameresponse = JsonConvert.DeserializeObject<GetPaymentpolicyByNameresponse>(response.Item1);
                        return new Tuple<GetPaymentpolicyByNameresponse, HttpStatusCode>(getPaymentpolicyByNameresponse, response.Item2);
            }

        public async Task<Tuple<Createpaymentpolicyresponse,HttpStatusCode>> createPaymentPolicyService(CreatePaymerntPolicyRequest createPaymerntPolicyRequest)
            {
            var body = JsonConvert.SerializeObject(createPaymerntPolicyRequest);
            RestHelper helper = new RestHelper(ApplicationConstants.PaymentPolicy_Url);
            var response = await helper.Post(body, Token);
            Createpaymentpolicyresponse createpaymentpolicyresponse = JsonConvert.DeserializeObject<Createpaymentpolicyresponse>(response.Item1);
                        return new Tuple<Createpaymentpolicyresponse, HttpStatusCode>(createpaymentpolicyresponse, response.Item2);
            }


        public async Task<Tuple<updatePaymentPolicyResponse,HttpStatusCode>> updatePaymentPolicyService(updatePaymentPolicyRequest updatePaymentPolicyrequest, string Id)
            {
            var body = JsonConvert.SerializeObject(updatePaymentPolicyrequest);
            RestHelper helper = new RestHelper(ApplicationConstants.PaymentPolicy_Url  + Id );
            var response = await helper.Put(body, Token);
            updatePaymentPolicyResponse updatePaymentPolicyresponse = JsonConvert.DeserializeObject<updatePaymentPolicyResponse>(response.Item1);
                        return new Tuple<updatePaymentPolicyResponse, HttpStatusCode>(updatePaymentPolicyresponse, response.Item2); 
            }


        public async Task<Tuple<GetRateTablesResponse,HttpStatusCode>> getratePolicyService(RateTable ratetable)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.RATETABLE_URL + ratetable.countryCode);
            var response = await helper.Get(Token);
            GetRateTablesResponse getRateTablesResponse = JsonConvert.DeserializeObject<GetRateTablesResponse>(response.Item1);
                        return new Tuple<GetRateTablesResponse, HttpStatusCode>(getRateTablesResponse, response.Item2);
            }
        public async Task<Tuple<string,HttpStatusCode>> deletePolicyService(string Id)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.PaymentPolicy_Url + Id );
            var response = await helper.Delete(Id, Token);
            return new Tuple<string, HttpStatusCode>(response.Item1, response.Item2);
            }
        }
    }
