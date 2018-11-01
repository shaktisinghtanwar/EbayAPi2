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
  public  class ReturnPolicyService
        {
      private string Token;

      public ReturnPolicyService()
           {

           }

      public ReturnPolicyService(string Token)
          {
      // TODO: Complete member initialization
      this.Token = Token;
          }

      public async Task<Tuple<GetReturnPolicyResponse,HttpStatusCode>>   getReturnPolicy(string return_policy_id)
           {
           RestHelper helper = new RestHelper(ApplicationConstants.RATETABLE_URL + return_policy_id);
           var response = await helper.Get(Token);
           GetReturnPolicyResponse getReturnPolicyResponse = JsonConvert.DeserializeObject<GetReturnPolicyResponse>(response.Item1);
         return new Tuple<GetReturnPolicyResponse, HttpStatusCode>(getReturnPolicyResponse, response.Item2);
           }

      public async Task<Tuple<GetReturnPoliciesResponse,HttpStatusCode>>   getReturnPolicies(string marketplaceId)
          {
          RestHelper helper = new RestHelper(ApplicationConstants.RETURNPOLICY_URL + "?marketplace_id= " + marketplaceId );
          var response = await helper.Get(Token);
          GetReturnPoliciesResponse getReturnPoliciesResponse = JsonConvert.DeserializeObject<GetReturnPoliciesResponse>(response.Item1);
         return new Tuple<GetReturnPoliciesResponse, HttpStatusCode>(getReturnPoliciesResponse, response.Item2);
          }

      public async Task<Tuple<GetReturnPolicyByNameResponse,HttpStatusCode>>   getReturnPoliciesByName(string marketplaceId,string name  )
          {
          RestHelper helper = new RestHelper(ApplicationConstants.PaymentPolicy_Url + "get_by_policy_name?marketplace_id=" + marketplaceId + "&name=" +name);
          var response = await helper.Get(Token);
          GetReturnPolicyByNameResponse getReturnPolicyByNameResponse = JsonConvert.DeserializeObject<GetReturnPolicyByNameResponse>(response.Item1);
         return new Tuple<GetReturnPolicyByNameResponse, HttpStatusCode>(getReturnPolicyByNameResponse, response.Item2);
          }

      public async Task<Tuple<CreateReturnPolicyResponse,HttpStatusCode>>   createReturnPolicyService(CreateReturnPolicyrequest createReturnPolicyrequest)
          {
          var body = JsonConvert.SerializeObject(createReturnPolicyrequest);
          RestHelper helper = new RestHelper(ApplicationConstants.RETURNPOLICY_URL);
          var response = await helper.Post(body, Token);
          CreateReturnPolicyResponse createReturnpolicyResponse = JsonConvert.DeserializeObject<CreateReturnPolicyResponse>(response.Item1);
         return new Tuple<CreateReturnPolicyResponse, HttpStatusCode>(createReturnpolicyResponse, response.Item2);
          }

      public async Task<Tuple<string,HttpStatusCode>> deleteReturnPolicyService(string Id)
          {
          RestHelper helper = new RestHelper(ApplicationConstants.RETURNPOLICY_URL+Id);
          var response = await helper.Delete(Id, Token);
         return new Tuple<string, HttpStatusCode>(response.Item1, response.Item2);
          }

      public async Task<Tuple<UpdatereturnPolicyresponse, HttpStatusCode>> updateReturnPolicyService(UpdateReturnPolicyRequest updateReturnPolicyRequest, string Id)
          {
          var body = JsonConvert.SerializeObject(updateReturnPolicyRequest);
          RestHelper helper = new RestHelper(ApplicationConstants.RETURNPOLICY_URL +  Id );
          var response = await helper.Put(body, Token);
          UpdatereturnPolicyresponse updatereturnPolicyresponse = JsonConvert.DeserializeObject<UpdatereturnPolicyresponse>(response.Item1);
          return new Tuple<UpdatereturnPolicyresponse, HttpStatusCode>(updatereturnPolicyresponse, response.Item2);
          }

        }
    }
