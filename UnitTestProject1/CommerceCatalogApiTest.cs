using EbaySdkLib.Messages;
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
    class CommerceCatalogApiTest
        {
        CatalogService _catalogService;
        public string Token { get; set; }
        [TestInitialize]
        public void Setup()
            {
        Token = ConfigurationManager.AppSettings["token"];
        _catalogService = new CatalogService(Token);

            }
        [TestMethod]
        public void getProductResponseTest()
            {
            

            string epid = "232669172";
            var response = _catalogService.getProductResponse(epid).Result;
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
        public void productSummarySearchResponse()
            {
            

            string q = "232669172";
            //GetProductResponse response = catalogceservice.productSummarySearchResponse(q).Result;
            var response = _catalogService.productSummarySearchResponse(q).Result;
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
        public void getProductMetadataResponse()
            {
            

            string epid = "242755377";
            var response = _catalogService.productSummarySearchResponse(epid).Result;
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
        public void getProductMetadataForCategoriesResponse()
            {
            

            string primary_category_id = "500";
            var response = _catalogService.getProductMetadataForCategoriesResponse(primary_category_id).Result;
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
        public void getChangeRequestResponse()
            {
            

            string change_request_id = "5ac3cf22ca4c591b0c324749";
            var response = _catalogService.getChangeRequestResponse(change_request_id).Result;
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
        public void getChangeRequestsResponse()
            {
            

            var response = _catalogService.getChangeRequestsResponse().Result;
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
        public void createChangeRequestsResponse()
            {
            
            CreateChangeRequest changerequest = new CreateChangeRequest();
            changerequest.changeRequestType = EbaySdkLib.Enums.ChangeRequestTypeEnum.PRODUCT_UPDATE;
            changerequest.suggestedProduct = new SuggestedProduct()
            {
                primaryCategoryId = "9355"
            };
            var response = _catalogService.createChangeRequestService(changerequest).Result;
            if (response.Item2.ToString() == "OK")
                {
                Assert.IsNotNull(response.Item1);
                }
            else
                {
                Assert.Fail(response.Item2.ToString());
                }
            }

        }
    }
