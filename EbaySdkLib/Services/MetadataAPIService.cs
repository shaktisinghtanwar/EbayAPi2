using EbaySdkLib.Constants;
using EbaySdkLib.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Services
    {
  public  class MetadataAPIService
        {
       public string Token { get; private set; }
       public MetadataAPIService(string token)
            {
        this.Token = Token;
            }

      public async Task<Tuple<GetSalesTaxJurisdictions,HttpStatusCode>> getSalesTaxJurisdictionsService( string countrycode)
      {
      RestHelper helper = new RestHelper(ApplicationConstants.JURISDICTION_URL +countrycode+"/sales_tax_jurisdiction");
      var response = await helper.Get(Token);
      GetSalesTaxJurisdictions getSalesTaxJurisdictions = JsonConvert.DeserializeObject<GetSalesTaxJurisdictions>(response.Item1);
      return new Tuple<GetSalesTaxJurisdictions, HttpStatusCode>(getSalesTaxJurisdictions, response.Item2);
      }
      public async Task<Tuple<GetAutomotivePartsCompatibilityPolicies,HttpStatusCode>> getAutomotivePartsCompatibilityService(string marketPlaceId, string filter)
          {
          RestHelper helper = new RestHelper(ApplicationConstants.JURISDICTION_URL + marketPlaceId + "/get_automotive_parts_compatibility_policies?filter=categoryIds:" + filter);
          var response = await helper.Get(Token);
          GetAutomotivePartsCompatibilityPolicies getAutomotivePartsCompatibilityPolicies = JsonConvert.DeserializeObject<GetAutomotivePartsCompatibilityPolicies>(response.Item1);
          return new Tuple<GetAutomotivePartsCompatibilityPolicies, HttpStatusCode>(getAutomotivePartsCompatibilityPolicies, response.Item2);
          }
      public async Task<Tuple<GetItemConditionPoliciesResponse,HttpStatusCode>> getItemConditionPoliciesService(string marketPlaceId, string filter)
          {
          RestHelper helper = new RestHelper(ApplicationConstants.JURISDICTION_URL + marketPlaceId + "/get_automotive_parts_compatibility_policies?filter=categoryIds:" + filter);
          var response = await helper.Get(Token);
          GetItemConditionPoliciesResponse getItemConditionPoliciesResponse = JsonConvert.DeserializeObject<GetItemConditionPoliciesResponse>(response.Item1);
          return new Tuple<GetItemConditionPoliciesResponse, HttpStatusCode>(getItemConditionPoliciesResponse, response.Item2); 
          }
      public async Task<Tuple<GetListingStructurePoliciesResponse,HttpStatusCode>> GetListingStructurePoliciesService(string marketPlaceId, string filter)
          {
          RestHelper helper = new RestHelper(ApplicationConstants.MARKETPLACE_URL + marketPlaceId + "/get_listing_structure_policies?filter=categoryIds" + filter);
          var response = await helper.Get(Token);
          GetListingStructurePoliciesResponse getListingStructurePoliciesResponse = JsonConvert.DeserializeObject<GetListingStructurePoliciesResponse>(response.Item1);
          return new Tuple<GetListingStructurePoliciesResponse, HttpStatusCode>(getListingStructurePoliciesResponse, response.Item2); 
          }

      public async Task<Tuple<GetNegotiatedPricePoliciesResponse,HttpStatusCode>> getNegotiatedPricePoliciesService(string marketPlaceId, string filter)
          {
          RestHelper helper = new RestHelper(ApplicationConstants.MARKETPLACE_URL + marketPlaceId + "/get_negotiated_price_policies?filter=" + filter);
          var response = await helper.Get(Token);
          GetNegotiatedPricePoliciesResponse getNegotiatedPricePoliciesResponse = JsonConvert.DeserializeObject<GetNegotiatedPricePoliciesResponse>(response.Item1);
          return new Tuple<GetNegotiatedPricePoliciesResponse, HttpStatusCode>(getNegotiatedPricePoliciesResponse, response.Item2); 
          }
      public async Task<Tuple<GetProductAdoptionPolicies,HttpStatusCode>> getProductAdoptionPoliciesService(string marketPlaceId, string filter)
          {
          RestHelper helper = new RestHelper(ApplicationConstants.MARKETPLACE_URL + marketPlaceId + "get_product_adoption_policies?filter=categoryIds" + filter);
          var response = await helper.Get(Token);
          GetProductAdoptionPolicies getProductAdoptionPolicies = JsonConvert.DeserializeObject<GetProductAdoptionPolicies>(response.Item1);
          return new Tuple<GetProductAdoptionPolicies, HttpStatusCode>(getProductAdoptionPolicies, response.Item2); 
          }
      
      public async Task<Tuple<MetadataGetreturnPolicyresponse,HttpStatusCode>> metadataGetreturnPolicyService(string marketPlaceId, string filter)
          {
          RestHelper helper = new RestHelper(ApplicationConstants.MARKETPLACE_URL + marketPlaceId + "get_return_policies?filter=categoryIds" + filter);
          var response = await helper.Get(Token);
          MetadataGetreturnPolicyresponse metadataGetreturnPolicyresponse = JsonConvert.DeserializeObject<MetadataGetreturnPolicyresponse>(response.Item1);
          return new Tuple<MetadataGetreturnPolicyresponse, HttpStatusCode>(metadataGetreturnPolicyresponse, response.Item2); 
          }

     
        }
    }
