using EbaySdkLib;
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
    class FullfillmentApiTest
        {
        FulFillmentApiService _fulFillmentApiService;
        public string Token { get; set; }
        [TestInitialize]
        public void Setup()
            {
        Token = ConfigurationManager.AppSettings["token"];
        _fulFillmentApiService = new FulFillmentApiService(Token);

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

        EbaySdkLib.Messages.GetOrdersRequest getOrdersRequest = new EbaySdkLib.Messages.GetOrdersRequest();
        string filter = "%5B2016-09-29T15:05:43.026Z..%5D";
        string limit = "50";
        string offset = "0";
        string orderIds = "6498414015!260000000562911";
        var response = _fulFillmentApiService.OrderService.GetOrders(filter, limit, offset).Result;
        if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
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

