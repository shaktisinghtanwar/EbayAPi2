using EbaySdkLib.Constants;
using EbaySdkLib.Messages;
using EbaySdkLib.Services;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;


namespace EbaySdkLib.Services
{
   public  class MarketingAPIService
    {
         public string Token { get;private set; }
         public MarketingAPIService(string token)
            {
             this.Token = Token;
          }

      
       
     
    #region lodhisir
        public async Task<Tuple<bulkCreateAdsByInventoryReferenceRequest,HttpStatusCode>> bulkCreateAdsByInventory(bulkCreateAdsByInventoryReferenceRequest bulkCreateAdsByInventory,string campaign_id, string bulk_create_ads)
        {
            var body = JsonConvert.SerializeObject(bulkCreateAdsByInventory);
            RestHelper helper = new RestHelper(ApplicationConstants.BULKCREATEADSBYINVENTORY_URL+ campaign_id+"/"+ bulk_create_ads);
            var response = await helper.Post(body, Token);
            bulkCreateAdsByInventoryReferenceRequest bulkCreateAdsResponse = JsonConvert.DeserializeObject<bulkCreateAdsByInventoryReferenceRequest>(response.Item1);

            return new Tuple<bulkCreateAdsByInventoryReferenceRequest, HttpStatusCode>(bulkCreateAdsResponse, response.Item2);
        }
        public async Task<Tuple<bulkCreateAdsByInventoryReferenceRequest,HttpStatusCode>> bulkCreateAdsByListingId(bulkCreateAdsByInventoryReferenceRequest bulkCreateAdsByInventory,string campaign_id,string bulk_create_ads_by_listing)
        {
            var body = JsonConvert.SerializeObject(bulkCreateAdsByInventory);
            RestHelper helper = new RestHelper(ApplicationConstants.BULKCREATEADSBYINVENTORY_URL + campaign_id+"/"+ bulk_create_ads_by_listing);
            var response = await helper.Post(body, Token);
            bulkCreateAdsByInventoryReferenceRequest bulkCreateAds = JsonConvert.DeserializeObject<bulkCreateAdsByInventoryReferenceRequest>(response.Item1);
            return new Tuple<bulkCreateAdsByInventoryReferenceRequest, HttpStatusCode>(bulkCreateAds, response.Item2);
        }

        
        public async Task<Tuple<bulkCreateAdsByInventoryReferenceRequest,HttpStatusCode>> bulkDeleteAdsByInventoryReference(bulkCreateAdsByInventoryReferenceRequest bulkDeleteAdsByInventory,string campaign_id,string bulk_delete_ads_by_inventory)
        {
            var body = JsonConvert.SerializeObject(bulkDeleteAdsByInventory);
            RestHelper helper = new RestHelper(ApplicationConstants.BULKCREATEADSBYINVENTORY_URL+ campaign_id + "/" + bulk_delete_ads_by_inventory);
            var response = await helper.Post(body, Token);
            bulkCreateAdsByInventoryReferenceRequest bulkDeleteAdsByInventoryResponse = JsonConvert.DeserializeObject<bulkCreateAdsByInventoryReferenceRequest>(response.Item1);
            return new Tuple<bulkCreateAdsByInventoryReferenceRequest, HttpStatusCode>(bulkDeleteAdsByInventoryResponse, response.Item2);
        }
        public async Task<Tuple<bulkCreateAdsByInventoryReferenceRequest,HttpStatusCode>> bulkDeleteAdsByListingId(bulkCreateAdsByInventoryReferenceRequest bulkDeleteAdsByListingId,string campaign_id,string bulkDeleteAdsByListing)
        {
            var body = JsonConvert.SerializeObject(bulkDeleteAdsByListingId);
            RestHelper helper = new RestHelper(ApplicationConstants.BULKCREATEADSBYINVENTORY_URL + campaign_id + "/" + bulkDeleteAdsByListing);
            var response = await helper.Post(body, Token);
            bulkCreateAdsByInventoryReferenceRequest bulkDeleteAdsByListingIdResponse = JsonConvert.DeserializeObject<bulkCreateAdsByInventoryReferenceRequest>(response.Item1);
            return new Tuple<bulkCreateAdsByInventoryReferenceRequest, HttpStatusCode>(bulkDeleteAdsByListingIdResponse, response.Item2);
        }
        public async Task<Tuple<bulkCreateAdsByInventoryReferenceRequest,HttpStatusCode>>bulkUpdateAdsBidByInventoryReference(bulkCreateAdsByInventoryReferenceRequest bulkUpdateAdsBidByInventory,string campaign_id,string bulk_update_ads)
        {
            var body = JsonConvert.SerializeObject(bulkUpdateAdsBidByInventory);
            RestHelper helper = new RestHelper(ApplicationConstants.BULKCREATEADSBYINVENTORY_URL + campaign_id + "/" + bulk_update_ads);
            var response = await helper.Post(body, Token);
            bulkCreateAdsByInventoryReferenceRequest bulkUpdateAdsBidByInventoryResponse = JsonConvert.DeserializeObject<bulkCreateAdsByInventoryReferenceRequest>(response.Item1);
            return new Tuple<bulkCreateAdsByInventoryReferenceRequest, HttpStatusCode>(bulkUpdateAdsBidByInventoryResponse, response.Item2);
        }
        public async Task<Tuple<bulkCreateAdsByInventoryReferenceRequest,HttpStatusCode>> bulkUpdateAdsBidByListingId(bulkCreateAdsByInventoryReferenceRequest bulkUpdateAdsBidByListingId,string campaign_id, string bulk_update_ads_by_listing)
        {
            var body = JsonConvert.SerializeObject(bulkUpdateAdsBidByListingId);
            RestHelper helper = new RestHelper(ApplicationConstants.BULKCREATEADSBYINVENTORY_URL + campaign_id + "/" + bulk_update_ads_by_listing);
            var response = await helper.Post(body, Token);
            bulkCreateAdsByInventoryReferenceRequest bulkUpdateAdsBidByListingResponse = JsonConvert.DeserializeObject<bulkCreateAdsByInventoryReferenceRequest>(response.Item1);
            return new Tuple<bulkCreateAdsByInventoryReferenceRequest, HttpStatusCode>(bulkUpdateAdsBidByListingResponse, response.Item2);
        }
        public async Task<Tuple<bulkCreateAdsByInventoryReferenceRequest,HttpStatusCode>> createAdByListingId(bulkCreateAdsByInventoryReferenceRequest createAdByListingId,string campaign_id,string createAd)
        {
            var body = JsonConvert.SerializeObject(createAdByListingId);
            RestHelper helper = new RestHelper(ApplicationConstants.BULKCREATEADSBYINVENTORY_URL + campaign_id + "/" + createAd);
            var response = await helper.Post(body, Token);
            bulkCreateAdsByInventoryReferenceRequest createAdByListingResponse = JsonConvert.DeserializeObject<bulkCreateAdsByInventoryReferenceRequest>(response.Item1);
            return new Tuple<bulkCreateAdsByInventoryReferenceRequest, HttpStatusCode>(createAdByListingResponse, response.Item2);
        }
        public async Task<Tuple<bulkCreateAdsByInventoryReferenceRequest,HttpStatusCode>> createAdsByInventoryReference(bulkCreateAdsByInventoryReferenceRequest createAdsByInventoryReference,string campaign_id, string create_ads_by_inventory)
        {
            var body = JsonConvert.SerializeObject(createAdsByInventoryReference);
            RestHelper helper = new RestHelper(ApplicationConstants.BULKCREATEADSBYINVENTORY_URL + campaign_id + "/" + create_ads_by_inventory);
            var response = await helper.Post(body, Token);
            bulkCreateAdsByInventoryReferenceRequest createAdsByInventoryReferenceResponse = JsonConvert.DeserializeObject<bulkCreateAdsByInventoryReferenceRequest>(response.Item1);
            return new Tuple<bulkCreateAdsByInventoryReferenceRequest, HttpStatusCode>(createAdsByInventoryReferenceResponse, response.Item2);
        }

        public async Task<Tuple<bulkCreateAdsByInventoryReferenceRequest,HttpStatusCode>> deleteAd(bulkCreateAdsByInventoryReferenceRequest deleteAd,string campaign_id,string deletead,string addid)
        {
            var body = JsonConvert.SerializeObject(deleteAd);
            RestHelper helper = new RestHelper(ApplicationConstants.BULKCREATEADSBYINVENTORY_URL + campaign_id + "/" + deletead+"/"+ addid);
            var response = await helper.Delete(body, Token);
            bulkCreateAdsByInventoryReferenceRequest deleteAdResponse = JsonConvert.DeserializeObject<bulkCreateAdsByInventoryReferenceRequest>(response.Item1);
            return new Tuple<bulkCreateAdsByInventoryReferenceRequest, HttpStatusCode>(deleteAdResponse, response.Item2);
        }
        public async Task<Tuple<bulkCreateAdsByInventoryReferenceRequest,HttpStatusCode>> deleteAdsByInventoryReference(bulkCreateAdsByInventoryReferenceRequest deleteAdsByInventoryReference, string campaign_id,string delete_ads)
        {
            var body = JsonConvert.SerializeObject(deleteAdsByInventoryReference);
            RestHelper helper = new RestHelper(ApplicationConstants.BULKCREATEADSBYINVENTORY_URL + campaign_id + "/" + delete_ads);
            var response = await helper.Post(body, Token);
            bulkCreateAdsByInventoryReferenceRequest deleteAdsByInventoryReferenceResponse = JsonConvert.DeserializeObject<bulkCreateAdsByInventoryReferenceRequest>(response.Item1);
            return new Tuple<bulkCreateAdsByInventoryReferenceRequest, HttpStatusCode>(deleteAdsByInventoryReferenceResponse, response.Item2);
        }
        public async Task<Tuple<bulkCreateAdsByInventoryReferenceRequest,HttpStatusCode>> getAd(bulkCreateAdsByInventoryReferenceRequest getAd,string campaign_id,string ad ,string adId)
        {
           // var body = JsonConvert.SerializeObject(getAd);
            RestHelper helper = new RestHelper(ApplicationConstants.BULKCREATEADSBYINVENTORY_URL + campaign_id + "/" + ad+"/"+ adId);
            var response = await helper.Get(Token);
            bulkCreateAdsByInventoryReferenceRequest getAdResponse = JsonConvert.DeserializeObject<bulkCreateAdsByInventoryReferenceRequest>(response.Item1);
            return new Tuple<bulkCreateAdsByInventoryReferenceRequest, HttpStatusCode>(getAdResponse, response.Item2);
        }
        public async Task<Tuple<GetAdsResponse,HttpStatusCode>> getAds(string campaign_id,string ad)
        {
            // var body = JsonConvert.SerializeObject(getAd);
            RestHelper helper = new RestHelper(ApplicationConstants.BULKCREATEADSBYINVENTORY_URL + campaign_id + "/" + ad );
            var response = await helper.Get(Token);
            GetAdsResponse getAdsResponse = JsonConvert.DeserializeObject<GetAdsResponse>(response.Item1);
            return new Tuple<GetAdsResponse, HttpStatusCode>(getAdsResponse, response.Item2);
        }
        public async Task<Tuple<bulkCreateAdsByInventoryReferenceRequest,HttpStatusCode>> getAdsByInventoryReference(bulkCreateAdsByInventoryReferenceRequest getAdsByInventoryReference,string campaign_id,string getads)
        {     
            RestHelper helper = new RestHelper(ApplicationConstants.BULKCREATEADSBYINVENTORY_URL + campaign_id + "/" + getads + "inventory_reference_id=" + getAdsByInventoryReference.inventoryReferenceId + "&inventory_reference_type=" + getAdsByInventoryReference.inventoryReferenceType);
            var response = await helper.Get(Token);
            bulkCreateAdsByInventoryReferenceRequest getAdsByInventoryReferenceResponse = JsonConvert.DeserializeObject<bulkCreateAdsByInventoryReferenceRequest>(response.Item1);
            return new Tuple<bulkCreateAdsByInventoryReferenceRequest, HttpStatusCode>(getAdsByInventoryReferenceResponse, response.Item2);
        }
        public async Task<Tuple<bulkCreateAdsByInventoryReferenceRequest,HttpStatusCode>> updateBid(bulkCreateAdsByInventoryReferenceRequest updateBid,string campaign_id,string updatead,string adId,string update_bid)
        {
            var body = JsonConvert.SerializeObject(updateBid);
            RestHelper helper = new RestHelper(ApplicationConstants.BULKCREATEADSBYINVENTORY_URL + campaign_id + "/" + updatead +"/"+ adId+"/"+ update_bid);
            var response = await helper.Post(body, Token);
            bulkCreateAdsByInventoryReferenceRequest updateBidResponse = JsonConvert.DeserializeObject<bulkCreateAdsByInventoryReferenceRequest>(response.Item1);
            return new Tuple<bulkCreateAdsByInventoryReferenceRequest, HttpStatusCode>(updateBidResponse, response.Item2);
        }
        public async Task<Tuple<string,HttpStatusCode>> getReport(string reportid)
        {      
            RestHelper helper = new RestHelper(ApplicationConstants.GETREPORT_URL + reportid);
            var response = await helper.Get(Token);
            var getReportResponse = JsonConvert.DeserializeObject<string>(response.Item1);
                       return new Tuple<string, HttpStatusCode>(response.Item1, response.Item2);
        }
        public async Task<Tuple<GetReportMetadataResponse,HttpStatusCode>> getReportMetadata() 
        {
            RestHelper helper = new RestHelper(ApplicationConstants.GETREPORTMETADATA_URL);
            var response = await helper.Get(Token);
            GetReportMetadataResponse getReportMetadataResponse = JsonConvert.DeserializeObject<GetReportMetadataResponse>(response.Item1);
            return new Tuple<GetReportMetadataResponse, HttpStatusCode>(getReportMetadataResponse, response.Item2);
        }
        public async Task<Tuple<GetReportMetadataResponse,HttpStatusCode>> getReportMetadataForReportType(GetReportMetadataResponse reportmetadata) 
        {
            RestHelper helper = new RestHelper(ApplicationConstants.GETREPORTMETADATA_URL+ reportmetadata);
            var response = await helper.Get(Token);
            GetReportMetadataResponse getReportMetadataResponse = JsonConvert.DeserializeObject<GetReportMetadataResponse>(response.Item1);
            return new Tuple<GetReportMetadataResponse, HttpStatusCode>(getReportMetadataResponse, response.Item2);
        }
        public async Task<Tuple<CreateReportTaskRequest,HttpStatusCode>> createReportTask(CreateReportTaskRequest createReportTask) 
        {
            var body = JsonConvert.SerializeObject(createReportTask);
            RestHelper helper = new RestHelper(ApplicationConstants.ADDREPORTTASK_URL);
            var response = await helper.Post(body, Token);
            CreateReportTaskRequest createReportTaskResponse = JsonConvert.DeserializeObject<CreateReportTaskRequest>(response.Item1);
            return new Tuple<CreateReportTaskRequest, HttpStatusCode>(createReportTaskResponse, response.Item2);
        }
        public async Task<Tuple<CreateReportTaskRequest,HttpStatusCode>> deleteReportTask(string reportTaskId)
        {
            var body = JsonConvert.SerializeObject(reportTaskId);
            RestHelper helper = new RestHelper(ApplicationConstants.ADDREPORTTASK_URL+"/" + reportTaskId);
            var response = await helper.Delete(body, Token);
            CreateReportTaskRequest deleteReportTaskResponse = JsonConvert.DeserializeObject<CreateReportTaskRequest>(response.Item1);
            return new Tuple<CreateReportTaskRequest, HttpStatusCode>(deleteReportTaskResponse, response.Item2);
        }
        public async Task<Tuple<CreateReportTaskRequest,HttpStatusCode>> getReportTask(string reportTaskId) 
        {
            RestHelper helper = new RestHelper(ApplicationConstants.ADDREPORTTASK_URL +"/"+ reportTaskId);
            var response = await helper.Get(Token);
            CreateReportTaskRequest getReportTaskResponse = JsonConvert.DeserializeObject<CreateReportTaskRequest>(response.Item1);
            return new Tuple<CreateReportTaskRequest, HttpStatusCode>(getReportTaskResponse, response.Item2);
        }
        public async Task<Tuple<CreateReportTaskRequest,HttpStatusCode>> getReportTasks(string reportTaskstatus,string limit )
        {
            RestHelper helper = new RestHelper(ApplicationConstants.ADDREPORTTASK_URL + "?report_task_statuses="+ reportTaskstatus + "&limit=" + limit);
            var response = await helper.Get(Token);
            CreateReportTaskRequest getReportTasksResponse = JsonConvert.DeserializeObject<CreateReportTaskRequest>(response.Item1);
            if (getReportTasksResponse != null)
            {
                
            }
            return new Tuple<CreateReportTaskRequest, HttpStatusCode>(getReportTasksResponse, response.Item2); 
        }

    #endregion
        public async Task<Tuple<string,HttpStatusCode>> CloneMarketing(CloneCampaignRequest cloneCampaignRequest, string campaign_id)
            {
            var body = JsonConvert.SerializeObject(cloneCampaignRequest);
            RestHelper helper = new RestHelper(ApplicationConstants._URLCOMPAIGN + campaign_id + "/" + "clone");
            var response = await helper.Post(body, Token);    // response is not match with ebay response

                       return new Tuple<string, HttpStatusCode>(response.Item1, response.Item2);
            }
        public async Task<Tuple<string,HttpStatusCode>> CreateMarketing(CreateCampaignRequest createCampaignRequest)
            {
            var body = JsonConvert.SerializeObject(createCampaignRequest);
            RestHelper helper = new RestHelper(ApplicationConstants._URLCOMPAIGN);
            var response = await helper.Post(body, Token);

                       return new Tuple<string, HttpStatusCode>(response.Item1, response.Item2);
            }
        public async Task<Tuple<string,HttpStatusCode>> DeleteMarketing(string campaign_id)
            {
            RestHelper helper = new RestHelper(ApplicationConstants._URLCOMPAIGN + campaign_id);
            var response = await helper.Delete(campaign_id, Token);
                       return new Tuple<string, HttpStatusCode>(response.Item1, response.Item2);
            }
        public async Task<Tuple<EndCampaignResponse,HttpStatusCode>> EndCampaign(string campaign_id)
            {

            RestHelper helper = new RestHelper(ApplicationConstants._URLCOMPAIGN + campaign_id + "/" + "end");
            var response = await helper.Post(campaign_id, Token);
            EndCampaignResponse endCampaignResponse = JsonConvert.DeserializeObject<EndCampaignResponse>(response.Item1);
            return new Tuple<EndCampaignResponse, HttpStatusCode>(endCampaignResponse, response.Item2);
            }
        public async Task<Tuple<GetCampaignResponse,HttpStatusCode>> GetCampaign(string campaign_id)
            {

            RestHelper helper = new RestHelper(ApplicationConstants._URLCOMPAIGN + campaign_id);
            var response = await helper.Get(Token);
            GetCampaignResponse getCampaignResponse = JsonConvert.DeserializeObject<GetCampaignResponse>(response.Item1);
            return new Tuple<GetCampaignResponse, HttpStatusCode>(getCampaignResponse, response.Item2);
            }
        public async Task<Tuple<GetCampaignByNameResponse,HttpStatusCode>> GetCampaignByNameRequest(string campaignName)
            {

            RestHelper helper = new RestHelper(ApplicationConstants._URLCOMPAIGN + "get_campaign_by_name" + "?campaign_name=" + campaignName);
            var response = await helper.Get(Token);
            GetCampaignByNameResponse getCampaignByNameResponse = JsonConvert.DeserializeObject<GetCampaignByNameResponse>(response.Item1);
            return new Tuple<GetCampaignByNameResponse, HttpStatusCode>(getCampaignByNameResponse, response.Item2);
            }
        public async Task<Tuple<GetCampaignsResponse,HttpStatusCode>> GetCampaigns(string campaignName, string campaignStatus, string startDate, string endDate, string limit, string offset)
            {

            RestHelper helper = new RestHelper(ApplicationConstants._URLCOMPAIGN + "?campaign_status=" + campaignStatus + "&start_date_range=" + startDate + "&end_date_range=" + endDate + "&campaign_name=" + campaignName + "&limit=" + limit + "&offset=" + offset);
            var response = await helper.Get(Token);
            GetCampaignsResponse getCampaignsResponse = JsonConvert.DeserializeObject<GetCampaignsResponse>(response.Item1);
            return new Tuple<GetCampaignsResponse, HttpStatusCode>(getCampaignsResponse, response.Item2);
            }
        public async Task<Tuple<PauseCampaignResponse,HttpStatusCode>> PauseCampaign(string campaign_id)
            {
            //without request payload how can  i send a body within a post method
            var body = JsonConvert.SerializeObject(campaign_id);
            RestHelper helper = new RestHelper(ApplicationConstants._URLCOMPAIGN + campaign_id + "/" + "pause");
            var response = await helper.Post(body, Token);
            PauseCampaignResponse pauseCampaignResponse = JsonConvert.DeserializeObject<PauseCampaignResponse>(response.Item1);
            return new Tuple<PauseCampaignResponse, HttpStatusCode>(pauseCampaignResponse, response.Item2);
            }
        public async Task<Tuple<ResumeCampaignResponse,HttpStatusCode>> ResumeCampaign(string campaign_id)
            {   //without request payload how can  i send a body within a post method
            var body = JsonConvert.SerializeObject(campaign_id);
            RestHelper helper = new RestHelper(ApplicationConstants._URLCOMPAIGN + campaign_id + "/" + "resume");
            var response = await helper.Post(body, Token);
            ResumeCampaignResponse resumeCampaignResponse = JsonConvert.DeserializeObject<ResumeCampaignResponse>(response.Item1);
            return new Tuple<ResumeCampaignResponse, HttpStatusCode>(resumeCampaignResponse, response.Item2);
            }
        public async Task<Tuple<UpdateCampaignIdentificationResponse,HttpStatusCode>> UpdateCampaignIdentification(UpdateCampaignIdentificationRequest updateCampaignIdentificationRequest, string campaign_id)
            {
            var body = JsonConvert.SerializeObject(updateCampaignIdentificationRequest);
            RestHelper helper = new RestHelper(ApplicationConstants._URLCOMPAIGN + campaign_id + "/" + "update_campaign_identification");
            var response = await helper.Post(body, Token);
            UpdateCampaignIdentificationResponse updateCampaignIdentificationResponse = JsonConvert.DeserializeObject<UpdateCampaignIdentificationResponse>(response.Item1);
            return new Tuple<UpdateCampaignIdentificationResponse, HttpStatusCode>(updateCampaignIdentificationResponse, response.Item2);
            }

        public async Task<Tuple<CreateItemPromotionResponse,HttpStatusCode>> CreateItemPromotion(CreateItemPromotionRequest createItemPromotionRequest)
            {
            var body = JsonConvert.SerializeObject(createItemPromotionRequest);
            RestHelper helper = new RestHelper(ApplicationConstants._URLPROMOTION);
            var response = await helper.Post(body, Token);
            CreateItemPromotionResponse createItemPromotionResponse = JsonConvert.DeserializeObject<CreateItemPromotionResponse>(response.Item1);
            return new Tuple<CreateItemPromotionResponse, HttpStatusCode>(createItemPromotionResponse, response.Item2);
            }
        public async Task<Tuple<string,HttpStatusCode>> DeleteItemPromotion(string campaign_id)
            {
            RestHelper helper = new RestHelper(ApplicationConstants._URLPROMOTION + campaign_id);
            var response = await helper.Delete(campaign_id, Token);
                       return new Tuple<string, HttpStatusCode>(response.Item1, response.Item2);
            }
        public async Task<Tuple<GetItemPromotionResponse,HttpStatusCode>> GetItemPromotion(string campaign_id)
            {

            RestHelper helper = new RestHelper(ApplicationConstants._URLPROMOTION + campaign_id);
            var response = await helper.Get(Token);
            GetItemPromotionResponse getItemPromotionResponse = JsonConvert.DeserializeObject<GetItemPromotionResponse>(response.Item1);
            return new Tuple<GetItemPromotionResponse, HttpStatusCode>(getItemPromotionResponse, response.Item2);
            }
        public async Task<Tuple<UpdateItemPromotionResponse,HttpStatusCode>> UpdateItemPromotion(UpdateItemPromotionRequest updateItemPromotionRequest, string campaign_id)
            {
            var body = JsonConvert.SerializeObject(updateItemPromotionRequest);
            RestHelper helper = new RestHelper(ApplicationConstants._URLPROMOTION + campaign_id);
            var response = await helper.Post(body, Token);
            UpdateItemPromotionResponse updateItemPromotionResponse = JsonConvert.DeserializeObject<UpdateItemPromotionResponse>(response.Item1);
            return new Tuple<UpdateItemPromotionResponse, HttpStatusCode>(updateItemPromotionResponse, response.Item2);
            }

        public async Task<Tuple<GetListingSetResponse,HttpStatusCode>> GetListingSet(string campaign_id, string status, string sort, int limit, int offset)
            {

            RestHelper helper = new RestHelper(ApplicationConstants.PROMOTIONLIST_URL + campaign_id + "/" + "get_listing_set" + "?limit=" + limit + "&offset=" + offset + "&sort=" + sort + "&status=" + status);
            var response = await helper.Get(Token);
            GetListingSetResponse getListingSetResponse = JsonConvert.DeserializeObject<GetListingSetResponse>(response.Item1);
            return new Tuple<GetListingSetResponse, HttpStatusCode>(getListingSetResponse, response.Item2);
            }
        public async Task<Tuple<GetPromotionsResponse,HttpStatusCode>> Getpromotion(int limit, int offset, string promotion_status, string sort, string marketplace_id)
            {

            RestHelper helper = new RestHelper(ApplicationConstants.PROMOTIONLIST_URL + "?limit=" + limit + "&offset=" + offset + "&promotion_status=" + promotion_status + "&sort=" + sort + "&marketplace_id=" + marketplace_id);
            var response = await helper.Get(Token);
            GetPromotionsResponse getPromotionsResponse = JsonConvert.DeserializeObject<GetPromotionsResponse>(response.Item1);
            return new Tuple<GetPromotionsResponse, HttpStatusCode>(getPromotionsResponse, response.Item2);
            }
        public async Task<Tuple<string,HttpStatusCode>> PausePromotion(string promotion_id)
            {
            var body = JsonConvert.SerializeObject(promotion_id);
            RestHelper helper = new RestHelper(ApplicationConstants.PROMOTIONLIST_URL + "/" + promotion_id + "/" + "pause");
            var response = await helper.Post(body, Token);
                       return new Tuple<string, HttpStatusCode>(response.Item1, response.Item2);
            }
        public async Task<Tuple<string,HttpStatusCode>> ResumePromotion(string promotion_id)
            {
            var body = JsonConvert.SerializeObject(promotion_id);
            RestHelper helper = new RestHelper(ApplicationConstants.PROMOTIONLIST_URL + "/" + promotion_id + "/" + "resume");
            var response = await helper.Post(body, Token);
                       return new Tuple<string, HttpStatusCode>(response.Item1, response.Item2);
            }

        //No any method of  MarketingApi is available for Item_Price_markdown 


        public async Task<Tuple<string,HttpStatusCode>> CreateItemPriceMarkdownPromotion(CreateItemPriceMarkdownPromotionRequest createItemPriceMarkdownPromotionRequest)
            {
            var body = JsonConvert.SerializeObject(createItemPriceMarkdownPromotionRequest);
            RestHelper helper = new RestHelper(ApplicationConstants.ITEMPRICE_URL);
            var response = await helper.Post(body, Token);
                       return new Tuple<string, HttpStatusCode>(response.Item1, response.Item2);
            }
        public async Task<Tuple<string,HttpStatusCode>> DeleteItemPriceMarkdownPromotion(string campaign_id)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.ITEMPRICE_URL + "/" + campaign_id);
            var response = await helper.Delete(campaign_id, Token);
                       return new Tuple<string, HttpStatusCode>(response.Item1, response.Item2);
            }
        public async Task<Tuple<GetItemPriceMarkdownPromotionResponse,HttpStatusCode>> getItemPriceMarkdownPromotion(string campaign_id)
            {

            RestHelper helper = new RestHelper(ApplicationConstants.ITEMPRICE_URL + "/" + campaign_id);
            var response = await helper.Get(Token);
            GetItemPriceMarkdownPromotionResponse getItemPriceMarkdownPromotionResponse = JsonConvert.DeserializeObject<GetItemPriceMarkdownPromotionResponse>(response.Item1);
            return new Tuple<GetItemPriceMarkdownPromotionResponse, HttpStatusCode>(getItemPriceMarkdownPromotionResponse, response.Item2);
            }
        public async Task<Tuple<string,HttpStatusCode>> UpdateItemPriceMarkdownPromotion(UpdateItemPromotionRequest updateItemPromotionRequest, string campaign_id)
            {
            var body = JsonConvert.SerializeObject(updateItemPromotionRequest);
            RestHelper helper = new RestHelper(ApplicationConstants.ITEMPRICE_URL + "/" + campaign_id);
            var response = await helper.Post(body, Token);
                       return new Tuple<string, HttpStatusCode>(response.Item1, response.Item2);
            }
        public async Task<Tuple<GetPromotionReportsResponse,HttpStatusCode>> getPromotionReports(string promotion_status, string marketplace_id)
            {

            RestHelper helper = new RestHelper(ApplicationConstants.PROMOTIONREPORT_URL + "/" + "?marketplace_id=" + marketplace_id + "&promotion_status=" + promotion_status);
            var response = await helper.Get(Token);
            GetPromotionReportsResponse getPromotionReportsResponse = JsonConvert.DeserializeObject<GetPromotionReportsResponse>(response.Item1);
            return new Tuple<GetPromotionReportsResponse, HttpStatusCode>(getPromotionReportsResponse, response.Item2);
            }
        public async Task<Tuple<GetPromotionSummaryReportResponse,HttpStatusCode>> GetPromotionSummaryReport(string marketplace_id)
            {

            RestHelper helper = new RestHelper(ApplicationConstants.PROMOTIONSUMMARYREP_URL + "?marketplace_id=" + marketplace_id);
            var response = await helper.Get(Token);
            GetPromotionSummaryReportResponse getPromotionSummaryReportResponse = JsonConvert.DeserializeObject<GetPromotionSummaryReportResponse>(response.Item1);
            return new Tuple<GetPromotionSummaryReportResponse, HttpStatusCode>(getPromotionSummaryReportResponse, response.Item2);
            }
   

    }
   

}
