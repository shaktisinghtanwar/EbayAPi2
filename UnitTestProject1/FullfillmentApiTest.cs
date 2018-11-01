using EbaySdkLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SellingTools_Lib.DBConnect;
using SellingTools_Lib.Ebay;
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
    class FullfillmentApiTest
        {
        FulFillmentApiService _fulFillmentApiService;
        public string Token { get; set; }
        SqlConnectionStringBuilder _cstr;
        [TestInitialize]
        public void Setup()
            {
               Token = ConfigurationManager.AppSettings["token"];
              _fulFillmentApiService = new FulFillmentApiService(Token);
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
                Fullfillment.TokenCheckerPreRequest(_cstr, AccessTokenType.OAUTH);
                AccessTokenInfo at = DA_Ebay_Fullfillment.Get_AccessTokenInfo(_cstr, AccessTokenType.OAUTH);
                token = at.AccessToken;
            }
            catch (Exception er)
            {
                throw er;
            }
            return token;
        }


        [TestMethod]
        public void GetOrderTest()
            {

        EbaySdkLib.Messages.GetOrderRequest getOrderRequest = new EbaySdkLib.Messages.GetOrderRequest();
        string orderId = "6498414015!260000000562911";
        var response = _fulFillmentApiService.OrderService.GetOrder(orderId).Result;
        if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }

            }
        [TestMethod]
        public void GetOrdersTest()
        {
        string token = UsingTokenMethod();
        FulFillmentApiService _fulFillmentApiService = new FulFillmentApiService(token);
        EbaySdkLib.Messages.GetOrdersRequest getOrdersRequest = new EbaySdkLib.Messages.GetOrdersRequest();
        string filter = "%5B2016-09-29T15:05:43.026Z..%5D";
        string limit = "50";
        string offset = "0";
        string orderIds = "6498414015!260000000562911";
        var response = _fulFillmentApiService.OrderService.GetOrders(filter, limit, offset).Result;
       // if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
        switch (response.Item2)
        {
            case System.Net.HttpStatusCode.OK:
                {
                    //Add to DB
                    foreach (EbaySdkLib.Models.Order _fp in response.Item1.orders)
                    {
                        //int getOrderDBID = SellingTools_Lib.DBConnect.DA_Ebay_Fullfillment.Add_GetOrder(_cstr, _fp., _fp.marketplaceId.ToString(), int.Parse(_fp.handlingTime.value), _fp.handlingTime.unit.ToString());

                        //foreach (EbaySdkLib.Models.CategoryType _ct in _fp.categoryTypes)
                        //{
                        //    SellingTools_Lib.DBConnect.DA_Ebay_Fullfillment.Add_FPCategoryType(_cstr, FulfillmentDBID, _ct.name.ToString(), _ct.@default);
                        //}

                        
                    }

                    return;

                }

            case System.Net.HttpStatusCode.InternalServerError:
                {
                    throw new Exception("Internal Server Error From Api - [GetFulfillmentPolicies] - " + response.Item2.ToString());

                }
            case System.Net.HttpStatusCode.BadRequest:
                {
                    throw new Exception("Bad Request From Api - [GetFulfillmentPolicies] - " + response.Item2.ToString());
                }

            default:
                {
                    throw new Exception("Unrecognised Error Response From Api - [GetFulfillmentPolicies] - " + response.Item2.ToString());

                }
        }   
        }


        [TestMethod]
        public void CreateShippingFullfilmentTest()
            {

        EbaySdkLib.Messages.CreateShippingFulfillmentRequest createShippingFulfillmentRequest = new EbaySdkLib.Messages.CreateShippingFulfillmentRequest();
        string orderId = "6498414015!260000000562911";
        createShippingFulfillmentRequest.lineItems = new EbaySdkLib.Models.LineItem[]  {
               new  EbaySdkLib.Models.LineItem(){
                lineItemId = "6254458011",
                quantity = 1
                                }
               };
        createShippingFulfillmentRequest.shippedDate = "2016-07-20T00:00:00.000Z";
        createShippingFulfillmentRequest.shippingCarrierCode = "USPS";
        createShippingFulfillmentRequest.trackingNumber = "1Z50992656936";
        var response = _fulFillmentApiService.OrderService.CreateShippingFullfilment(createShippingFulfillmentRequest, orderId).Result;
        if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }

            }
        [TestMethod]
        public void GetShippingFulfillmentTest()
            {

        EbaySdkLib.Messages.GetShippingFulfillmentRequest getShippingFulfillmentRequest = new EbaySdkLib.Messages.GetShippingFulfillmentRequest();
        string fulfillmentId = "1Z50992656936";
        string orderid = "6498414015!260000000562911";
        var response = _fulFillmentApiService.OrderService.GetShippingFulfillment(fulfillmentId, orderid).Result;
        if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }

            }
        [TestMethod]
        public void GetShippingFulfillmentsTest()
            {

        EbaySdkLib.Messages.GetShippingFulfillmentsRequest getShippingFulfillmentsRequest = new EbaySdkLib.Messages.GetShippingFulfillmentsRequest();
        string orderid = "6498414015!260000000562911";
        var response = _fulFillmentApiService.OrderService.GetShippingFulfillments(orderid).Result;
        if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }

            }


        }


    }

