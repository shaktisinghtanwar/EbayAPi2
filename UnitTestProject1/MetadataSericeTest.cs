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
    class MetadataSericeTest
        {
        MetadataAPIService _metadataAPIService;
        public string Token { get; set; }
        [TestInitialize]
        public void Setup()
            {
        Token = ConfigurationManager.AppSettings["token"];
        _metadataAPIService = new MetadataAPIService(Token);

            }
        #region MetadataApi
        [TestMethod]
        public void getSalesTaxJurisdictions()
            {
           
            string countrycode = EbaySdkLib.Enums.CountryCodeEnum.CA.ToString();
            var response = _metadataAPIService.getSalesTaxJurisdictionsService(countrycode).Result;
             if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            
            }
        [TestMethod]
        public void getAutomotivePartsCompatibilityPolicies()
            {
           
            string marketPlaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_MOTORS_US.ToString();

            string filter = System.Net.WebUtility.UrlEncode("80740|33548");
             var response = _metadataAPIService.getAutomotivePartsCompatibilityService(marketPlaceId, filter).Result;
             if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            
            }
        [TestMethod]
        public void getItemConditionPolicies()
            {
           
            string marketPlaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US.ToString();

            string filter = System.Net.WebUtility.UrlEncode("80740|33548");
             var response = _metadataAPIService.getItemConditionPoliciesService(marketPlaceId, filter).Result;
             if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            
            }

        [TestMethod]
        public void GetListingStructurePolicies()
            {
           
            string marketPlaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US.ToString();

            string filter = System.Net.WebUtility.UrlEncode("75592|90638");
             var response = _metadataAPIService.GetListingStructurePoliciesService(marketPlaceId, filter).Result;
             if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
           
            }
        [TestMethod]
        public void getNegotiatedPricePolicies()
            {
           
            string marketPlaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US.ToString();

            string filter = System.Net.WebUtility.UrlEncode("75592|90638");
             var response = _metadataAPIService.getNegotiatedPricePoliciesService(marketPlaceId, filter).Result;
             if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
           
            }
        [TestMethod]
        public void getProductAdoptionPolicies()
            {
           
            string marketPlaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US.ToString();

            string filter = System.Net.WebUtility.UrlEncode("75592|90638");
             var response = _metadataAPIService.getProductAdoptionPoliciesService(marketPlaceId, filter).Result;
             if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
           
            }
        [TestMethod]
        public void getReurnPoliciesMetadata()
            {
           
            string marketPlaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US.ToString();

            string filter = System.Net.WebUtility.UrlEncode("80740|33548");
             var response = _metadataAPIService.metadataGetreturnPolicyService(marketPlaceId, filter).Result;
             if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            
            }

        #endregion
        }
    }
