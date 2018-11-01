using EbaySdkLib.Messages;
using EbaySdkLib.Services;
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
    class CpmplianceAPIServiceTest
        {
        ComplianceService _complianceService;
        SqlConnectionStringBuilder _cstr;
        public string Token { get; set; }
        [TestInitialize]
        public void Setup()
            {
        Token = ConfigurationManager.AppSettings["token"];
        _complianceService = new ComplianceService(Token);
        _cstr = new SqlConnectionStringBuilder();
        _cstr.DataSource = "DESKTOP-4SQEA0V\\SQLEXPRESS2012";
        _cstr.InitialCatalog = "Ebay_Api";
        _cstr.IntegratedSecurity = true;
        _cstr.TrustServerCertificate = true;
            }
        public string UsingTokenMethod()
        {
            string token = "";
            try
            {
                Compliance.TokenCheckerPreRequest(_cstr, AccessTokenType.OAUTH);
                AccessTokenInfo at = DA_Ebay_Compliance.Get_AccessTokenInfo(_cstr, AccessTokenType.OAUTH);
                token = at.AccessToken;
            }
            catch (Exception er)
            {
                throw er;
            }
            return token;
        }

        [TestMethod]
        public void getListingViolationsSummary()
            {
                try
                {
                    string Token = UsingTokenMethod();
                    ComplianceService _complianceService = new ComplianceService(Token);
                    string compliance_type = "PRODUCT_ADOPTION";
                    // GetListingViolationsSummaryResponse response = complainceservice.getListingViolationsSummary(compliance_type).Result;
                    var response = _complianceService.getListingViolationsSummary(compliance_type).Result;
                    //   if (response.Item2.ToString() == "OK")
                    //    {
                    //    Assert.IsNotNull(response.Item1);
                    //    }
                    //else
                    //    {
                    //    Assert.Fail(response.Item2.ToString());
                    //    }
                    foreach (EbaySdkLib.Models.ViolationSummary   _vs  in response.Item1.violationSummaries)
                    {
                        int ListingViolationsSummaryDBID = SellingTools_Lib.DBConnect.DA_Ebay_Compliance.Add_GetListingViolationsSummary(_cstr, _vs.complianceType, _vs.listingCount,_vs.marketplaceId.ToString());


                       
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }

        [TestMethod]
        public void getListingViolations()
            {
                try
                {
                    string Token = UsingTokenMethod();
                    ComplianceService _complianceService = new ComplianceService(Token);
                    string compliance_type = EbaySdkLib.Enums.ComplianceTypeEnum.PRODUCT_ADOPTION.ToString();
                    int offset = 0;
                    string listing_id = "200008552419";
                    int limit = 100;
                    //GetListingViolationsResponse response = complainceservice.getListingViolations(compliance_type, offset, listing_id, limit).Result;
                    var response = _complianceService.getListingViolations(compliance_type, offset, listing_id, limit).Result;
                    //if (response.Item2.ToString() == "OK")
                    //    {
                    //    Assert.IsNotNull(response.Item1);
                    //    }
                    //else
                    //    {
                    //    Assert.Fail(response.Item2.ToString());
                    //    }


                    foreach (EbaySdkLib.Models.ListingViolation _vs in response.Item1.listingViolations)
                    {
                        int ListingViolationsDBID = SellingTools_Lib.DBConnect.DA_Ebay_Compliance.Add_GetListingViolations(_cstr, _vs.complianceType, _vs.listingId);

                        foreach (EbaySdkLib.Models.Violation _vio in _vs.violations)
                        {
                            SellingTools_Lib.DBConnect.DA_Ebay_Compliance.Add_Violations(_cstr, ListingViolationsDBID, _vio.reasonCode, _vio.message);
                        }

                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }

        }
    }
