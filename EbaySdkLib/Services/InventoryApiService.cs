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
    public class InventoryApiService
        {
         public string Token { get;private set; }
         public InventoryApiService(string token)
            {
             this.Token = token;
          }

        #region InventoryLocations
    

        public async Task<Tuple<GetInventryLocationResponse, HttpStatusCode>> CreateInventoryLocationService(CreateInventoryLocationRequest createInventoryLocationRequest, string merchantLocationKey)
            {
            var body = JsonConvert.SerializeObject(createInventoryLocationRequest);
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORYLOCATION_URL + merchantLocationKey);
            var response = await helper.Post(body, Token);
            GetInventryLocationResponse getInventryLocationResponse =  JsonConvert.DeserializeObject<GetInventryLocationResponse>(response.Item1);
            return new Tuple<GetInventryLocationResponse, HttpStatusCode>(getInventryLocationResponse, response.Item2);
            }

        public async Task<Tuple<string, HttpStatusCode>> UpdateInventoryLocationService(UpdateInventoryLocationRequest updateInventoryLocationRequest, string merchantLocationKey)
            {
            var body = JsonConvert.SerializeObject(updateInventoryLocationRequest);
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORYLOCATION_URL + merchantLocationKey);
            var response = await helper.Post(body, Token);
            return new Tuple<string, HttpStatusCode>(response.Item1, response.Item2);
            }


        public async Task<Tuple<GetInventryLocationResponse,HttpStatusCode>>getInventoryLocationService(string merchantLocationKey)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORYLOCATION_URL  + merchantLocationKey );
            var response = await helper.Get(Token);
            GetInventryLocationResponse getInventryLocationResponse = JsonConvert.DeserializeObject<GetInventryLocationResponse>(response.Item1);
            return new Tuple<GetInventryLocationResponse, HttpStatusCode>(getInventryLocationResponse, response.Item2);
            }

        public async Task<Tuple<GetInventoryLocationsResponce,HttpStatusCode>> getInventoryLocationsService(int limit = 2, int offset = 2)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORYLOCATION_URL + "?limit=" + limit + "&offset=" + offset);
            var response = await helper.Get(Token);
            GetInventoryLocationsResponce getReturnPoliciesResponse = JsonConvert.DeserializeObject<GetInventoryLocationsResponce>(response.Item1);
            return new Tuple<GetInventoryLocationsResponce, HttpStatusCode>(getReturnPoliciesResponse, response.Item2);
            }
        //request invalid for enable and disable
        public async Task<Tuple<string,HttpStatusCode>> enableInventoryLocationService(string Id)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORYLOCATION_URL +  Id + "/enable");
            var response = await helper.Get(Token);
            return new Tuple<string, HttpStatusCode>(response.Item1, response.Item2);
            }

        public async Task<Tuple<string,HttpStatusCode>> disableInventoryLocationService(string Id)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORYLOCATION_URL +  Id + "/disable");
            var response = await helper.Get(Token);
            return new Tuple<string, HttpStatusCode>(response.Item1, response.Item2);
            }

        public async Task<Tuple<string,HttpStatusCode>> deleteInventoryLocationService(string Id)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORYLOCATION_URL + Id );
            var response = await helper.Delete(Id, Token);
            return new Tuple<string, HttpStatusCode>(response.Item1, response.Item2); ;
            }

        #endregion 
        #region Inventory offers
        /// <summary>
        /// Invalid response
        /// </summary>
        /// <param name="createOffersRequest"></param>
        /// <returns></returns>
        public async Task<Tuple<CreateOffersResponse,HttpStatusCode>> createOffersService(CreateOffersRequest createOffersRequest)
            {
            var body = JsonConvert.SerializeObject(createOffersRequest);
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORYOFFER_URL);
            var response = await helper.Post(body, Token);
            CreateOffersResponse createOffersresponse = JsonConvert.DeserializeObject<CreateOffersResponse>(response.Item1);
            return new Tuple<CreateOffersResponse, HttpStatusCode>(createOffersresponse, response.Item2);
            }

        public async Task<Tuple<UpdateInventoryOffersResponse,HttpStatusCode>> updateOffersService(UpdateInventoryOfferRequest updateInventoryOfferRequest,string Id)
            {
            var body = JsonConvert.SerializeObject(updateInventoryOfferRequest);
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORYOFFER_URL+Id);
            var response = await helper.Post(body, Token);
            UpdateInventoryOffersResponse updateinventoryOffersResponse = JsonConvert.DeserializeObject<UpdateInventoryOffersResponse>(response.Item1);
            return new Tuple<UpdateInventoryOffersResponse, HttpStatusCode>(updateinventoryOffersResponse, response.Item2);
            }

        public async Task<Tuple<GetOffersResponse,HttpStatusCode>> getOffersService(string Id)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORYOFFER_URL+"?sku=" + Id);
            var response = await helper.Get(Token);
            GetOffersResponse getOffersResponse = JsonConvert.DeserializeObject<GetOffersResponse>(response.Item1);
            return new Tuple<GetOffersResponse, HttpStatusCode>(getOffersResponse, response.Item2);
            }

        public async Task<Tuple<GetofferResponse,HttpStatusCode>> getOfferService(string Id)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORYOFFER_URL + Id);
            var response = await helper.Get(Token);
            GetofferResponse getofferResponse = JsonConvert.DeserializeObject<GetofferResponse>(response.Item1);
            return new Tuple<GetofferResponse, HttpStatusCode>(getofferResponse, response.Item2);
            }
        public async Task<Tuple<string,HttpStatusCode>> deleteOffersService(string Id)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORYOFFER_URL + Id);
            var response = await helper.Get(Token);
            return new Tuple<string ,HttpStatusCode>(response.Item1,response.Item2);
            }
        public async Task<Tuple<PublichoffersResponse,HttpStatusCode>> publishOfferService(string Id)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORYOFFER_URL + Id+"/publish");
            
            var response = await helper.Post("",Token);
            PublichoffersResponse publichoffersResponse = JsonConvert.DeserializeObject<PublichoffersResponse>(response.Item1);
            return new Tuple<PublichoffersResponse, HttpStatusCode>(publichoffersResponse, response.Item2);
          
            }
      
        public async Task<Tuple<GetListingFeesResponse,HttpStatusCode>> getListingFeesService(string Id)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORYOFFER_URL +Id);
            var response = await helper.Get(Token);
            GetListingFeesResponse getListingFeesResponse = JsonConvert.DeserializeObject<GetListingFeesResponse>(response.Item1);
            return new Tuple<GetListingFeesResponse, HttpStatusCode>(getListingFeesResponse, response.Item2);
          
            }
        public async Task<Tuple<GetListingFeesResponse,HttpStatusCode>> publishOfferByInventoryItemGroupService(string Id)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORYOFFER_URL + Id);
            var response = await helper.Get(Token);
            GetListingFeesResponse publishOffer = JsonConvert.DeserializeObject<GetListingFeesResponse>(response.Item1);
            return new Tuple<GetListingFeesResponse, HttpStatusCode>(publishOffer, response.Item2);

            }
        public async Task<Tuple<WithdrawOfferResponse,HttpStatusCode>> WithdrawOfferService(string Id)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORYOFFER_URL + Id+"/withdraw");
            var response = await helper.Get(Token);
            WithdrawOfferResponse WithdrawOffer = JsonConvert.DeserializeObject<WithdrawOfferResponse>(response.Item1);
            return new Tuple<WithdrawOfferResponse, HttpStatusCode>(WithdrawOffer, response.Item2);


            }
        #endregion
        #region InventoryItems
        public async Task<Tuple<GetInventoryitemResponse,HttpStatusCode>> getInventoryItemService(string Id)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORY_URL + "inventory_item/" + Id);
            var response = await helper.Get(Token);
            GetInventoryitemResponse getInventoryItems = JsonConvert.DeserializeObject<GetInventoryitemResponse>(response.Item1);
            return new Tuple<GetInventoryitemResponse, HttpStatusCode>(getInventoryItems, response.Item2);
            }
        public async Task<Tuple<GetInventoryItemsResponse,HttpStatusCode>> getInventoryItemsService()
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORY_URL + "inventory_item?limit=2&offset=0");
            var response = await helper.Get(Token);
            GetInventoryItemsResponse getInventoryItemsResponse = JsonConvert.DeserializeObject<GetInventoryItemsResponse>(response.Item1);
            return new Tuple<GetInventoryItemsResponse, HttpStatusCode>(getInventoryItemsResponse, response.Item2);
            }
        public async Task<Tuple<string,HttpStatusCode>> deleteInventoryItemService(string sku)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORY_URL  + sku);
            var response = await helper.Get(Token);
            return new Tuple<string ,HttpStatusCode>(response.Item1,response.Item2);
            }
        public async Task<Tuple<BulkUpdatePriceQualityResponse,HttpStatusCode>> bulkUpdatePriceQualityService(BulkUpdatePriceQualityRequest bulkUpdatePriceQualityRequest)
            {
            var body = JsonConvert.SerializeObject(bulkUpdatePriceQualityRequest);
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORY_URL+"bulk_update_price_quantity");
            var response = await helper.Post(body, Token);
            BulkUpdatePriceQualityResponse bnulkUpdatePriceQualityResponse = JsonConvert.DeserializeObject<BulkUpdatePriceQualityResponse>(response.Item1);
            return new Tuple<BulkUpdatePriceQualityResponse, HttpStatusCode>(bnulkUpdatePriceQualityResponse, response.Item2);
            }

        public async Task<Tuple<CreateorReplaceItemResponse,HttpStatusCode>> CreateorReplaceItemService(CreateorReplaceInventoryItemrequest createorReplaceInventoryItemrequest, string sku)
            {
            var body = JsonConvert.SerializeObject(createorReplaceInventoryItemrequest);
            RestHelper helper = new RestHelper(ApplicationConstants.PRODCOMPATIBILITY_URL + sku);
            var response = await helper.Put(body, Token);//.ConfigureAwait(false);
            CreateorReplaceItemResponse createorReplaceItemResponse = JsonConvert.DeserializeObject<CreateorReplaceItemResponse>(response.Item1);
            return new Tuple<CreateorReplaceItemResponse, HttpStatusCode>(createorReplaceItemResponse, response.Item2);
            }

        #endregion
        #region inventoryGrp

        public async Task<Tuple<GetinventoryItemGroupResponse,HttpStatusCode>> getInventoryItemGroupService(string val)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTRYITEMGROUP_URL + val);
            var response = await helper.Get(Token);
            GetinventoryItemGroupResponse getinventoryItemGroupResponse = JsonConvert.DeserializeObject<GetinventoryItemGroupResponse>(response.Item1);
            return new Tuple<GetinventoryItemGroupResponse, HttpStatusCode>(getinventoryItemGroupResponse, response.Item2);
            }
        public async Task<Tuple<string,HttpStatusCode>> deleteInventoryItemgrpService(string val)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTRYITEMGROUP_URL + val);
            var response = await helper.Get(Token);
            return new Tuple<string,HttpStatusCode>( response.Item1,response.Item2);
            }

        public async Task<Tuple<CreateorReplaceItemResponse,HttpStatusCode>> CreateorReplaceItemgrpProdService(CreateOrReplaceinventoryItemGrpRequest createorReplaceItemRequest, string val)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTRYITEMGROUP_URL + val);
            var body = JsonConvert.SerializeObject(createorReplaceItemRequest);
            var response = await helper.Post(body, Token);
            CreateorReplaceItemResponse createorReplaceItemResponse = JsonConvert.DeserializeObject<CreateorReplaceItemResponse>(response.Item1);
            return new Tuple<CreateorReplaceItemResponse, HttpStatusCode>(createorReplaceItemResponse, response.Item2);
            }

        #endregion
        #region Listing
        public async Task<Tuple<BulkMigratelistingresponse,HttpStatusCode>> bulkMigrateListingService(BulkMigrateListingRequest bulkMigrateListingRequest)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTORY_URL + "bulk_migrate_listing");
            var body = JsonConvert.SerializeObject(bulkMigrateListingRequest);
            var response = await helper.Post(body, Token);
            BulkMigratelistingresponse bulkMigratelistingresponse = JsonConvert.DeserializeObject<BulkMigratelistingresponse>(response.Item1);
            return new Tuple<BulkMigratelistingresponse, HttpStatusCode>(bulkMigratelistingresponse, response.Item2);
            }

        #endregion

        #region ProdCompatibility
        public async Task<Tuple<CreateOrReplaceProductComaptibilityResponse,HttpStatusCode>> CreateOrReplaceProductCompatibilityService(CreateOrReplaceProductCompatibilityRequest createOrReplaceProductCompatibilityRequest, string sku)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.PRODCOMPATIBILITY_URL + sku+"/product_compatibility");
          
         
            var body = JsonConvert.SerializeObject(createOrReplaceProductCompatibilityRequest);
            var response = await helper.Post(body, Token);
            
            CreateOrReplaceProductComaptibilityResponse comaptibilityResponse = JsonConvert.DeserializeObject<CreateOrReplaceProductComaptibilityResponse>(response.Item1);
            return new Tuple<CreateOrReplaceProductComaptibilityResponse, HttpStatusCode>(comaptibilityResponse, response.Item2);
            }

        public async Task<Tuple<GetProductCompatibilityResponse,HttpStatusCode>> getProductCompatibilityService(string val)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTRYITEMGROUP_URL + val+"/product_compatibility");
            var response = await helper.Get(Token);
            GetProductCompatibilityResponse getProductCompatibilityResponse = JsonConvert.DeserializeObject<GetProductCompatibilityResponse>(response.Item1);
            return new  Tuple<GetProductCompatibilityResponse, HttpStatusCode>(getProductCompatibilityResponse, response.Item2); 
            }
        public async Task<Tuple<string,HttpStatusCode>> deleteProductCompatibilityService(string val)
            {
            RestHelper helper = new RestHelper(ApplicationConstants.INVENTRYITEMGROUP_URL + val);
            var response = await helper.Get(Token);
            return new Tuple<string, HttpStatusCode>(response.Item1, response.Item2); 
            }

       
        #endregion
        }
    }
