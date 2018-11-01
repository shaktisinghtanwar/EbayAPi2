using EbaySdkLib;
using EbaySdkLib.Messages;
using EbaySdkLib.Models;
using EbaySdkLib.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SellingTools_Lib;
using SellingTools_Lib.DBConnect;
using SellingTools_Lib.Enums;
using SellingTools_Lib.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
    {
    [TestClass]
    public class InventoryApiTest
        {
        InventoryApiService _inventoryApiService;
        SqlConnectionStringBuilder _cstr;
        public string Token { get; set; }
        [TestInitialize]
        public void Setup()
            {
        Token = ConfigurationManager.AppSettings["token"];
        _inventoryApiService = new InventoryApiService(Token);
        _cstr = new SqlConnectionStringBuilder();
        _cstr.DataSource = "DESKTOP-4SQEA0V\\SQLEXPRESS2012";
        _cstr.InitialCatalog = "Ebay_Api";
        _cstr.IntegratedSecurity = true;
        _cstr.TrustServerCertificate = true;
            }
        [TestMethod]
        public void GetAccessTokenTest()
        {
            GetAccessTokenService getAccessTokenService = new GetAccessTokenService();
            var response = getAccessTokenService.GetToken(Token).Result;

            Assert.IsNotNull(response);
        }
        [TestMethod]
        public void GetRefreshTokenTest()
        {
            string ExpiredAccessToken = "";
            GetAccessTokenService getAccessTokenService = new GetAccessTokenService();
            var response = getAccessTokenService.GetRefreshToken(ExpiredAccessToken).Result;
            Assert.IsNotNull(response);
        }

        public string UsingTokenMethod()
        {
            string token = "";
            try
            {
                Inventory.TokenCheckerPreRequest(_cstr, AccessTokenType.OAUTH);
                AccessTokenInfo at = DA_Ebay_Inventory.Get_AccessTokenInfo(_cstr, AccessTokenType.OAUTH);
                token = at.AccessToken;
            }
            catch (Exception er)
            {
                throw er;
            }
            return token;
        }
        #region InventoryLocation


        [TestMethod]
        public void CreateInventoryLocation()
            {
            string token = UsingTokenMethod();
            InventoryApiService _inventoryApiService = new InventoryApiService(token);
            string merchantLocationKey = "Warehouse-1";
            CreateInventoryLocationRequest createInventoryLocationRequest = new CreateInventoryLocationRequest();
            createInventoryLocationRequest.location = new Location()
            {
                address = new Address()
                {
                    addressLine1 = "2055 Hamilton Ave",
                    addressLine2 = "Building 3",
                    city = "San Jose",
                    stateOrProvince = "CA",
                    postalCode = "95125",
                    country = EbaySdkLib.Enums.CountryCodeEnum.US

                }

            };
            var response = _inventoryApiService.CreateInventoryLocationService(createInventoryLocationRequest, merchantLocationKey).Result;
            //if (response.Item2.ToString() == "OK")
            //    {
            //    Assert.IsNotNull(response.Item1);
            //    }
            //else
            //    {
            //    Assert.Fail(response.Item2.ToString());
            //    }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB

                        foreach (EbaySdkLib.Models.Location _loc in response.Item1.location)
                        {

                            SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_CreateInventoryLocation(_cstr, response.Item1.locationInstructions, response.Item1.name, response.Item1.merchantLocationStatus, response.Item1.locationTypes.ToString(), _loc.address.addressLine1, _loc.address.addressLine2, _loc.address.city, _loc.address.stateOrProvince, _loc.address.postalCode, _loc.address.country);
                           
                        }

                        return;
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [OutPutOfPrograms] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
            }


            }
        [TestMethod]
        public void UpdateInventoryLocation()
         {
            string token = UsingTokenMethod();
            InventoryApiService _inventoryApiService = new InventoryApiService(token);
            string merchantLocationKey = "Warehouse-1";
            UpdateInventoryLocationRequest updateInventoryLocationRequest = new UpdateInventoryLocationRequest();
            updateInventoryLocationRequest.locationAdditionalInformation = "Available for drop-off on Mondays only.";
            updateInventoryLocationRequest.locationInstructions = "Entrance is on the backside of the building.";
            updateInventoryLocationRequest.locationWebUrl = "http://www.example.com/warehouse-1";
            updateInventoryLocationRequest.name = "Warehouse-South";
            updateInventoryLocationRequest.phone = "888-730-0000";
            updateInventoryLocationRequest.operatingHours = new OperatingHour[]
         {
               new OperatingHour()
               {
               dayOfWeekEnum=EbaySdkLib.Enums.DayOfWeekEnum.MONDAY
               }
           };

            var response = _inventoryApiService.UpdateInventoryLocationService(updateInventoryLocationRequest, merchantLocationKey).Result;
            //if (response.Item2.ToString() == "OK")
            //    {
            //    Assert.IsNotNull(response.Item1);
            //    }
            //else
            //    {
            //    Assert.Fail(response.Item2.ToString());
            //    }

            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB

                     // int updatelocatyion=SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_UpdateLocation(_cstr,response.Item1.ToStri, response.Item1.name, response.Item1.merchantLocationStatus, response.Item1.locationTypes.ToString());

                    
                        return;
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [OutPutOfPrograms] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
            }
            }

        [TestMethod]
        public void getInventoryLocation()
            {
            string token = UsingTokenMethod();
            InventoryApiService _inventoryApiService = new InventoryApiService(token);
            string merchantLocationKey = "Warehouse-1";
            var response = _inventoryApiService.getInventoryLocationService(merchantLocationKey).Result;
            //if (response.Item2.ToString() == "OK")
            //    {
            //    Assert.IsNotNull(response.Item1);
            //    }
            //else
            //    {
            //    Assert.Fail(response.Item2.ToString());
            //    }

            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        int locationDBID = SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_GetInventoryLocation(_cstr, response.Item1.name, response.Item1.merchantLocationStatus, response.Item1.merchantLocationKey);
                        foreach (EbaySdkLib.Models.Location _loc in response.Item1.location)
                        {

                            SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_LocationAddress(_cstr, locationDBID, _loc.locationId, _loc.address.addressLine1, _loc.address.addressLine2, _loc.address.city, _loc.address.stateOrProvince, _loc.address.postalCode, _loc.address.country);
                        }
                        return;
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [OutPutOfPrograms] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
            }

            }

        [TestMethod]
        public void getInventoryLocations()
            {
                string token = UsingTokenMethod();
                InventoryApiService _inventoryApiService = new InventoryApiService(token);
                int limit = 2; int offset = 2;
               var response = _inventoryApiService.getInventoryLocationsService(limit, offset).Result;
            //if (response.Item2.ToString() == "OK")
            //    {
            //    Assert.IsNotNull(response.Item1);
            //    }
            //else
            //    {
            //    Assert.Fail(response.Item2.ToString());
            //    }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                      
                            int locationDBID = SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_GetInventoryLocations(_cstr, response.Item1.name,response.Item1.merchantLocationStatus, response.Item1.merchantLocationKey);
                            foreach (EbaySdkLib.Models.Location _loc in response.Item1.location)
                            {

                                SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_LocationsAddress(_cstr, locationDBID, _loc.locationId, _loc.address.city, _loc.address.stateOrProvince, _loc.address.postalCode,_loc.address.county);
                              
                                
                            }
                       
                        return;
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [OutPutOfPrograms] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
            }


            }


        [TestMethod]
        public void enableInventoryLocation()
            {
                string token = UsingTokenMethod();
                InventoryApiService _inventoryApiService = new InventoryApiService(token);
            string merchantLocationKey = "warehouse-1";
            var response = _inventoryApiService.enableInventoryLocationService(merchantLocationKey).Result;
            Assert.IsNotNull(response);
            }
        [TestMethod]
        public void disableInventoryLocation()
            {
                string token = UsingTokenMethod();
                InventoryApiService _inventoryApiService = new InventoryApiService(token);
            string merchantLocationKey = "warehouse-1";
            var response = _inventoryApiService.disableInventoryLocationService(merchantLocationKey).Result;
            if (response.Item2.ToString() == "OK")
                {
                Assert.IsNotNull(response.Item1);
                }
            else
                {
                Assert.Fail(response.Item2.ToString());
                }
            }


        //[TestMethod]
        //public void createInventoryLocations()
        //    {
        //  
        //    EbaySdkLib.Messages.CreateInventoryLocationRequest createInventoryLocationRequest = new EbaySdkLib.Messages.CreateInventoryLocationRequest();
        //    createInventoryLocationRequest.location = new EbaySdkLib.Models.Location()
        //    {
        //        address = new Address()
        //        {
        //            addressLine1 = "2055 Hamilton Ave",
        //            addressLine2 = "Building 3",
        //            city = "San Jose",
        //            country = CountryCodeEnum.US,
        //            postalCode = "12",
        //            stateOrProvince = "12"
        //        },
        //        geoCoordinates = new GeoCoordinates()
        //        {
        //            latitude = "12",
        //            longitude = "a34c"
        //        },
        //        locationId = "abc"
        //    };
        //    createInventoryLocationRequest.merchantLocationStatus = EbaySdkLib.Enums.StatusEnum.ENABLED;
        //    createInventoryLocationRequest.operatingHours = new EbaySdkLib.Models.OperatingHour[] { new EbaySdkLib.Models.OperatingHour()
        //    { 
        //        DayOfWeekEnum=DayOfWeekEnum.MONDAY,

        //    };
        //    //var response = _inventoryApiService.createInventoryLocationsService().Result;
        //   // Assert.IsNotNull(response);
        //    }

        [TestMethod]
        public void deleteInventoryLocation()
            {
               
            string merchantLocationKey = "warehouse-1";
            var response = _inventoryApiService.deleteInventoryLocationService(merchantLocationKey).Result;
            if (response.Item2.ToString() == "OK")
                {
                Assert.IsNotNull(response.Item1);
                }
            else
                {
                Assert.Fail(response.Item2.ToString());
                }
            }
        #endregion

        #region Offers
        /// <summary>
        /// header issue
        /// </summary>
        [TestMethod]
        public void createOffers()
            {
            string token = UsingTokenMethod();
            InventoryApiService _inventoryApiService = new InventoryApiService(token);
            EbaySdkLib.Messages.CreateOffersRequest createOffersRequest = new EbaySdkLib.Messages.CreateOffersRequest();
            createOffersRequest.marketplaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US;
            createOffersRequest.format = EbaySdkLib.Enums.FormatTypeEnum.FIXED_PRICE;
            createOffersRequest.sku = "ddtest1";
            createOffersRequest.availableQuantity = 75;
            createOffersRequest.listingPolicies = new ListingPolicies()
            {
                paymentPolicyId = "37967344010",
                returnPolicyId = "61019560011"
            };
            createOffersRequest.pricingSummary = new PricingSummary()
            {
                price = new Amount()
                {
                    currency = EbaySdkLib.Models.CurrencyCodeEnum.USD,
                    value = "260.00"

                }
            };
            var response = _inventoryApiService.createOffersService(createOffersRequest).Result;
            //if (response.Item2.ToString() == "OK")
            //    {
            //    Assert.IsNotNull(response.Item1);
            //    }
            //else
            //    {
            //    Assert.Fail(response.Item2.ToString());
            //    }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                       

                        return;
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [OutPutOfPrograms] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
            }


            }
        [TestMethod]
        public void UpdateOffers()
            {
          
            string OfferId = "36445435465";
            EbaySdkLib.Messages.UpdateInventoryOfferRequest updateInventoryOfferRequest = new EbaySdkLib.Messages.UpdateInventoryOfferRequest();
            updateInventoryOfferRequest.categoryId = "30120";
            updateInventoryOfferRequest.availableQuantity = 75;
            updateInventoryOfferRequest.listingPolicies = new ListingPolicies()
            {
                paymentPolicyId = "37967344010",
                returnPolicyId = "37967343010"
            };
            updateInventoryOfferRequest.pricingSummary = new PricingSummary()
            {
                price = new Amount()
                {
                    currency = EbaySdkLib.Models.CurrencyCodeEnum.USD,
                    value = "260.00"

                }

            };

            var response = _inventoryApiService.updateOffersService(updateInventoryOfferRequest, OfferId).Result;
            if (response.Item2.ToString() == "OK")
                {
                Assert.IsNotNull(response.Item1);
                }
            else
                {
                Assert.Fail(response.Item2.ToString());
                };
            }

        [TestMethod]
        public void getOffers()
            {
                string token = UsingTokenMethod();
                InventoryApiService _inventoryApiService = new InventoryApiService(token);
            string sku = "3455632452345";
            var response = _inventoryApiService.getOffersService(sku).Result;
            //if (response.Item2.ToString() == "OK")
            //    {
            //    Assert.IsNotNull(response.Item1);
            //    }
            //else
            //    {
            //    Assert.Fail(response.Item2.ToString());
            //    }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        foreach (EbaySdkLib.Models.Offer _offers in response.Item1.offers)
                        {

                               int offerDBID = SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_GetOffers(_cstr, _offers.offerId, _offers.sku, _offers.marketplaceId, _offers.format, _offers.availableQuantity, _offers.categoryId, _offers.quantityLimitPerBuyer, _offers.status);
                               SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_ListingOffers(_cstr, offerDBID, _offers.listing.listingId, _offers.listing.listingStatus, _offers.listing.soldQuantity);
                               SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_ListingPolicies(_cstr, offerDBID, _offers.listingPolicies.paymentPolicyId, _offers.listingPolicies.returnPolicyId,_offers.pricingSummary.price.currency, _offers.pricingSummary.price.value);
                        }
                        
                        return;
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [OutPutOfPrograms] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
            }




            }

        [TestMethod]
        public void getOffer()
            {
                string token = UsingTokenMethod();
                InventoryApiService _inventoryApiService = new InventoryApiService(token);
            string offerId = "36445435465";
            var response = _inventoryApiService.getOfferService(offerId).Result;
            //if (response.Item2.ToString() == "OK")
            //    {
            //    Assert.IsNotNull(response.Item1);
            //    }
            //else
            //    {
            //    Assert.Fail(response.Item2.ToString());
            //    }

            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        int offerDBID = SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_GetOffer(_cstr, response.Item1.offerId, response.Item1.sku, response.Item1.marketplaceId, response.Item1.format, response.Item1.availableQuantity, response.Item1.categoryId, response.Item1.quantityLimitPerBuyer, response.Item1.status);
                        SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_ListingOffer(_cstr, offerDBID, response.Item1.listing.listingId, response.Item1.listing.listingStatus, response.Item1.listing.soldQuantity, response.Item1.listingPolicies.paymentPolicyId, response.Item1.listingPolicies.returnPolicyId, response.Item1.pricingSummary.price.currency, response.Item1.pricingSummary.price.value);
                        return;
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [OutPutOfPrograms] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
            }

            }
        [TestMethod]
        public void deleteOffer()
            {
          
            string offerId = "3455632452345";
            var response = _inventoryApiService.deleteOffersService(offerId).Result;
            if (response.Item2.ToString() == "OK")
                {
                Assert.IsNotNull(response.Item1);
                }
            else
                {
                Assert.Fail(response.Item2.ToString());
                }
            }
        [TestMethod]
        public void publishOffer()
            {
          
            string offerId = "36445435465";
            var response = _inventoryApiService.publishOfferService(offerId).Result;
            Assert.IsNotNull(response);
            Assert.Fail();
            }
        [TestMethod]
        public void getListingFees()
         {
            string token = UsingTokenMethod();
            InventoryApiService _inventoryApiService = new InventoryApiService(token);
            string get_listing_fees = "get_listing_fees";
            var response = _inventoryApiService.getListingFeesService(get_listing_fees).Result;
            if (response.Item2.ToString() == "OK")
                {
                Assert.IsNotNull(response.Item1);
                }
             else
                {
                Assert.Fail(response.Item2.ToString());
                }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        foreach (EbaySdkLib.Models.FeeSummary _fs in response.Item1.feeSummaries)
                        {

                            int feeDBID = SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_GetListFee(_cstr, _fs.marketplaceId);
                        
                        foreach (EbaySdkLib.Models.Fee _fee in _fs.fees)
                        {
                            SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_FeeDetails(_cstr, feeDBID, _fee.amount.currency, _fee.amount.value, _fee.feeType);
                        } 
                        
                        }
                        return;
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [OutPutOfPrograms] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
            }

            }
        [TestMethod]
        public void publishOfferByInventoryItemGroup()
            {
          
            string get_listing_fees = "get_listing_fees";
            var response = _inventoryApiService.publishOfferByInventoryItemGroupService(get_listing_fees).Result;
            if (response.Item2.ToString() == "OK")
                {
                Assert.IsNotNull(response.Item1);
                }
            else
                {
                Assert.Fail(response.Item2.ToString());
                }
            }


        [TestMethod]
        public void WithdrawOrder()
            {
          
            string Listing_Id = "3455632452346";
            var response = _inventoryApiService.WithdrawOfferService(Listing_Id).Result;
            if (response.Item2.ToString() == "OK")
                {
                Assert.IsNotNull(response.Item1);
                }
            else
                {
                Assert.Fail(response.Item2.ToString());
                }
            }

        #endregion

        #region InventoryItems
        [TestMethod]
        public void getInventoryItem()
            {
                try
                {
                    string token = UsingTokenMethod();
                    InventoryApiService _inventoryApiService = new InventoryApiService(token);
                    string sku = "GP-Cam-01";
                    var response = _inventoryApiService.getInventoryItemService(sku).Result;
                    //if (response.Item2.ToString() == "OK")
                    //    {
                    //    Assert.IsNotNull(response.Item1);
                    //    }
                    //else
                    //    {
                    //    Assert.Fail(response.Item2.ToString());
                    //    }
                    switch (response.Item2)
                    {
                        case System.Net.HttpStatusCode.OK:
                            {
                                //Add to DB

                                int InventoryDBID = SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_GetInventoryItem(_cstr, response.Item1.sku, response.Item1.condition);
                                SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_InventoryProduct(_cstr, InventoryDBID, response.Item1.product.title, response.Item1.product.description, response.Item1.product.imageUrls.ToString());
                                return;

                            }

                        case System.Net.HttpStatusCode.InternalServerError:
                            {
                                throw new Exception("Internal Server Error From Api - [getInventoryItem] - " + response.Item2.ToString());

                            }
                        case System.Net.HttpStatusCode.BadRequest:
                            {
                                throw new Exception("Bad Request From Api - [getInventoryItem] - " + response.Item2.ToString());
                            }

                        default:
                            {
                                throw new Exception("Unrecognised Error Response From Api - [getInventoryItem] - " + response.Item2.ToString());

                            }
                    }

                }
                catch (Exception)
                {
                    
                    throw;
                }

            }
        [TestMethod]
        public void getInventoryItems()
            {

                string token = UsingTokenMethod();
                InventoryApiService _inventoryApiService = new InventoryApiService(token);
                var response = _inventoryApiService.getInventoryItemsService().Result;
                //if (response.Item2.ToString() == "OK")
                //   {
                //     Assert.IsNotNull(response.Item1);
                //   }
                //else
                // {
                //   Assert.Fail(response.Item2.ToString());
                // }
               switch (response.Item2)
                 {
                    case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB

                        foreach (EbaySdkLib.Models.InventoryItem _ii in response.Item1.inventoryItems)
                        {
                            int InventoryItemsDBID = SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_InventoryItems(_cstr, _ii.inventoryReferenceId, _ii.inventoryReferenceType);

                        }
                        return; 
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [getInventoryItems] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [getInventoryItems] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [getInventoryItems] - " + response.Item2.ToString());

                    }
            }


            }

        [TestMethod]
        public void deleteInventoryItem()
            {
          
            string sku = "GP-Cam-01";
            var response = _inventoryApiService.deleteInventoryItemService(sku).Result;
            if (response.Item2.ToString() == "OK")
                {
                Assert.IsNotNull(response.Item1);
                }
            else
                {
                Assert.Fail(response.Item2.ToString());
                }
            }

        [TestMethod]
        public void bulkUpdatePriceQuality()
         {
            string token = UsingTokenMethod();
            InventoryApiService _inventoryApiService = new InventoryApiService(token);
            EbaySdkLib.Messages.BulkUpdatePriceQualityRequest bulkUpdatePriceQualityRequest = new EbaySdkLib.Messages.BulkUpdatePriceQualityRequest();
            bulkUpdatePriceQualityRequest.requests = new PriceQuality[]{
                          new PriceQuality ()
                          {
                          sku="GP-Cam-01",
                          shipToLocationAvailability=new ShipToLocationAvailability (){ quantity= 25},
                         offers=new Offer[]{new Offer(){availableQuantity= 10,offerId= "3455632452395", pricingSummary=new PricingSummary { price=new Amount(){currency=EbaySdkLib.Models.CurrencyCodeEnum.GBP,value="182.0"} }
                           }
                             }
                          }
                        };

            var response = _inventoryApiService.bulkUpdatePriceQualityService(bulkUpdatePriceQualityRequest).Result;
            //if (response.Item2.ToString() == "OK")
            //    {
            //    Assert.IsNotNull(response.Item1);
            //    }
            //else
            //    {
            //    Assert.Fail(response.Item2.ToString());
            //    }
             switch (response.Item2)
                 {
                    case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB

                        foreach (EbaySdkLib.Models.PriceQuality _res in response.Item1.responses)
                        {
                            foreach (EbaySdkLib.Models.Offer _off  in _res.offers)
	                        {
                                int InventoryItemsDBID = SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_BulkPriceQuality(_cstr, _res.sku, _off.offerId, _off.status);
	                        }
                        }
                        return; 
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [bulkUpdatePriceQuality] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [bulkUpdatePriceQuality] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [bulkUpdatePriceQuality] - " + response.Item2.ToString());

                    }
            }

            }

        [TestMethod]
        public void CreateorReplaceItem()
            {
                try
                {
                    string token = UsingTokenMethod();
                    InventoryApiService _inventoryApiService = new InventoryApiService(token);
                    CreateorReplaceInventoryItemrequest createorReplaceInventoryItemrequest = new CreateorReplaceInventoryItemrequest();
                    string sku = "GP-Cam-01";
                    createorReplaceInventoryItemrequest.availability = new Availability
                    {
                        shipToLocationAvailability = new ShipToLocationAvailability()
                        {
                            quantity = 50
                        }
                    };
                    createorReplaceInventoryItemrequest.condition = EbaySdkLib.Enums.ConditionEnum.NEW;
                    createorReplaceInventoryItemrequest.product = new Product()
                    {
                        title = "GoPro Hero4 Helmet Cam",
                        description = "New GoPro Hero4 Helmet Cam. Unopened box."
                    };

                    var response = _inventoryApiService.CreateorReplaceItemService(createorReplaceInventoryItemrequest, sku).Result;
                    //if (response.Item2.ToString() == "OK")
                    //    {
                    //    Assert.IsNotNull(response.Item1);
                    //    }
                    //else
                    //    {
                    //    Assert.Fail(response.Item2.ToString());
                    //    }

                    switch (response.Item2)
                    {
                        case System.Net.HttpStatusCode.OK:
                            {
                                //Add to DB

                                 int InventoryDBID = SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_CreateorReplaceItem(_cstr,response.Item1.condition,response.Item1.availability.shipToLocationAvailability.quantity);
                                 foreach (EbaySdkLib.Models.Product  _IP in response.Item1.product)
                                 {
                                     foreach (EbaySdkLib.Models.AspectValues _AsV in  _IP.aspects )
                                     {
                                         SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_ProductDetails(_cstr,InventoryDBID, _IP.description, _IP.title, _IP.brand, _IP.ean, _IP.imageUrls);   
                                     }
                                 }

                                return;
                            }

                        case System.Net.HttpStatusCode.InternalServerError:
                            {
                                throw new Exception("Internal Server Error From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                            }
                        case System.Net.HttpStatusCode.BadRequest:
                            {
                                throw new Exception("Bad Request From Api - [OutPutOfPrograms] - " + response.Item2.ToString());
                            }

                        default:
                            {
                                throw new Exception("Unrecognised Error Response From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                            }
                    }
                }
                catch (Exception ex)
                {
                    
                    throw;
                }

            }
        #endregion

        #region InventoryItemGrp

        [TestMethod]
        public void createorReplceItemGroup()
         {
            string token = UsingTokenMethod();
            InventoryApiService _inventoryApiService = new InventoryApiService(token);
            CreateOrReplaceinventoryItemGrpRequest createorReplaceInventoryItemrequest = new CreateOrReplaceinventoryItemGrpRequest();
            string inventoryItemGroupKey = "Mens_Solid_Polo_Shirts";
            createorReplaceInventoryItemrequest.variantSKUs = new string[]
            {
                "MSPS-GrS",
                "MSPS-GrM",
                "MSPS-GrL",
                "MSPS-GrXL",
                "MSPS-BlS",
                "MSPS-BlM",
                "MSPS-BlL",
                "MSPS-BlXL",
                "MSPS-RdS",
                "MSPS-RdM",
                "MSPS-RdL",
                "MSPS-RdXL",
                "MSPS-BkS",
                "MSPS-BkM",
                "MSPS-BkL"
            };
            var response = _inventoryApiService.CreateorReplaceItemgrpProdService(createorReplaceInventoryItemrequest, inventoryItemGroupKey).Result;
            //if (response.Item2.ToString() == "OK")
            //    {
            //    Assert.IsNotNull(response.Item1);
            //    }
            //else
            //    {
            //    Assert.Fail(response.Item2.ToString());
            //    }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                       // int createorReplaceDbID = SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_createorReplceItemGroup(_cstr, response.Item1., response.Item1.title, response.Item1.description);
                        return;
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [OutPutOfPrograms] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
            }

            }

        [TestMethod]
        public void getInventoryItemGroup()
            {
            string token = UsingTokenMethod();
            InventoryApiService _inventoryApiService = new InventoryApiService(token);
            string inventoryItemGroupKey = "Mens_Solid_Polo_Shirts";
            var response = _inventoryApiService.getInventoryItemGroupService(inventoryItemGroupKey).Result;
            //if (response.Item2.ToString() == "OK")
            //    {
            //    Assert.IsNotNull(response.Item1);
            //    }
            //else
            //    {
            //    Assert.Fail(response.Item2.ToString());
            //    }

            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        int offerDBID = SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_GetItemGroup(_cstr,response.Item1.inventoryItemGroupKey,response.Item1.title,response.Item1.description);
                        return;
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [OutPutOfPrograms] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [OutPutOfPrograms] - " + response.Item2.ToString());

                    }
            }


            }
        [TestMethod]
        public void deleteInventoryItemGroup()
            {
          
            string inventoryItemGroupKey = "Mens_Solid_Polo_Shirts";
            var response = _inventoryApiService.deleteInventoryItemgrpService(inventoryItemGroupKey).Result;
            if (response.Item2.ToString() == "OK")
                {
                Assert.IsNotNull(response.Item1);
                }
            else
                {
                Assert.Fail(response.Item2.ToString());
                }
            }
        #endregion

        #region Listing

        [TestMethod]
        public void bulkMigrateListing()
            {
                try
                {

                    string token = UsingTokenMethod();
                    InventoryApiService _inventoryApiService = new InventoryApiService(token);
                    BulkMigrateListingRequest bulkMigrateListingRequest = new BulkMigrateListingRequest();
                    bulkMigrateListingRequest.requests = new MigrateListRequest[]
            {
                new MigrateListRequest()
                {
                    listingId="160009220563"
                },
                new MigrateListRequest()
                {
                    listingId="160009220564"
                },
                new MigrateListRequest()
                {
                    listingId="160009220565"
                }

            };
                    var response = _inventoryApiService.bulkMigrateListingService(bulkMigrateListingRequest).Result;
                    //if (response.Item2.ToString() == "OK")
                    //    {
                    //    Assert.IsNotNull(response.Item1);
                    //    }
                    //else
                    //    {
                    //    Assert.Fail(response.Item2.ToString());
                    //    }

                    switch (response.Item2)
                    {
                        case System.Net.HttpStatusCode.OK:
                            {
                                //Add to DB
                                foreach (EbaySdkLib.Models.MigrateListingRespons _list in response.Item1.responses)
                                {
                                    int InventoryItemsDBID = SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_bulkMigrateListing(_cstr, _list.statusCode, _list.listingId, _list.marketplaceId, _list.inventoryItemGroupKey);
                                }
                                return;

                            }

                        case System.Net.HttpStatusCode.InternalServerError:
                            {
                                throw new Exception("Internal Server Error From Api - [BulkMigrateListing] - " + response.Item2.ToString());

                            }
                        case System.Net.HttpStatusCode.BadRequest:
                            {
                                throw new Exception("Bad Request From Api - [BulkMigrateListing] - " + response.Item2.ToString());
                            }

                        default:
                            {
                                throw new Exception("Unrecognised Error Response From Api - [BulkMigrateListing] - " + response.Item2.ToString());

                            }
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }

            }
        
        #endregion

        #region ProdCompatibility
        [TestMethod]
        public void CreateOrReplaceProductCompatibilityService()
            {
            string token = UsingTokenMethod();
            InventoryApiService _inventoryApiService = new InventoryApiService(token);
            CreateOrReplaceProductCompatibilityRequest createOrReplaceProductCompatibilityRequest = new CreateOrReplaceProductCompatibilityRequest();
            string sku = "Al-8730";
            createOrReplaceProductCompatibilityRequest.compatibleProducts = new CompatibleProduct[]{
                new CompatibleProduct(){
                productFamilyProperties=new ProductFamilyProperties()
                {
                make="Subaru",
                model ="DL",
                year="1982",
                trim="Base Wagon 4-Door",
                engine= "1.8L 1781CC H4 GAS SOHC Naturally Aspirated"
                },
                notes="Equivalent to AC Delco Alternator"
                }

            };
            var response = _inventoryApiService.CreateOrReplaceProductCompatibilityService(createOrReplaceProductCompatibilityRequest, sku).Result;
            //if (response.Item2.ToString() == "OK")
            //    {
            //    Assert.IsNotNull(response.Item1);
            //    }
            //else
            //    {
            //    Assert.Fail(response.Item2.ToString());
            //    }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        return;
                       
                      
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [CreateOrReplaceProductCompatibilityService] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [CreateOrReplaceProductCompatibilityService] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [CreateOrReplaceProductCompatibilityService] - " + response.Item2.ToString());

                    }
            }

            }
        [TestMethod]
        public void getProdCompatibility()
          {
            string token = UsingTokenMethod();
            InventoryApiService _inventoryApiService = new InventoryApiService(token);
            string sku = "Al-8730";
            var response = _inventoryApiService.getProductCompatibilityService(sku).Result;
            //if (response.Item2.ToString() == "OK")
            //    {
            //    Assert.IsNotNull(response.Item1);
            //    }
            //else
            //    {
            //    Assert.Fail(response.Item2.ToString());
            //    }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB

                        foreach (EbaySdkLib.Models.CompatibleProduct _PCom in response.Item1.compatibleProducts)
                        {
                            int InventoryItemsDBID = SellingTools_Lib.DBConnect.DA_Ebay_Inventory.Add_GetProdCompatibility(_cstr, response.Item1.sku, _PCom.notes, _PCom.productFamilyProperties.make, _PCom.productFamilyProperties.model, _PCom.productFamilyProperties.engine, _PCom.productFamilyProperties.trim, _PCom.productFamilyProperties.year);
                           
                        }
                        return;
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [GetProdCompatibility] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [GetProdCompatibility] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [GetProdCompatibility] - " + response.Item2.ToString());

                    }
            }

            }
        [TestMethod]
        public void deleteProdCompatibility()
            {
          
            string sku = "Al-8730";
            var response = _inventoryApiService.deleteProductCompatibilityService(sku).Result;
            if (response.Item2.ToString() == "OK")
                {
                Assert.IsNotNull(response.Item1);
                }
            else
                {
                Assert.Fail(response.Item2.ToString());
                }
            }

        #endregion
        }
    }
