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
    class AnalyticsServiceTest
        {
        AnalyticsService _analyticsService;
        public string Token { get; set; }
        [TestInitialize]
        public void Setup()
            {
        Token = ConfigurationManager.AppSettings["token"];
        _analyticsService = new AnalyticsService(Token);

            }
        [TestMethod]
        public void getTrafficreport()
            {
          
            string filter = "marketplace_ids:%7BEBAY_US%7D,date_range:%5B20161007..20161009%5D";
            string dimension = "LISTING";
            string metric = "LISTING_IMPRESSION_SEARCH_RESULTS_PAGE,LISTING_IMPRESSION_STORE,SALES_CONVERSION_RATE";
            string sort = "LISTING_IMPRESSION_STORE";
            // GetTrafficReportResponse response = analyticsService.getAnalyticsService(filter, dimension, metric, sort).Result;
           var response = _analyticsService.getAnalyticsService(filter, dimension, metric, sort).Result;
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
        public void findSellerStandardsProfile()
            {
          
            //Return status is 200, but there is issue in response
           var response = _analyticsService.findSellerStandardsProfilesResponseAnalyticsService().Result;
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
        public void getSellerAnalytics()
            {
          
            getSellerStandardsProfileResponse getSellerStandards = new getSellerStandardsProfileResponse();
            getSellerStandards.program = EbaySdkLib.Enums.ProgramEnum.PROGRAM_DE;
            string cycle = "CURRENT";
           var response = _analyticsService.getSellerStandards(getSellerStandards, cycle).Result;
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
