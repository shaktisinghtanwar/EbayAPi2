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
    public class CatalogService
        {
        public string Token { get; private set; }
        public CatalogService(string token)
            {
        this.Token = Token;
            }

        public async Task<Tuple<GetProductResponse, HttpStatusCode>> getProductResponse(string epid)
            {
        RestHelper helper = new RestHelper(Constants.ApplicationConstants.CATALOG_URL + epid);
        var response = await helper.Get(Token);
        GetProductResponse getProductResponse = JsonConvert.DeserializeObject<GetProductResponse>(response.Item1);
        return new Tuple<GetProductResponse, HttpStatusCode>(getProductResponse, response.Item2);
            }

        public async Task<Tuple<ProductSummarySearchResponse, HttpStatusCode>> productSummarySearchResponse(string q)
            {
        RestHelper helper = new RestHelper(Constants.ApplicationConstants.CATALOG_URL + q);
        var response = await helper.Get(Token);
        ProductSummarySearchResponse ProductSummarySearchResponse = JsonConvert.DeserializeObject<ProductSummarySearchResponse>(response.Item1);
        return new Tuple<ProductSummarySearchResponse, HttpStatusCode>(ProductSummarySearchResponse, response.Item2);
            }

        public async Task<Tuple<GetProductMetadataResponse, HttpStatusCode>> getProductMetadataResponse(string epid)
            {
        RestHelper helper = new RestHelper(Constants.ApplicationConstants.PRODUCTMETADATA_URL + " ?epid = " + epid);
        var response = await helper.Get(Token);
        GetProductMetadataResponse getProductMetadataResponse = JsonConvert.DeserializeObject<GetProductMetadataResponse>(response.Item1);
        return new Tuple<GetProductMetadataResponse, HttpStatusCode>(getProductMetadataResponse, response.Item2);
            }

        public async Task<Tuple<GetProductMetadataForCategoriesResponse, HttpStatusCode>> getProductMetadataForCategoriesResponse(string primary_category_id)
            {
        RestHelper helper = new RestHelper(Constants.ApplicationConstants.PRODUCTMETADATAFORCATEGORIES_URL + " ?primary_category_id = " + primary_category_id);
        var response = await helper.Get(Token);
        GetProductMetadataForCategoriesResponse getProductMetadataForCategoriesResponse = JsonConvert.DeserializeObject<GetProductMetadataForCategoriesResponse>(response.Item1);
        return new Tuple<GetProductMetadataForCategoriesResponse, HttpStatusCode>(getProductMetadataForCategoriesResponse, response.Item2);
            }

        public async Task<Tuple<GetChangeRequestResponse, HttpStatusCode>> getChangeRequestResponse(string change_request_id)
            {
        RestHelper helper = new RestHelper(Constants.ApplicationConstants.GETCHANGEREQUEST_URL + " ?change_request_id = " + change_request_id);
        var response = await helper.Get(Token);
        GetChangeRequestResponse getChangeRequestResponse = JsonConvert.DeserializeObject<GetChangeRequestResponse>(response.Item1);
        return new Tuple<GetChangeRequestResponse, HttpStatusCode>(getChangeRequestResponse, response.Item2);
            }


        public async Task<Tuple<GetChangeRequestsResponse, HttpStatusCode>> getChangeRequestsResponse()
            {
        RestHelper helper = new RestHelper(Constants.ApplicationConstants.GETCHANGEREQUEST_URL);
        var response = await helper.Get(Token);
        GetChangeRequestsResponse getChangeRequestsResponse = JsonConvert.DeserializeObject<GetChangeRequestsResponse>(response.Item1);
        return new Tuple<GetChangeRequestsResponse, HttpStatusCode>(getChangeRequestsResponse, response.Item2);
            }


        public async Task<Tuple<string, HttpStatusCode>> createChangeRequestService(CreateChangeRequest createChangeRequest)
            {
        var body = JsonConvert.SerializeObject(createChangeRequest);

        RestHelper helper = new RestHelper(ApplicationConstants.GETCHANGEREQUEST_URL);
        var response = await helper.Post(body, Token);

        return new Tuple<string, HttpStatusCode>(response.Item1, response.Item2);
            }
        }
    }
