using EbaySdkLib;
using EbaySdkLib.Enums;
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
    public class TaxonomyApiServiceTests
        {
        TaxonomyApiService _taxonomyApiService;
        public string Token { get; set; }
        [TestInitialize]
        public void Setup()
            {
        Token = ConfigurationManager.AppSettings["token"];
        _taxonomyApiService = new TaxonomyApiService(Token);

            }
        [TestMethod]
        public void getCategoryTree()
            {

       // var request = new GetCategoryTreeRequest();
        var response = _taxonomyApiService.GetCategoryTree().Result;
        Assert.IsNotNull(response);
            }
        [TestMethod]
        public void getCategorySubtree()
            {

        var request = new GetCategorySubtreeRequest();
        //request.category_id = "11450";
        var response = _taxonomyApiService.GetCategorySubtree(request).Result;
        if (response.Item2.ToString() == "OK")
            { Assert.IsNotNull(response.Item1); }
            else
                {
                Assert.Fail(response.Item2.ToString());
                }
            
            }
        [TestMethod]
        public void getCategorySuggestions()
            {
        var request = new GetCategorySuggestionsRequest();
       // request.q = new object[] { "IPhone" };
        var response = _taxonomyApiService.GetCategorySuggestions(request).Result;
       if (response.Item2.ToString() == "OK")
            { Assert.IsNotNull(response.Item1); }
            else
                {
                Assert.Fail(response.Item2.ToString());
                }
            }
            

        [TestMethod]
        public void GetDefaultCategoryTreeIdTest()
            {

        var request = new GetDefaultCategoryTreeIdRequest();
        request.marketplace_id = MarketplaceIdEnum.EBAY_US;
        string Id = request.marketplace_id.ToString();
        var response = _taxonomyApiService.GetDefaultCategoryTreeId(request).Result;
        if (response.Item2.ToString() == "OK")
        { Assert.IsNotNull(response.Item1); }
        else
            {
        Assert.Fail(response.Item2.ToString());
            }
            }

        [TestMethod]
        public void GetItemAspectsForCategoryTest()
            {

        var request = new GetItemAspectsForCategoryRequest();
        request.category_id = "";
        request.category_tree_id = "";
        var response = _taxonomyApiService.GetItemAspectsForCategory(request).Result;
        if (response.Item2.ToString() == "OK")
        { Assert.IsNotNull(response.Item1); }
        else
            {
        Assert.Fail(response.Item2.ToString());
            }
            }
        }
    }
