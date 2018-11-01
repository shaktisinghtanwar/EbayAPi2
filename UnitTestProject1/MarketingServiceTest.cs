using EbaySdkLib.Messages;
using EbaySdkLib.Models;
using EbaySdkLib.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnitTestProject1
    {
    [TestClass]
    class marketingAPIService 
        {
        MarketingAPIService _marketingAPIService;
        public string Token { get; set; }
        [TestInitialize]
        public void Setup()
            {
        Token = ConfigurationManager.AppSettings["token"];
        _marketingAPIService = new MarketingAPIService(Token);

            }
        #region marketingApi/compaign
        [TestMethod]
        public void CloneMarketingTest()
            {
           
            EbaySdkLib.Messages.CloneCampaignRequest cloneCampaignRequest = new EbaySdkLib.Messages.CloneCampaignRequest();
            string campaign_id = "10001741014";
            cloneCampaignRequest.campaignName = "Fall Sale";
            string campaignName = cloneCampaignRequest.campaignName.ToString();
            cloneCampaignRequest.endDate = "2016-10-25T20:57:00.000Z";
            cloneCampaignRequest.fundingStrategy = new EbaySdkLib.Models.FundingStrategy()
            {
                bidPercentage = "15.0",
                fundingModel = EbaySdkLib.Enums.FundingModelEnum.COST_PER_SALE

            };
            cloneCampaignRequest.startDate = "2016-09-24T20:57:00.000Z";
            var response = _marketingAPIService.CloneMarketing(cloneCampaignRequest, campaign_id).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }

        [TestMethod]
        public void CreatemarketingTest()
            {
           
            EbaySdkLib.Messages.CreateCampaignRequest createCampaignRequest = new EbaySdkLib.Messages.CreateCampaignRequest();
            createCampaignRequest.campaignName = "Fall Sale";
            createCampaignRequest.fundingStrategy = new EbaySdkLib.Models.FundingStrategy()
            {
                bidPercentage = "10.0",
                fundingModel = EbaySdkLib.Enums.FundingModelEnum.COST_PER_SALE

            };
            createCampaignRequest.marketplaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US;
            createCampaignRequest.startDate = "2016-09-24T20:57:00.000Z";
            var response = _marketingAPIService.CreateMarketing(createCampaignRequest).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void DeleteMarketingTest()
            {
           
            string campaign_id = "10001741014";
            var response = _marketingAPIService.DeleteMarketing(campaign_id).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}

            }
        [TestMethod]
        public void EndCampaignTest()
            {
           
            string campaign_id = "10001741014";
            var response = _marketingAPIService.EndCampaign(campaign_id).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}

            }
        [TestMethod]
        public void GetCampaignTest()
            {
           
            string campaign_id = "10000176012";
            var response = _marketingAPIService.GetCampaign(campaign_id).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}

            }
        [TestMethod]
        public void GetCampaignByNameTest()
            {
           
            string campaignName = "Summer Sale";
            var response = _marketingAPIService.GetCampaignByNameRequest(campaignName).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}

            }
        [TestMethod]
        public void GetCampaignsTest()
            {
           
            string campaignName = "Fall Sale";
            string campaignStatus = "SCHEDULED";
            string startDate = "2016-09-25T02:20:00.000Z";
            string endDate = "2016-09-26T19:57:00.000Z";
            string limit = "10";
            string offset = "0";

            var response = _marketingAPIService.GetCampaigns(campaignName, campaignStatus, startDate, endDate, limit, offset).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}

            }
        [TestMethod]
        public void PauseCampaignTest()
            {
           
            string campaign_id = "10005213014";
            var response = _marketingAPIService.PauseCampaign(campaign_id).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}

            }
        [TestMethod]
        public void ResumeCampaignTest()
            {
           
            string campaign_id = "10005213014";
            var response = _marketingAPIService.ResumeCampaign(campaign_id).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}

            }
        [TestMethod]
        public void UpdateCampaignIdentificationTest()
            {
           
            EbaySdkLib.Messages.UpdateCampaignIdentificationRequest updateCampaignIdentificationRequest = new EbaySdkLib.Messages.UpdateCampaignIdentificationRequest();
            string campaign_id = "10005213014";
            updateCampaignIdentificationRequest.campaignName = "Fall Sale II";
            updateCampaignIdentificationRequest.endDate = "2016-09-07T21:43:00.000Z";
            updateCampaignIdentificationRequest.startDate = null;
            var response = _marketingAPIService.UpdateCampaignIdentification(updateCampaignIdentificationRequest, campaign_id).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}

            }


        #endregion
        #region marketingApi/Item_Promotion
        [TestMethod]
        public void CreateItemPromotionTest()
        {
           
            EbaySdkLib.Messages.CreateItemPromotionRequest createItemPromotionRequest = new EbaySdkLib.Messages.CreateItemPromotionRequest();
            createItemPromotionRequest.description = "Buy 1 and get 2nd one 25% off -part 6";
            createItemPromotionRequest.discountRules = new EbaySdkLib.Models.DiscountRule[]{new EbaySdkLib.Models.DiscountRule(){ discountSpecification = new EbaySdkLib.Models.DiscountSpecification()
                        { numberOfDiscountedItems =1,
                         forEachQuantity=1
                                         
                          }, ruleOrder=0,

                    discountBenefit=new EbaySdkLib.Models.DiscountBenefit()
                    {
                        percentageOffItem="25",

                    },
                  }
                
                };
            createItemPromotionRequest.name = "Buy 1 and get 2nd one 25% off -part 6";
            createItemPromotionRequest.startDate = "2017-03-11T19:58:18.918Z";
            createItemPromotionRequest.endDate = "2027-03-01T20:00:00.000Z";
            createItemPromotionRequest.marketplaceId = "EBAY-US";

            var response = _marketingAPIService.CreateItemPromotion(createItemPromotionRequest).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}

            }
        [TestMethod]
        public void DeleteItemPromotionTest()
            {
           
            string promotion_id = "115001954505@EBAY-US";
            var response = _marketingAPIService.DeleteItemPromotion(promotion_id).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }



        #endregion

        #region Lodhiwork
        [TestMethod]
        public void bulkCreateAdsByInventory()
            {
           
            bulkCreateAdsByInventoryReferenceRequest bulkCreateAds = new bulkCreateAdsByInventoryReferenceRequest();
            bulkCreateAds.inventoryReferenceId = "66352443";
            bulkCreateAds.inventoryReferenceType = "INVENTORY_ITEM";
            string campaign_id = "10001741014";
            string bulk_create_ads = "bulk_create_ads_by_inventory_reference";
            var response = _marketingAPIService.bulkCreateAdsByInventory(bulkCreateAds, campaign_id, bulk_create_ads).Result;

            if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            }

        [TestMethod]
        public void bulkCreateAdsByListingId()
            {
           
            bulkCreateAdsByInventoryReferenceRequest bulkCreateAds = new bulkCreateAdsByInventoryReferenceRequest();
            bulkCreateAds.inventoryReferenceId = "66352443";
            bulkCreateAds.inventoryReferenceType = "INVENTORY_ITEM";
            string campaign_id = "10001741014";
            string bulk_create_ads_by_listing = "bulk_create_ads_by_listing_id";
            var response = _marketingAPIService .bulkCreateAdsByListingId(bulkCreateAds, campaign_id, bulk_create_ads_by_listing).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void bulkDeleteAdsByInventoryReference()
            {
           
            bulkCreateAdsByInventoryReferenceRequest bulkCreateAds = new bulkCreateAdsByInventoryReferenceRequest();
            bulkCreateAds.inventoryReferenceId = "66352443";
            bulkCreateAds.inventoryReferenceType = "INVENTORY_ITEM";
            string campaign_id = "10001741014";
            string bulk_delete_ads_by_inventory = "bulk_delete_ads_by_inventory_reference";
            var response = _marketingAPIService .bulkDeleteAdsByInventoryReference(bulkCreateAds, campaign_id, bulk_delete_ads_by_inventory).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void bulkDeleteAdsByListingId()
            {
           
            bulkCreateAdsByInventoryReferenceRequest bulkDeleteAd = new bulkCreateAdsByInventoryReferenceRequest();
            bulkDeleteAd.inventoryReferenceId = "66352443";
            bulkDeleteAd.inventoryReferenceType = "INVENTORY_ITEM";
            string campaign_id = "10001741014";
            string bulkDeleteAdsByListingId = "bulk_delete_ads_by_listing_id";
            var response = _marketingAPIService .bulkDeleteAdsByListingId(bulkDeleteAd, campaign_id, bulkDeleteAdsByListingId).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void bulkUpdateAdsBidByInventoryReference()
            {
           
            bulkCreateAdsByInventoryReferenceRequest bulkUpdateAds = new bulkCreateAdsByInventoryReferenceRequest();
            bulkUpdateAds.inventoryReferenceId = "2343212";
            bulkUpdateAds.inventoryReferenceType = "INVENTORY_ITEM";
            string campaign_id = "10001741014";
            string bulk_update_ads = "bulk_update_ads_bid_by_inventory_reference";
            var response = _marketingAPIService .bulkUpdateAdsBidByInventoryReference(bulkUpdateAds, campaign_id, bulk_update_ads).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void bulkUpdateAdsBidByListingId()
            {
           
            bulkCreateAdsByInventoryReferenceRequest bulkUpdateAds = new bulkCreateAdsByInventoryReferenceRequest();
            bulkUpdateAds.listingId = "190007022519";
            string campaign_id = "10001741014";
            string bulk_update_ads_by_listing = "bulk_update_ads_bid_by_listing_id";
            var response = _marketingAPIService .bulkUpdateAdsBidByListingId(bulkUpdateAds, campaign_id, bulk_update_ads_by_listing).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void createAdByListingId()
            {
           
            bulkCreateAdsByInventoryReferenceRequest createAdByListing = new bulkCreateAdsByInventoryReferenceRequest();
            createAdByListing.listingId = "190007022519";
            createAdByListing.bidPercentage = "10";
            string campaign_id = "10001741014";
            string createAd = "ad";
            var response = _marketingAPIService .createAdByListingId(createAdByListing, campaign_id, createAd).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void createAdsByInventoryReference()
            {
           
            bulkCreateAdsByInventoryReferenceRequest createAdsByInventoryReference = new bulkCreateAdsByInventoryReferenceRequest();
            createAdsByInventoryReference.bidPercentage = "10";
            createAdsByInventoryReference.inventoryReferenceId = "87536492";
            createAdsByInventoryReference.inventoryReferenceType = "INVENTORY_ITEM";
            string campaign_id = "10001741014";
            string create_ads_by_inventory = "create_ads_by_inventory_reference";
            var response = _marketingAPIService .createAdsByInventoryReference(createAdsByInventoryReference, campaign_id, create_ads_by_inventory).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void deleteAd()
            {
           
            bulkCreateAdsByInventoryReferenceRequest deleteAd = new bulkCreateAdsByInventoryReferenceRequest();
            //deleteAd.bidPercentage = "10";
            //deleteAd.inventoryReferenceId = "87536492";
            //deleteAd.inventoryReferenceType = "INVENTORY_ITEM";
            string campaign_id = "10001741014";
            string deletead = "ad";
            string addid = "12428546014";
            var response = _marketingAPIService .deleteAd(deleteAd, campaign_id, deletead, addid).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void deleteAdsByInventoryReference()
            {
           
            bulkCreateAdsByInventoryReferenceRequest deleteAdsByInventoryReference = new bulkCreateAdsByInventoryReferenceRequest();
            deleteAdsByInventoryReference.inventoryReferenceId = "133232";
            deleteAdsByInventoryReference.inventoryReferenceType = "INVENTORY_ITEM";
            string campaign_id = "10001741014";
            string delete_ads = "delete_ads_by_inventory_reference";
            var response = _marketingAPIService .deleteAdsByInventoryReference(deleteAdsByInventoryReference, campaign_id, delete_ads).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void getAd()
            {

           
            bulkCreateAdsByInventoryReferenceRequest getAd = new bulkCreateAdsByInventoryReferenceRequest();
            string campaign_id = "10001741014";
            string ad = "ad";
            string adId = "12427947014";
            var response = _marketingAPIService .getAd(getAd, campaign_id, ad, adId).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void getAds()
            {
           
            //GetAdsResponse getAds = new GetAdsResponse();
            //getAds.ads = new EbaySdkLib.Models.Ad[] { new EbaySdkLib.Models.Ad() {listingId= "190007022518" } };
            //getAds.limit = "10";
            //getAds.offset = "0";
            string campaign_id = "10001741014";
            string ad = "ad";
            var response = _marketingAPIService .getAds(campaign_id, ad).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void getAdsByInventoryReference()
            {
           
            bulkCreateAdsByInventoryReferenceRequest getAdsByInventoryReference = new bulkCreateAdsByInventoryReferenceRequest();
            getAdsByInventoryReference.inventoryReferenceType = "INVENTORY_ITEM";
            getAdsByInventoryReference.inventoryReferenceId = "133232";
            string campaign_id = "10001741014";
            string getads = "get_ads_by_inventory_reference?";
            var response = _marketingAPIService .getAdsByInventoryReference(getAdsByInventoryReference, campaign_id, getads).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void updateBid()
            {
           
            bulkCreateAdsByInventoryReferenceRequest updateBid = new bulkCreateAdsByInventoryReferenceRequest();
            updateBid.bidPercentage = "11";
            string campaign_id = "10001741014";
            string updatead = "ad";
            string adId = "12427947014";
            string update_bid = "update_bid";
            var response = _marketingAPIService .updateBid(updateBid, campaign_id, updatead, adId, update_bid).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void getReport()
            {
           
            string reportiId = "10000049014";
            var response = _marketingAPIService .getReport(reportiId).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void getReportMetadata()
            {
           
            var response = _marketingAPIService .getReportMetadata().Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void getReportMetadataForReportType()
            {
           
            GetReportMetadataResponse GetReportMetadata = new GetReportMetadataResponse();
            GetReportMetadata.reportType = "ACCOUNT_PERFORMANCE_REPORT";
            var response = _marketingAPIService .getReportMetadataForReportType(GetReportMetadata).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void createReportTask()
            {
           
            CreateReportTaskRequest createReportTask = new CreateReportTaskRequest();
            string[] metricKeys = new string[] { "CLICKS" };
            string[] annotationKeys = new string[] { "campaign_name", "campaign_start_date", "campaign_end_date" };

            createReportTask.reportType = EbaySdkLib.Enums.ReportTypeEnum.CAMPAIGN_PERFORMANCE_REPORT;
            createReportTask.dateTo = "yyyy-MM-ddThh:mm.ss.sssZ";
            //createReportTask.metricKeys = metricKeys;
            //createReportTask.dimensions = new Dimension(new string[]{ "Darth", "Vader" }).dimensionKey("Luke"); 
            var response = _marketingAPIService .createReportTask(createReportTask).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void deleteReportTask()
            {
           
            string reportTaskId = "10000056014";
            var response = _marketingAPIService .deleteReportTask(reportTaskId).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void getReportTask()
            {
           
            string reportTaskId = "10000049014";
            var response = _marketingAPIService .getReportTask(reportTaskId).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        [TestMethod]
        public void getReportTasks()
            {
           
            CreateReportTaskRequest reporttask = new CreateReportTaskRequest();

            string reportTaskstatus = "PENDING,SUCCESS";
            string limit = "10";
            var response = _marketingAPIService .getReportTasks(reportTaskstatus, limit).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}
            }
        #endregion

        #region MarketingApi/Promotion
        [TestMethod]
        public void GetListingSetTest()
            {
           
            //EbaySdkLib.Messages.GetListingSetRequest getShippingFulfillmentsRequest = new EbaySdkLib.Messages.GetListingSetRequest();
            string promotion_id = "115002723203@EBAY-US";
            string status = "SKIPPED";
            string sort = "AVAILABLE";
            int offset = 0;
            int limit = 10;


            var response = _marketingAPIService.GetListingSet(promotion_id, status, sort, offset, limit).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}


            }
        [TestMethod]
        public void GetpromotionTest()
            {
           
            int limit = 5;
            int offset = 0;
            string promotion_status = "DRAFT";
            string sort = "START_DATE";
            string marketplace_id = "EBAY_US";
            var response = _marketingAPIService.Getpromotion(limit, offset, promotion_status, sort, marketplace_id).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}

            }
        [TestMethod]
        public void PausePromotionTest()
            {
           

            string promotion_id = "115001954505@EBAY-US";
            var response = _marketingAPIService.PausePromotion(promotion_id).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}

            }
        [TestMethod]
        public void ResumePromotionTest()
            {
           

            string promotion_id = "115001954505@EBAY-US";
            var response = _marketingAPIService.ResumePromotion(promotion_id).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}

            }
        #endregion
        #region Promotion_Report
        [TestMethod]
        public void getPromotionReportsTest()
            {
           
            string promotion_status = "ENDED";
            string marketplace_id = "EBAY_US";
            var response = _marketingAPIService.getPromotionReports(promotion_status, marketplace_id).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}

            }

        #endregion
        #region Pramotion_Summary_Report
        [TestMethod]
        public void GetPromotionSummaryReportTest()
            {
           
            string marketplace_id = "EBAY_US";
            var response = _marketingAPIService.GetPromotionSummaryReport(marketplace_id).Result;
            if(response.Item2.ToString()=="OK"){ Assert.IsNotNull(response.Item1);}else{Assert.Fail(response.Item2.ToString());}

            }
        #endregion

        }
    }
