using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using EbaySdkLib;
using EbaySdkLib.Models;
using EbaySdkLib.Messages;
using EbaySdkLib.Enums;
using EbaySdkLib.Services;
using System.Configuration;
using System.Data.SqlClient;
using EbaySdkLib;
using SellingTools_Lib.Enums;
using SellingTools_Lib.Models;
using SellingTools_Lib.DBConnect;
using SellingTools_Lib;

namespace UnitTestProject1
    {
    [TestClass]
    public class _accountServiceTests
        {
        AccountService _accountService;
        SqlConnectionStringBuilder _cstr;
        public string Token { get; set; }

        [TestInitialize]
        public void Setup()
            {
            Token = ConfigurationManager.AppSettings["token"]; 
            _accountService = new AccountService(Token);
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
             int insertoken= SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_InsertTokenDetails(_cstr,"Auth", response.AccessToken,response.RefreshToken,response.ExpiredTime,response.RefreshTokenExpires);

        }
       


        [TestMethod]
        public void GetRefreshTokenTest()
        {
            string ExpiredAccessToken = "";
            GetAccessTokenService getAccessTokenService = new GetAccessTokenService();
            var response = getAccessTokenService.GetRefreshToken(ExpiredAccessToken).Result;

            Assert.IsNotNull(response);
            int insertoken = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_RefreshTokenDetails(_cstr, "Auth", response.AccessToken, response.RefreshToken, response.ExpiredTime, response.RefreshTokenExpires);
        }

        #region FulffillmentPolicy
        [TestMethod]
        public void DeleteFulfillmentPolicyTest()
        {
            EbaySdkLib.Messages.DeleteFulfillmentPolicyRequest deleteFulfillmentPolicyRequest = new EbaySdkLib.Messages.DeleteFulfillmentPolicyRequest();
            deleteFulfillmentPolicyRequest.fulfillmentPolicyId = "5446309000";
            string fulfillmentPolicyId = deleteFulfillmentPolicyRequest.fulfillmentPolicyId;
            var response = _accountService.FulfilmentPolicyService.DeleteFulfillmentPolicy(fulfillmentPolicyId).Result; if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            if (response.Item2.ToString() == "OK")
            { Assert.IsNotNull(response.Item1); }
            else
            {
                Assert.Fail(response.Item2.ToString());
            }

            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        int FulfillmentDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_FPDeleteFulfillmentPolicy(_cstr, "Delete Successfully");
                    }

                    return;

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [DeleteFulfillmentPolicy] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [DeleteFulfillmentPolicy] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [DeleteFulfillmentPolicy] - " + response.Item2.ToString());

                    }
            }
        }
        [TestMethod]
        public void CreateFulfillmentPolicyTest()
            {

            string token = UsingTokenMethod();
            EbaySdkLib.AccountService _accountService = new AccountService(token);
            EbaySdkLib.Messages.CreateFulfillmentRequest createFulfillmentRequest = new EbaySdkLib.Messages.CreateFulfillmentRequest();
            createFulfillmentRequest.categoryTypes = new EbaySdkLib.Models.CategoryType[] { new EbaySdkLib.Models.CategoryType() { name = CategoryTypeEnum.ALL_EXCLUDING_MOTORS_VEHICLES } };
            createFulfillmentRequest.name = "Domestic free shipping";
            createFulfillmentRequest.handlingTime = new EbaySdkLib.Models.TimeDuration()
            {
                value = "1",
                unit = EbaySdkLib.Models.TimeDurationUnitEnum.DAY
            };
            createFulfillmentRequest.shippingOptions = new EbaySdkLib.Models.ShippingOption[]{
                new EbaySdkLib.Models.ShippingOption()
                {
                    costType= EbaySdkLib.Models.ShippingCostTypeEnum.FLAT_RATE,
            optionType=EbaySdkLib.Models.ShippingOptionTypeEnum.DOMESTIC,
            shippingServices = new EbaySdkLib.Models.ShippingService[]{ new EbaySdkLib.Models.ShippingService()
                {
                    buyerResponsibleForShipping= "false",
                    freeShipping= "true",
                    shippingCarrierCode="USPS",
                    shippingServiceCode="USPSPriorityFlatRateBox"
                } }
                }
            };

            var response = _accountService.FulfilmentPolicyService.CreateFulfillmentPolicy(createFulfillmentRequest).Result;
            if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); }
            else { Assert.Fail(response.Item2.ToString()); }

            Assert.IsNotNull(response);
            // Assert.AreEqual(response.marketplaceId);
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        int FulfillmentDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_FPCreateFulfillmentPolicy(_cstr, response.Item1.name, response.Item1.marketplaceId.ToString(), int.Parse(response.Item1.handlingTime.value), response.Item1.handlingTime.unit.ToString());

                        foreach (EbaySdkLib.Models.CategoryType _ct in response.Item1.categoryTypes)
                        {
                            SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_FPCategoryType(_cstr, FulfillmentDBID, _ct.name.ToString(), _ct.@default);
                        }

                        foreach (EbaySdkLib.Models.ShippingOption _so in response.Item1.shippingOptions)
                        {
                            foreach (EbaySdkLib.Models.ShippingService _ss in _so.shippingServices)
                            {

                                SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_FPShippingServices(_cstr, FulfillmentDBID, _so.optionType.ToString(), _so.costType.ToString(), int.Parse(_ss.sortOrder), _ss.shippingCarrierCode, _ss.shippingServiceCode, _ss.shippingCost.value.ToString(), _ss.shippingCost.currency.ToString(),
                                        _ss.additionalShippingCost.value.ToString(), _ss.additionalShippingCost.currency.ToString(), bool.Parse(_ss.freeShipping.ToString()), bool.Parse(_ss.buyerResponsibleForShipping), bool.Parse(_ss.buyerResponsibleForPickup), bool.Parse(_so.insuranceOffered), _so.insuranceFee.value.ToString(), _so.insuranceFee.currency.ToString(), bool.Parse(response.Item1.globalShipping), response.Item1.pickupDropOff, bool.Parse(response.Item1.freightShipping), response.Item1.fulfillmentPolicyId);
                            }
                        }
                    }

                    return;



                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [CreateFulfillmentPolicy] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [CreateFulfillmentPolicy] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [CreateFulfillmentPolicy] - " + response.Item2.ToString());

                    }
            }

            }


        [TestMethod]
        public void GetFulfilmentPolicies()
          {
            string token = UsingTokenMethod();
            EbaySdkLib.AccountService _accountService = new AccountService(token);
            EbaySdkLib.Messages.GetFulfilmentPoliciesRequest createFulfillmentRequest = new EbaySdkLib.Messages.GetFulfilmentPoliciesRequest();
            createFulfillmentRequest.marketplaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US.ToString();
            string Id = createFulfillmentRequest.marketplaceId.ToString();
            var response = _accountService.FulfilmentPolicyService.GetFulfilmentPolicies(Id).Result;
            if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        foreach (EbaySdkLib.Models.FulfillmentPolicy _fp in response.Item1.fulfillmentPolicies)
                        {
                            int FulfillmentDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_FPFulfillmentPolicy(_cstr, _fp.name, _fp.marketplaceId.ToString(), int.Parse(_fp.handlingTime.value), _fp.handlingTime.unit.ToString());

                            foreach (EbaySdkLib.Models.CategoryType _ct in _fp.categoryTypes)
                            {
                                SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_FPCategoryType(_cstr, FulfillmentDBID, _ct.name.ToString(), _ct.@default);
                            }

                            foreach (EbaySdkLib.Models.ShippingOption _so in _fp.shippingOptions)
                            {
                                foreach (EbaySdkLib.Models.ShippingService _ss in _so.shippingServices)
                                {

                                    SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_FPShippingServices(_cstr, FulfillmentDBID, _so.optionType.ToString(), _so.costType.ToString(), int.Parse(_ss.sortOrder), _ss.shippingCarrierCode, _ss.shippingServiceCode, _ss.shippingCost.value.ToString(), _ss.shippingCost.currency.ToString(),
                                        _ss.additionalShippingCost.value.ToString(), _ss.additionalShippingCost.currency.ToString(), bool.Parse(_ss.freeShipping.ToString()), bool.Parse(_ss.buyerResponsibleForShipping), bool.Parse(_ss.buyerResponsibleForPickup), bool.Parse(_so.insuranceOffered), _so.insuranceFee.value.ToString(), _so.insuranceFee.currency.ToString(), bool.Parse(_fp.globalShipping), bool.Parse(_fp.pickupDropOff), bool.Parse(_fp.freightShipping), _fp.fulfillmentPolicyId);
                                }
                            }
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
        public void GetfulfillmentPolicyByNameTest()
            {
            string token = UsingTokenMethod();
            EbaySdkLib.AccountService _accountService = new AccountService(token);
            EbaySdkLib.Messages.GetFulfillmentPolicyByNameRequest getFulfillmentPolicyByNameRequest = new EbaySdkLib.Messages.GetFulfillmentPolicyByNameRequest();
            getFulfillmentPolicyByNameRequest.marketplaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US;
            string Id = getFulfillmentPolicyByNameRequest.marketplaceId.ToString();

            string Name = getFulfillmentPolicyByNameRequest.name = "Domestic free shipping";
            var response = _accountService.FulfilmentPolicyService.GetFulfillmentPolicyByName(Name, Id).Result;
            if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        int FulfillmentDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_FPGetFulfillmentPolicyByName(_cstr, response.Item1.name,response.Item1.marketplaceId.ToString(), int.Parse(response.Item1.handlingTime.value), response.Item1.handlingTime.unit.ToString());

                        foreach (EbaySdkLib.Models.CategoryType _ct in response.Item1.categoryTypes)
                        {
                            SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_FPCategoryType(_cstr, FulfillmentDBID, _ct.name.ToString(), _ct.@default);
                        }

                        foreach (EbaySdkLib.Models.ShippingOption _so in response.Item1.shippingOptions)
                        {
                            foreach (EbaySdkLib.Models.ShippingService _ss in _so.shippingServices)
                            {

                                SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_FPShippingServices(_cstr, FulfillmentDBID, _so.optionType.ToString(), _so.costType.ToString(), int.Parse(_ss.sortOrder), _ss.shippingCarrierCode, _ss.shippingServiceCode, _ss.shippingCost.value.ToString(), _ss.shippingCost.currency.ToString(),
                                        _ss.additionalShippingCost.value.ToString(), _ss.additionalShippingCost.currency.ToString(), bool.Parse(_ss.freeShipping.ToString()), bool.Parse(_ss.buyerResponsibleForShipping), bool.Parse(_ss.buyerResponsibleForPickup), bool.Parse(_so.insuranceOffered), _so.insuranceFee.value.ToString(), _so.insuranceFee.currency.ToString(), bool.Parse(response.Item1.globalShipping), bool.Parse(response.Item1.pickupDropOff), bool.Parse(response.Item1.freightShipping), response.Item1.fulfillmentPolicyId);
                            }
                        }
                    }

                    return;



                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [GetFulfillmentPolicyByName] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [GetFulfillmentPolicyByName] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [GetFulfillmentPolicyByName] - " + response.Item2.ToString());

                    }
            }

            }



        [TestMethod]
        public void UpdateFulfillmentPolicyTest()
          {
            string token = UsingTokenMethod();
            EbaySdkLib.AccountService _accountService = new AccountService(token);
            EbaySdkLib.Messages.UpdateFulfillmentPolicyRequest updateFulfillmentPolicyRequest = new EbaySdkLib.Messages.UpdateFulfillmentPolicyRequest();
            string fulfillmentpolicyid = "5733606000";
            updateFulfillmentPolicyRequest.categoryTypes = new EbaySdkLib.Models.CategoryType[] { new EbaySdkLib.Models.CategoryType() { name = CategoryTypeEnum.ALL_EXCLUDING_MOTORS_VEHICLES } };
            updateFulfillmentPolicyRequest.marketplaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US;
            updateFulfillmentPolicyRequest.name = "Domestic free shipping";
            updateFulfillmentPolicyRequest.handlingTime = new EbaySdkLib.Models.TimeDuration()
            {
                value = "1",
                unit = EbaySdkLib.Models.TimeDurationUnitEnum.DAY
            };
            updateFulfillmentPolicyRequest.shippingOptions = new EbaySdkLib.Models.ShippingOption[]{
                new EbaySdkLib.Models.ShippingOption()
                {
                    costType= EbaySdkLib.Models.ShippingCostTypeEnum.FLAT_RATE,
            optionType=EbaySdkLib.Models.ShippingOptionTypeEnum.DOMESTIC,
            shippingServices = new EbaySdkLib.Models.ShippingService[]{ new EbaySdkLib.Models.ShippingService()
                {
                    buyerResponsibleForShipping= "false",
                    freeShipping= "true",
                    shippingCarrierCode="USPS",
                    shippingServiceCode="USPSPriorityFlatRateBox"
                } }
                }
            };

            var response = _accountService.FulfilmentPolicyService.UpdateFulfillmentPolicy(fulfillmentpolicyid).Result;
            if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        int FulfillmentDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_FPUpdateFulfillmentPolicy(_cstr, response.Item1.name,response.Item1.marketplaceId.ToString(), int.Parse(response.Item1.handlingTime.value), response.Item1.handlingTime.unit.ToString());

                        foreach (EbaySdkLib.Models.CategoryType _ct in response.Item1.categoryTypes)
                        {
                            SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_FPCategoryType(_cstr, FulfillmentDBID, _ct.name.ToString(), _ct.@default);
                        }

                        foreach (EbaySdkLib.Models.ShippingOption _so in response.Item1.shippingOptions)
                        {
                            foreach (EbaySdkLib.Models.ShippingService _ss in _so.shippingServices)
                            {

                                SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_FPShippingServices(_cstr, FulfillmentDBID, _so.optionType.ToString(), _so.costType.ToString(), int.Parse(_ss.sortOrder), _ss.shippingCarrierCode, _ss.shippingServiceCode, _ss.shippingCost.value.ToString(), _ss.shippingCost.currency.ToString(),
                                        _ss.additionalShippingCost.value.ToString(), _ss.additionalShippingCost.currency.ToString(), bool.Parse(_ss.freeShipping.ToString()), bool.Parse(_ss.buyerResponsibleForShipping), bool.Parse(_ss.buyerResponsibleForPickup), bool.Parse(_so.insuranceOffered), _so.insuranceFee.value.ToString(), _so.insuranceFee.currency.ToString(), bool.Parse(response.Item1.globalShipping), bool.Parse(response.Item1.pickupDropOff), bool.Parse(response.Item1.freightShipping), response.Item1.fulfillmentPolicyId);
                            }
                        }
                    }

                    return;

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [UpdateFulfillmentPolicy] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [UpdateFulfillmentPolicy] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [UpdateFulfillmentPolicy] - " + response.Item2.ToString());

                    }
            }

            }
        [TestMethod]
        public void GetFulfillmentPolicyTest()
            {
            //GetFulfillmentPolicyRequest getFulfillmentPolicyRequest = new GetFulfillmentPolicyRequest();
            string token = UsingTokenMethod();
            EbaySdkLib.AccountService _accountService = new AccountService(token);
            EbaySdkLib.Messages.GetFulfillmentPolicyRequest getFulfillmentPolicyRequest = new EbaySdkLib.Messages.GetFulfillmentPolicyRequest();
            string fulfillmentpolicyid = "5733606000";
            getFulfillmentPolicyRequest.categoryTypes = new EbaySdkLib.Models.CategoryType[] { new EbaySdkLib.Models.CategoryType() { name = CategoryTypeEnum.ALL_EXCLUDING_MOTORS_VEHICLES } };
            getFulfillmentPolicyRequest.marketplaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US;
            getFulfillmentPolicyRequest.name = "Domestic free shipping";
            getFulfillmentPolicyRequest.handlingTime = new EbaySdkLib.Models.TimeDuration()
            {
                value = "1",
                unit = EbaySdkLib.Models.TimeDurationUnitEnum.DAY
            };
            getFulfillmentPolicyRequest.shippingOptions = new EbaySdkLib.Models.ShippingOption[]{
                new EbaySdkLib.Models.ShippingOption()
                {
                    costType= EbaySdkLib.Models.ShippingCostTypeEnum.FLAT_RATE,
                  optionType=EbaySdkLib.Models.ShippingOptionTypeEnum.DOMESTIC,
            shippingServices = new EbaySdkLib.Models.ShippingService[]{ new EbaySdkLib.Models.ShippingService()
                {
                    buyerResponsibleForShipping= "false",
                    freeShipping= "true",
                    shippingCarrierCode="USPS",
                    shippingServiceCode="USPSPriorityFlatRateBox"
                } 
            }
                }
            };

            var response = _accountService.FulfilmentPolicyService.GetFulfillmentPolicy(fulfillmentpolicyid).Result; if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }


            }


        #endregion

        #region Program
        [TestMethod]
        public void GetOptedInProgramsTest()
            {
           
            try
            {
            string token = UsingTokenMethod();
            EbaySdkLib.AccountService _accountService = new AccountService(token);
            EbaySdkLib.Messages.GetOptedInProgramsRequest getOptedInProgramsRequest = new EbaySdkLib.Messages.GetOptedInProgramsRequest();
            getOptedInProgramsRequest.programs = new EbaySdkLib.Models.Program[] { new EbaySdkLib.Models.Program() { programType = ProgramTypeEnum.SELLING_POLICY_MANAGEMENT } };
            var response = _accountService.ProgramService.GetOptedprogram(getOptedInProgramsRequest).Result;
            //if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        foreach (EbaySdkLib.Models.Program _fp in response.Item1.programs)
                        {
                            int GetOptedInProgramsDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_GetOptedInPrograms(_cstr, _fp.programType);
                           
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
            catch (Exception er)
            {
                throw er;
            }

            }


        [TestMethod]
        public void OpInToProgramsTest()
            {
                string token = UsingTokenMethod();

            AccountService _accountService = new EbaySdkLib.AccountService(token);
            EbaySdkLib.Messages.OptInToProgramRequest opInProgramsRequest = new EbaySdkLib.Messages.OptInToProgramRequest();
            opInProgramsRequest.programs = new EbaySdkLib.Models.Program[] { new EbaySdkLib.Models.Program() { programType = ProgramTypeEnum.OUT_OF_STOCK_CONTROL } };
            var response = _accountService.ProgramService.OplnToprogram(opInProgramsRequest).Result;
           // if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        foreach (EbaySdkLib.Models.Program _fp in response.Item1.programs)
                        {
                            int GetOptedInProgramsDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_OpInToPrograms(_cstr, _fp.programType);
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

        public  string UsingTokenMethod()
        {
            string token = "";
            try
            {
                Account.TokenCheckerPreRequest(_cstr, AccessTokenType.OAUTH);
                AccessTokenInfo at = DA_Ebay_Account.Get_AccessTokenInfo(_cstr, AccessTokenType.OAUTH);
                token = at.AccessToken;
            }
            catch (Exception er)
            {
                throw er;
            }
            return token;
        }

        [TestMethod]
        public void OutPutOfProgramsTest()
            {
               
            string token = UsingTokenMethod();
            AccountService _accountService = new EbaySdkLib.AccountService(token);
          
            EbaySdkLib.Messages.OptOutOfProgramRequest optOutOfProgramRequest = new EbaySdkLib.Messages.OptOutOfProgramRequest();
            optOutOfProgramRequest.programs = new EbaySdkLib.Models.Program[] { new EbaySdkLib.Models.Program() { programType = ProgramTypeEnum.SELLING_POLICY_MANAGEMENT } };

            var response = _accountService.ProgramService.OutPutOfProgram(optOutOfProgramRequest).Result;
          //  if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        foreach (EbaySdkLib.Models.Program _fp in response.Item1.programs)
                        {
                            int GetOptedInProgramsDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_OutPutOfPrograms(_cstr, _fp.programType);
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

        #endregion

        #region Privilage
        [TestMethod]
        public void GetPrivilageTest()
        {
                 try
                  {
                      string token = UsingTokenMethod();
                      AccountService _accountService = new EbaySdkLib.AccountService(token);
                       var response = _accountService.PrivilegeService.GetPrivilage().Result;
                    // if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
                   switch (response.Item2)
                    {
                        case System.Net.HttpStatusCode.OK:
                            {
                                //Add to DB
                                int PrivilegesDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_GetPrivilage(_cstr, response.Item1.sellingLimit.amount.value, response.Item1.sellingLimit.amount.currency, response.Item1.sellingLimit.quantity, bool.Parse(response.Item1.sellerRegistrationCompleted));
                                return;
                            }
                   case System.Net.HttpStatusCode.InternalServerError:
                       {
                           throw new Exception("Internal Server Error From Api - [GetPrivilage] - " + response.Item2.ToString());
               
                       }
                   case System.Net.HttpStatusCode.BadRequest:
                       {
                           throw new Exception("Bad Request From Api - [GetPrivilage] - " + response.Item2.ToString());
                       }
               
                   default:
                       {
                           throw new Exception("Unrecognised Error Response From Api - [GetPrivilage] - " + response.Item2.ToString());
               
                       }
               }
               
               }
               catch (Exception er)
               {
                   throw er;
               }


            }
        #endregion

        #region SalesTax
        [TestMethod]
        public void CreateOrReplaceSalesTexTest()
            {
            string token = UsingTokenMethod();
            AccountService _accountService = new EbaySdkLib.AccountService(token);
            EbaySdkLib.Messages.CreateOrReplaceSalesTaxRequest createOrReplaceSalesTaxRequest = new EbaySdkLib.Messages.CreateOrReplaceSalesTaxRequest();
            createOrReplaceSalesTaxRequest.salesTaxPercentage = "4.0";
            createOrReplaceSalesTaxRequest.shippingAndHandlingTaxed = true;
            string countyCode = CountryCodeEnum.US.ToString();
            string jurisdictionId = "NY";
            var response = _accountService.SalesTaxService.CreateorReplaceSalesTax(createOrReplaceSalesTaxRequest, countyCode, jurisdictionId).Result;
            if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            switch (response.Item2)
            {
                //case System.Net.HttpStatusCode.OK:
                //  {
                //      //Add to DB
                //      int PrivilegesDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_GetPrivilage(_cstr, response.Item1.sellingLimit.amount.value, response.Item1.sellingLimit.amount.currency, response.Item1.sellingLimit.quantity,bool.Parse(response.Item1.sellerRegistrationCompleted));
                //  }
                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [GetPrivilage] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [GetPrivilage] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [GetPrivilage] - " + response.Item2.ToString());

                    }
            }

            }
        [TestMethod]
        public void DeleteSalesTaxTest()
            {
            string token = UsingTokenMethod();
            AccountService _accountService = new EbaySdkLib.AccountService(token);
            EbaySdkLib.Messages.DeleteSalesTaxRequest deleteSalesTaxRequest = new EbaySdkLib.Messages.DeleteSalesTaxRequest();
            string countyCode = CountryCodeEnum.US.ToString();
            string jurisdictionId = "IL";
            var response = _accountService.SalesTaxService.DeleteSalesTax(countyCode, jurisdictionId).Result;
            if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB

                        int SalesTaxesDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_DeleteSalesTaxs(_cstr,"Delete Successfully");
                      
                        return;
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [GetSalesTaxes] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [GetSalesTaxes] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [GetSalesTaxes] - " + response.Item2.ToString());

                    }
               }
            }
        [TestMethod]
        public void GetSalesTaxTest()
            {
             string token = UsingTokenMethod();
             AccountService _accountService = new EbaySdkLib.AccountService(token);
            EbaySdkLib.Messages.GetSalesTaxRequest getSalesTaxRequest = new EbaySdkLib.Messages.GetSalesTaxRequest();
            string countyCode = CountryCodeEnum.US.ToString();
            string jurisdictionId = "NY";
            var response = _accountService.SalesTaxService.GetSalesTax(countyCode, jurisdictionId).Result;
            //if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        int SalesTaxDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_GetSalesTax(_cstr, response.Item1.salesTaxJurisdictionId, response.Item1.salesTaxPercentage, response.Item1.countryCode, response.Item1.shippingAndHandlingTaxed);
                        return;
                    }
                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [GetSalesTaxT] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [GetSalesTaxT] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [GetSalesTaxT] - " + response.Item2.ToString());

                    }
            }

            }
        [TestMethod]
        public void GetSalesTaxesTest()
            {

             string token = UsingTokenMethod();
             AccountService _accountService = new EbaySdkLib.AccountService(token);
             EbaySdkLib.Messages.GetSalesTaxesRequest getSalesTaxesRequest = new EbaySdkLib.Messages.GetSalesTaxesRequest();
             string countryCode = CountryCodeEnum.US.ToString();
             var response = _accountService.SalesTaxService.GetSalesTaxes(countryCode).Result;
           // if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        foreach (EbaySdkLib.Models.SalesTax _fp in response.Item1.salesTaxes)
                        {
                            int SalesTaxesDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_GetSalesTaxes(_cstr, _fp.salesTaxJurisdictionId.ToString(), _fp.salesTaxPercentage.ToString(), _fp.countryCode, _fp.shippingAndHandlingTaxed);
                        }
                        return;
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [GetSalesTaxes] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [GetSalesTaxes] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [GetSalesTaxes] - " + response.Item2.ToString());

                    }
            }

            }
        #endregion

        #region PaymentPolicies
        [TestMethod]
        public void getPaymentPolicy()
        {
            string token = UsingTokenMethod();
            AccountService _accountService = new EbaySdkLib.AccountService(token);
            EbaySdkLib.Messages.GetPaymentpolicyRequest getPaymentpolicy = new EbaySdkLib.Messages.GetPaymentpolicyRequest();
            getPaymentpolicy.payment_policy_id = "5486492000";
            string Id = getPaymentpolicy.payment_policy_id.ToString();
            var response = _accountService.PaymentpolicyService.getPaymentpolicyService(Id).Result;
            if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); }
            else { Assert.Fail(response.Item2.ToString()); }
             switch (response.Item2)
                {
                    case System.Net.HttpStatusCode.OK:
                        {
                            //Add to DB

                            int PaymentPolicyDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_PPPaymentPolicy(_cstr, response.Item1.name, "null", response.Item1.description,response.Item1.immediatePay, response.Item1.paymentPolicyId);

                               foreach (EbaySdkLib.Models.CategoryType _ct in response.Item1.categoryTypes)
                                {
                                    SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_PPCategoryType(_cstr, PaymentPolicyDBID, _ct.name.ToString(), _ct.@default);
                                }

                                foreach (EbaySdkLib.Models.PaymentMethod _so in response.Item1.paymentMethods)
                                {
                                    SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_PPPaymentMethods(_cstr, PaymentPolicyDBID, _so.paymentMethodType.ToString(), _so.recipientAccountReference.referenceId.ToString(), _so.recipientAccountReference.referenceType.ToString());
                                }
                            

                            return ;

                        }

                    case System.Net.HttpStatusCode.InternalServerError:
                        {
                            throw new Exception("Internal Server Error From Api - [GetPaymentPolicy] - " + response.Item2.ToString());

                        }
                    case System.Net.HttpStatusCode.BadRequest:
                        {
                            throw new Exception("Bad Request From Api - [GetPaymentPolicy] - " + response.Item2.ToString());
                        }

                    default:
                        {
                            throw new Exception("Unrecognised Error Response From Api - [GetPaymentPolicy] - " + response.Item2.ToString());

                        }
                }

            }

   

        [TestMethod]
        public void getPaymentPolicies()
            {
            string token = UsingTokenMethod();
            AccountService _accountService = new EbaySdkLib.AccountService(token);
            EbaySdkLib.Messages.GetpaymentpoliciesRequest getpaymentpoliciesRequest = new EbaySdkLib.Messages.GetpaymentpoliciesRequest();
            getpaymentpoliciesRequest.marketplaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US.ToString();
            string Id = getpaymentpoliciesRequest.marketplaceId.ToString();
            var response = _accountService.PaymentpolicyService.getPaymentpoliciesService(Id).Result;
            if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        foreach (EbaySdkLib.Models.PaymentPolicy _PP in response.Item1.paymentPolicies)
                        {
                            int PaymentPolicyDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_PPPaymentPolicies(_cstr, _PP.name, _PP.description, _PP.marketplaceId.ToString());

                            foreach (EbaySdkLib.Models.CategoryType _ct in _PP.categoryTypes)
                            {
                                SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_PPCategoryType(_cstr, PaymentPolicyDBID, _ct.name.ToString(), _ct.@default);
                            }

                            foreach (EbaySdkLib.Models.PaymentMethod _so in _PP.paymentMethods)
                            {
                                SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_PPPaymentMethods(_cstr, PaymentPolicyDBID, _so.paymentMethodType.ToString(), _so.recipientAccountReference.referenceId.ToString(), _so.recipientAccountReference.referenceType.ToString());
                            }
                        }

                        return ;

                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [GetPaymentPolicies] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [GetPaymentPolicies] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [GetPaymentPolicies] - " + response.Item2.ToString());

                    }
            }

            }


        [TestMethod]
        public void getPaymentPolicyByName()
        {
            string token = UsingTokenMethod();
            AccountService _accountService = new EbaySdkLib.AccountService(token);
            EbaySdkLib.Messages.GetPaymentPolicyByNameRequest getPaymentPolicyByNameRequest = new EbaySdkLib.Messages.GetPaymentPolicyByNameRequest();
            getPaymentPolicyByNameRequest.name = "default payment policy";
            getPaymentPolicyByNameRequest.marketplaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US;
            string marketplaceId = getPaymentPolicyByNameRequest.marketplaceId.ToString();
            string name = getPaymentPolicyByNameRequest.name;
            var response = _accountService.PaymentpolicyService.getPaymentPolicyByNameService(name, marketplaceId).Result;
            if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB

                        int PaymentPolicyDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_PPPaymentPolicyByName(_cstr, response.Item1.name, "null", response.Item1.description, response.Item1.immediatePay, response.Item1.paymentPolicyId);

                        foreach (EbaySdkLib.Models.CategoryType _ct in response.Item1.categoryTypes)
                        {
                            SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_PPCategoryType(_cstr, PaymentPolicyDBID, _ct.name.ToString(), _ct.@default);
                        }

                        foreach (EbaySdkLib.Models.PaymentMethod _so in response.Item1.paymentMethods)
                        {
                            SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_PPPaymentMethods(_cstr, PaymentPolicyDBID, _so.paymentMethodType.ToString(), _so.recipientAccountReference.referenceId.ToString(), _so.recipientAccountReference.referenceType.ToString());
                        }


                        return ;

                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [GetPaymentPolicyByName] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [GetPaymentPolicyByName] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [GetPaymentPolicyByName] - " + response.Item2.ToString());

                    }
            }
        }

        [TestMethod]
        public void createPaymentPolicy()
        {
            string token = UsingTokenMethod();
            AccountService _accountService = new EbaySdkLib.AccountService(token);
            EbaySdkLib.Messages.CreatePaymerntPolicyRequest createPaymerntPolicyRequest = new EbaySdkLib.Messages.CreatePaymerntPolicyRequest();
            createPaymerntPolicyRequest.categoryTypes = new EbaySdkLib.Models.CategoryType[] { new EbaySdkLib.Models.CategoryType() { name = CategoryTypeEnum.ALL_EXCLUDING_MOTORS_VEHICLES } };
            createPaymerntPolicyRequest.name = "minimal Payment Policy";
            createPaymerntPolicyRequest.paymentMethods = new EbaySdkLib.Models.PaymentMethod[] { new EbaySdkLib.Models.PaymentMethod() { paymentMethodType = PaymentMethodTypeEnum.PERSONAL_CHECK } };
            var response = _accountService.PaymentpolicyService.createPaymentPolicyService(createPaymerntPolicyRequest).Result;
            if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        int PaymentPolicyDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_PPCreatePaymentPolicy(_cstr, response.Item1.name, "null", response.Item1.description, response.Item1.immediatePay, response.Item1.paymentPolicyId);

                        foreach (EbaySdkLib.Models.CategoryType _ct in response.Item1.categoryTypes)
                        {
                            SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_PPCategoryType(_cstr, PaymentPolicyDBID, _ct.name.ToString(), _ct.@default);
                        }

                        foreach (EbaySdkLib.Models.PaymentMethod _so in response.Item1.paymentMethods)
                        {
                            SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_PPPaymentMethods(_cstr, PaymentPolicyDBID, _so.paymentMethodType.ToString(), _so.recipientAccountReference.referenceId.ToString(), _so.recipientAccountReference.referenceType.ToString());
                        }
                        return ;
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [createPaymentPolicy] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [createPaymentPolicy] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [createPaymentPolicy] - " + response.Item2.ToString());

                    }
            }

        }

        [TestMethod]
        public void updatepaymentPolicy()
        {
            string token = UsingTokenMethod();
            AccountService _accountService = new EbaySdkLib.AccountService(token);
            EbaySdkLib.Messages.updatePaymentPolicyRequest updatePaymentPolicyrequest = new EbaySdkLib.Messages.updatePaymentPolicyRequest();
            updatePaymentPolicyrequest.categoryTypes = new EbaySdkLib.Models.CategoryType[] { new EbaySdkLib.Models.CategoryType() { name = CategoryTypeEnum.ALL_EXCLUDING_MOTORS_VEHICLES } };
            updatePaymentPolicyrequest.description = "Standard payment policy, PP & CC payments";
            updatePaymentPolicyrequest.name = "default payment policy";
            updatePaymentPolicyrequest.paymentMethods = new EbaySdkLib.Models.PaymentMethod[] { new EbaySdkLib.Models.PaymentMethod() { paymentMethodType = PaymentMethodTypeEnum.PERSONAL_CHECK } };
            string policyId = "5458323000";
            var response = _accountService.PaymentpolicyService.updatePaymentPolicyService(updatePaymentPolicyrequest, policyId).Result;
            if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        int PaymentPolicyDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_PPUpdatePaymentPolicy(_cstr, response.Item1.name, "null", response.Item1.description, response.Item1.immediatePay, response.Item1.paymentPolicyId);

                        foreach (EbaySdkLib.Models.CategoryType _ct in response.Item1.categoryTypes)
                        {
                            SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_PPCategoryType(_cstr, PaymentPolicyDBID, _ct.name.ToString(), _ct.@default);
                        }

                        foreach (EbaySdkLib.Models.PaymentMethod _so in response.Item1.paymentMethods)
                        {
                            SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_PPPaymentMethods(_cstr, PaymentPolicyDBID, _so.paymentMethodType.ToString(), _so.recipientAccountReference.referenceId.ToString(), _so.recipientAccountReference.referenceType.ToString());
                        }

                        return ;

                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [UpdatePaymentPolicy] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [UpdatePaymentPolicy] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [UpdatePaymentPolicy] - " + response.Item2.ToString());

                    }
            }

        }


        [TestMethod]
        public void deletePaymentpolicy()
        {
            string token = UsingTokenMethod();
            AccountService _accountService = new EbaySdkLib.AccountService(token);
            string payment_policy_id = "5446270000";
            var response = _accountService.ReturnPolicyService.deleteReturnPolicyService(payment_policy_id).Result;
            if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }

            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        int PaymentPolicyDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_FPDeletePaymentPolicy(_cstr, "Delete Successfully");
                        return ;

                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [DeletePaymentPolicy] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [DeletePaymentPolicy] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [DeletePaymentPolicy] - " + response.Item2.ToString());

                    }
            }
        }

        #endregion

        #region RateTable
        /// Rate-tables
        ///Response is null but status code=200.
        [TestMethod]
        public void GetRateTablesTest()
            {

                string token = UsingTokenMethod();
                AccountService _accountService = new EbaySdkLib.AccountService(token);
                 var ratetables = new EbaySdkLib.Models.RateTable()
                 {
                     countryCode = EbaySdkLib.Enums.CountryCodeEnum.US
                 };
                 var response = _accountService.PaymentpolicyService.getratePolicyService(ratetables).Result;
                 //if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1.ToString()); } else { Assert.Fail(response.Item2.ToString()); }
                 switch (response.Item2)
                 {
                     case System.Net.HttpStatusCode.OK:
                         {
                             //Add to DB
                             foreach (EbaySdkLib.Models.RateTable _fp in response.Item1.rateTables)
                             {
                                 int RateTableDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_GetRateTables(_cstr, _fp.countryCode.ToString(), _fp.name.ToString(), _fp.locality, _fp.rateTableId);
                             }
                             return;
                         }

                     case System.Net.HttpStatusCode.InternalServerError:
                         {
                             throw new Exception("Internal Server Error From Api - [GetSalesTaxes] - " + response.Item2.ToString());

                         }
                     case System.Net.HttpStatusCode.BadRequest:
                         {
                             throw new Exception("Bad Request From Api - [GetSalesTaxes] - " + response.Item2.ToString());
                         }

                     default:
                         {
                             throw new Exception("Unrecognised Error Response From Api - [GetSalesTaxes] - " + response.Item2.ToString());

                         }
                 }
            }
        #endregion

        #region Return Policy
        /// <summary>
        ///  Return policy starts
        /// </summary>
        [TestMethod]
        public void getReturnPolicy()
            {
             string token = UsingTokenMethod();
            AccountService _accountService = new EbaySdkLib.AccountService(token);
            string return_policy_id = "5458323000";
            var response = _accountService.ReturnPolicyService.getReturnPolicy(return_policy_id).Result;
            if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        int ReturnPolicyDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_GetReturnPolicy(_cstr,response.Item1.name,response.Item1.description,response.Item1.marketplaceId.ToString());
                        foreach (EbaySdkLib.Models.CategoryType _ct in response.Item1.categoryTypes)
                        {
                            SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_RPCategoryType(_cstr, ReturnPolicyDBID, _ct.name.ToString(), _ct.@default);
                        }

                        SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_RPServiceMethod(_cstr, ReturnPolicyDBID, response.Item1.returnsAccepted, response.Item1.returnPeriod.unit.ToString(), response.Item1.returnPeriod.value, response.Item1.refundMethod.ToString(), response.Item1.returnShippingCostPayer.ToString(), response.Item1.internationalOverride.returnsAccepted, response.Item1.internationalOverride.returnPeriod.unit.ToString(), response.Item1.internationalOverride.returnPeriod.value, response.Item1.internationalOverride.returnShippingCostPayer.ToString(), response.Item1.returnPolicyId.ToString());
                       
                        return ;
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [ReturnPolicy] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [ReturnPolicy] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [ReturnPolicy] - " + response.Item2.ToString());

                    }
           
                  }
            }

        [TestMethod]
        public void GetReturnPolicies()
            {
             string token = UsingTokenMethod();
             AccountService _accountService = new EbaySdkLib.AccountService(token);
            GetReturnPoliciesRequest getReturnPoliciesRequest = new GetReturnPoliciesRequest();
            getReturnPoliciesRequest.marketplaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US;
            string marketplaceId = getReturnPoliciesRequest.marketplaceId.ToString();
            var response = _accountService.ReturnPolicyService.getReturnPolicies(marketplaceId).Result;
            if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        foreach (EbaySdkLib.Models.ReturnPolicy _RP in response.Item1.returnPolicies)
                        {
                            int ReturnPolicyDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_GetReturnPolicies(_cstr, _RP.name, _RP.description, _RP.marketplaceId.ToString());

                            foreach (EbaySdkLib.Models.CategoryType _ct in _RP.categoryTypes)
                            {
                                SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_RPCategoryType(_cstr, ReturnPolicyDBID, _ct.name.ToString(), _ct.@default);
                            }

                            foreach (EbaySdkLib.Models.ReturnPolicy _so in response.Item1.returnPolicies)
                            {
                                SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_RPServiceMethod(_cstr, ReturnPolicyDBID, _so.returnsAccepted, _so.returnPeriod.unit.ToString(), _so.returnPeriod.value, _so.refundMethod.ToString(),_so.returnShippingCostPayer.ToString(),_so.internationalOverride.returnsAccepted,_so.internationalOverride.returnPeriod.unit.ToString(),_so.internationalOverride.returnPeriod.value,_so.internationalOverride.returnShippingCostPayer.ToString(),_so.returnPolicyId.ToString());
                            }
                        }

                        return ;

                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [GetPaymentPolicies] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [GetPaymentPolicies] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [GetPaymentPolicies] - " + response.Item2.ToString());

                    }
            }
            }

        [TestMethod]
        public void getReturnPoliciesByName()
            {
            string token = UsingTokenMethod();
            AccountService _accountService = new EbaySdkLib.AccountService(token);
            GetReturnPolicyByNameRequest getReturnPolicyByNameRequest = new GetReturnPolicyByNameRequest();
            getReturnPolicyByNameRequest.marketplaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US;
            getReturnPolicyByNameRequest.name = "minimal return policy, US marketplace";
            string marketplaceId = getReturnPolicyByNameRequest.marketplaceId.ToString();
            string name = getReturnPolicyByNameRequest.name.ToString();
            var response = _accountService.ReturnPolicyService.getReturnPoliciesByName(marketplaceId, name).Result;
            if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        int ReturnPolicyDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_GetReturnPoliciesByName(_cstr, response.Item1.name, response.Item1.marketplaceId.ToString());
                        foreach (EbaySdkLib.Models.CategoryType _ct in response.Item1.categoryTypes)
                        {
                            SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_RPCategoryType(_cstr, ReturnPolicyDBID, _ct.name.ToString(), _ct.@default);
                        }

                        SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_RPServiceMethod(_cstr, ReturnPolicyDBID, response.Item1.returnsAccepted, response.Item1.returnPeriod.unit.ToString(), response.Item1.returnPeriod.value, response.Item1.refundMethod.ToString(), response.Item1.returnShippingCostPayer.ToString(), response.Item1.internationalOverride.returnsAccepted, response.Item1.internationalOverride.returnPeriod.unit.ToString(), response.Item1.internationalOverride.returnPeriod.value, response.Item1.internationalOverride.returnShippingCostPayer.ToString(), response.Item1.returnPolicyId.ToString());

                        return;
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [ReturnPoliciesByName] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [ReturnPoliciesByName] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [ReturnPoliciesByName] - " + response.Item2.ToString());

                    }

            }
            }
        /// <summary>
        /// Invalid return error
        /// </summary>
        [TestMethod]
        public void createReturnPolicy()
            {
            string token = UsingTokenMethod();
            AccountService _accountService = new EbaySdkLib.AccountService(token);
            CreateReturnPolicyrequest createReturnPolicyrequest = new CreateReturnPolicyrequest();
            createReturnPolicyrequest.categoryTypes = new EbaySdkLib.Models.CategoryType[] { new EbaySdkLib.Models.CategoryType() { name = CategoryTypeEnum.ALL_EXCLUDING_MOTORS_VEHICLES } };
            createReturnPolicyrequest.marketplaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US;
            createReturnPolicyrequest.name = "minimal return policy, US marketplace";
            var response = _accountService.ReturnPolicyService.createReturnPolicyService(createReturnPolicyrequest).Result;
            if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        int ReturnPolicyDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_createReturnPolicy(_cstr, response.Item1.name, response.Item1.description, response.Item1.marketplaceId.ToString());
                        foreach (EbaySdkLib.Models.CategoryType _ct in response.Item1.categoryTypes)
                        {
                            SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_RPCategoryType(_cstr, ReturnPolicyDBID, _ct.name.ToString(), _ct.@default);
                        }

                        SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_RPServiceMethod(_cstr, ReturnPolicyDBID, response.Item1.returnsAccepted, response.Item1.returnPeriod.unit.ToString(), response.Item1.returnPeriod.value, response.Item1.refundMethod.ToString(), response.Item1.returnShippingCostPayer.ToString(), response.Item1.internationalOverride.returnsAccepted, response.Item1.internationalOverride.returnPeriod.unit.ToString(), response.Item1.internationalOverride.returnPeriod.value, response.Item1.internationalOverride.returnShippingCostPayer.ToString(), response.Item1.returnPolicyId.ToString());

                        return;
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [ReturnPoliciesByName] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [ReturnPoliciesByName] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [ReturnPoliciesByName] - " + response.Item2.ToString());

                    }
               }
            }
        [TestMethod]
        public void UpdateReturnPolicy()
            {
            string token = UsingTokenMethod();
            AccountService _accountService = new EbaySdkLib.AccountService(token);
            UpdateReturnPolicyRequest updateReturnPolicyRequest = new UpdateReturnPolicyRequest();
            updateReturnPolicyRequest.categoryTypes = new EbaySdkLib.Models.CategoryType[] { new EbaySdkLib.Models.CategoryType() { name = CategoryTypeEnum.ALL_EXCLUDING_MOTORS_VEHICLES } };
            updateReturnPolicyRequest.marketplaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US;
            updateReturnPolicyRequest.returnsAccepted = false;
            updateReturnPolicyRequest.name = "minimal return policy, US marketplace";
            string Id = "5487698000";
            var response = _accountService.ReturnPolicyService.updateReturnPolicyService(updateReturnPolicyRequest, Id).Result;
            if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }
            switch (response.Item2)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        //Add to DB
                        int ReturnPolicyDBID = SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_UpdateReturnPolicy(_cstr, response.Item1.name, response.Item1.description, response.Item1.marketplaceId.ToString());
                        foreach (EbaySdkLib.Models.CategoryType _ct in response.Item1.categoryTypes)
                        {
                            SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_RPCategoryType(_cstr, ReturnPolicyDBID, _ct.name.ToString(), _ct.@default);
                        }

                        SellingTools_Lib.DBConnect.DA_Ebay_Account.Add_RPServiceMethod(_cstr, ReturnPolicyDBID, response.Item1.returnsAccepted, response.Item1.returnPeriod.unit.ToString(), response.Item1.returnPeriod.value, response.Item1.refundMethod.ToString(), response.Item1.returnShippingCostPayer.ToString(), response.Item1.internationalOverride.returnsAccepted, response.Item1.internationalOverride.returnPeriod.unit.ToString(), response.Item1.internationalOverride.returnPeriod.value, response.Item1.internationalOverride.returnShippingCostPayer.ToString(), response.Item1.returnPolicyId.ToString());

                        return;
                    }

                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        throw new Exception("Internal Server Error From Api - [UpdateReturnPolicy] - " + response.Item2.ToString());

                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        throw new Exception("Bad Request From Api - [UpdateReturnPolicy] - " + response.Item2.ToString());
                    }

                default:
                    {
                        throw new Exception("Unrecognised Error Response From Api - [UpdateReturnPolicy] - " + response.Item2.ToString());

                    }
            }
            }
        [TestMethod]
        public void deleteReturnPolicy()
            {
            
            string return_policy_id = "5456159000";
            var response = _accountService.ReturnPolicyService.deleteReturnPolicyService(return_policy_id).Result;
            if (response.Item2.ToString() == "OK") { Assert.IsNotNull(response.Item1); } else { Assert.Fail(response.Item2.ToString()); }

            }
        #endregion

        //#region "PaymentPolicy"
        //[TestMethod]
        //public void GetPaymentPolicies()
        //{
        //    SellingTools_Lib.Account.GetPaymentPolicies(_cstr, "EBAY_GB");
        //}
        //[TestMethod]
        //public void GetPaymentPolicy()
        //{
        //    SellingTools_Lib.Account.GetPaymentPolicy(_cstr, "5486492000");
        //}
        //[TestMethod]
        //public void GetPaymentPolicyByName()
        //{
        //    SellingTools_Lib.Account.GetPaymentPolicyByName(_cstr);
        //}
        //[TestMethod]
        //public void CreatePaymentPolicy()
        //{
        //    SellingTools_Lib.Account.CreatePaymentPolicy(_cstr);
        //}
        //[TestMethod]
        //public void DeletePaymentPolicy()
        //{
        //    SellingTools_Lib.Account.DeletePaymentPolicy(_cstr);
        //}
        //[TestMethod]
        //public void UpdatePaymentPolicyTest()
        //{
        //    SellingTools_Lib.Account.UpdatePaymentPolicy(_cstr);
        //}
        //#endregion

        //#region "FullfilmentPolicy"

        //[TestMethod]
        //public void GetFulfillmentPoliciesTest()
        //{
        //    SellingTools_Lib.Account.GetFulfillmentPolicies(_cstr, "EBAY_US");
        //}
        //[TestMethod]
        //public void CreateFulfillmentPolicyTest ()
        //{
        //    SellingTools_Lib.Account.CreateFulfillmentPolicy(_cstr);
        //}
        //[TestMethod]
        //public void GetFulfillmentPolicyByName()
        //{
        //    SellingTools_Lib.Account.GetFulfillmentPolicyByName(_cstr);
        //}
        //[TestMethod]
        //public void DeleteFulfillmentPolicyTest()
        //{
        //    SellingTools_Lib.Account.DeleteFulfillmentPolicy(_cstr);
        //}
        //[TestMethod]
        //public void UpdateFulfillmentPolicyTest()
        //{
        //    SellingTools_Lib.Account.UpdateFulfillmentPolicy(_cstr);
        //}

        //#endregion


        }
    }
