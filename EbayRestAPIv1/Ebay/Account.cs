#region Assembly Microsoft.VisualStudio.QualityTools.UnitTestFramework.dll, v10.0.0.0
// C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\PublicAssemblies\Microsoft.VisualStudio.QualityTools.UnitTestFramework.dll
#endregion
using EbaySdkLib;
using EbaySdkLib.Enums;
using EbaySdkLib.Models;
using SellingTools_Lib.DBConnect;
using SellingTools_Lib.Enums;
using SellingTools_Lib.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SellingTools_Lib
{
    public class Account
    {

        #region "Token"

        /// <summary>
        /// Mints access token from auth token provided in user grant page.
        /// </summary>
        public static bool MintAccessToken(SqlConnectionStringBuilder connectionString, string GrantToken)
        {

            try
            {
                GetAccessTokenService getAccessTokenService = new GetAccessTokenService();
                var response = getAccessTokenService.GetToken(GrantToken).Result;
                string AccessToken = response.AccessToken;  //Save to DB
                int? ExpiredTime = response.ExpiredTime;
                string RefreshToken = response.RefreshToken;
                string ErrorDescription = response.ErrorDescription;
                int? RefreshTokenExpiresIn = response.RefreshTokenExpires;
                DateTime AccessTokenExpiryTime = DateTime.Now;
                if (ExpiredTime != null)
                {
                    AccessTokenExpiryTime = AccessTokenExpiryTime.AddSeconds(Convert.ToDouble(ExpiredTime));
                }

                DateTime RefreshTokenExpiryTime = DateTime.Now;
                if (RefreshTokenExpiresIn != null)
                {
                    RefreshTokenExpiryTime = RefreshTokenExpiryTime.AddSeconds(Convert.ToDouble(RefreshTokenExpiresIn));
                }

                if (AccessToken != null)
                {
                    //Save to DB based on UserID and Refresh Token
                    //Refresh Token, RefreshTime, AccessToken, AccessTokenTime
                    DA_Ebay_Account.AddUpdate_AccessToken(connectionString, AccessTokenType.OAUTH, AccessToken, RefreshToken, AccessTokenExpiryTime, RefreshTokenExpiryTime);
                    return true;
                }
                else
                {

                    throw new Exception("Mint Access Token Failed: " + ErrorDescription);
                }

            }
            catch(Exception er)
            {
                throw er;
            }


        }

        /// <summary>
        /// Mints access token from a Saved RefreshToken.  AutoRun every 1.5hours
        /// </summary>
        public static bool RefreshAccessToken(SqlConnectionStringBuilder connectionString)
        {
            GetAccessTokenService getAccessTokenService = new GetAccessTokenService();

            AccessTokenInfo at =  DA_Ebay_Account.Get_AccessTokenInfo(connectionString, AccessTokenType.OAUTH);


            var response = getAccessTokenService.GetRefreshToken(at.RefreshToken).Result;
            string AccessToken = response.AccessToken;
            int? ExpiredTime = response.ExpiredTime; //seconds
            string ErrorDescription = response.ErrorDescription;

            DateTime AccessTokenExpiryTime = DateTime.Now;
            if (ExpiredTime != null)
            {
                AccessTokenExpiryTime = AccessTokenExpiryTime.AddSeconds(Convert.ToDouble(ExpiredTime));
            }

           
            if (AccessToken != null)
            {
                //Save to DB based on UserID and Refresh Token
                //Refresh Token, RefreshTime, AccessToken, AccessTokenTime


                DA_Ebay_Account.AddUpdate_AccessToken(connectionString, AccessTokenType.OAUTH, AccessToken, at.RefreshToken, AccessTokenExpiryTime, at.RefreshTokenExpiryDate);


                return true;
            }
            else
            {
                return false;
            }
        }


        public static void TokenCheckerPreRequest(SqlConnectionStringBuilder connectionString, AccessTokenType AccessType)
        {
            //Get token for OAuth
            AccessTokenInfo at = DA_Ebay_Account.Get_AccessTokenInfo(connectionString, AccessType);

            if (at.RefreshTokenExpiryDate < DateTime.Now.AddDays(1))
            {
                throw new Exception("Access expired- Please re new");
            }

            if (at.AccessTokenExpiryDate < DateTime.Now.AddMinutes(15))
            {
                //mint a new access token and save  then continue;
                bool Sucess = RefreshAccessToken(connectionString);

                if (!Sucess)
                {
                    throw new Exception("Failed to get Access Token");
                }
            }
        }

        #endregion

        #region "FulfillmentPolicies"

        public static bool GetFulfillmentPolicies(SqlConnectionStringBuilder ConnectionString, string MarketplaceID)
        {
            string token = "";
            try
            {
                try
                {
                    TokenCheckerPreRequest(ConnectionString, AccessTokenType.OAUTH);
                    AccessTokenInfo at = DA_Ebay_Account.Get_AccessTokenInfo(ConnectionString, AccessTokenType.OAUTH);
                    token = at.AccessToken;
                }
                catch(Exception er)
                {
                    throw er;
                }
                AccountService _accountService = new AccountService(token);
                EbaySdkLib.Messages.GetFulfilmentPoliciesRequest createFulfillmentRequest = new EbaySdkLib.Messages.GetFulfilmentPoliciesRequest();
                createFulfillmentRequest.marketplaceId = MarketplaceID;
                string Id = createFulfillmentRequest.marketplaceId.ToString();
                var response = _accountService.FulfilmentPolicyService.GetFulfilmentPolicies(Id).Result;

                switch (response.Item2)
                {
                    case System.Net.HttpStatusCode.OK:
                        {
                            //Add to DB
                            foreach (EbaySdkLib.Models.FulfillmentPolicy _fp in response.Item1.fulfillmentPolicies)
                            {
                                int FulfillmentDBID = DBConnect.DA_Ebay_Account.Add_FPFulfillmentPolicy(ConnectionString, _fp.name, MarketplaceID, int.Parse(_fp.handlingTime.value), _fp.handlingTime.unit.ToString());

                                foreach (EbaySdkLib.Models.CategoryType _ct in _fp.categoryTypes)
                                {
                                    DBConnect.DA_Ebay_Account.Add_FPCategoryType(ConnectionString, FulfillmentDBID, _ct.name.ToString(), _ct.@default);
                                }

                                foreach (EbaySdkLib.Models.ShippingOption _so in _fp.shippingOptions)
                                {
                                    foreach (EbaySdkLib.Models.ShippingService _ss in _so.shippingServices)
                                    {

                                        DBConnect.DA_Ebay_Account.Add_FPShippingServices(ConnectionString, FulfillmentDBID, _so.optionType.ToString(), _so.costType.ToString(), int.Parse(_ss.sortOrder), _ss.shippingCarrierCode, _ss.shippingServiceCode, _ss.shippingCost.value.ToString(), _ss.shippingCost.currency.ToString(),
                                            _ss.additionalShippingCost.value.ToString(), _ss.additionalShippingCost.currency.ToString(), bool.Parse(_ss.freeShipping.ToString()), bool.Parse(_ss.buyerResponsibleForShipping), bool.Parse(_ss.buyerResponsibleForPickup), bool.Parse(_so.insuranceOffered), _so.insuranceFee.value.ToString(), _so.insuranceFee.currency.ToString(), bool.Parse(_fp.globalShipping), bool.Parse(_fp.pickupDropOff), bool.Parse(_fp.freightShipping), _fp.fulfillmentPolicyId);
                                    }
                                }
                            }

                            return true;
                            
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
            catch(Exception er)
            {
                throw er;
            }
        }
        public static bool GetFulfillmentPolicy(SqlConnectionStringBuilder ConnectionString)
        {
            string token = "";
            try
            {
                try
                {
                    TokenCheckerPreRequest(ConnectionString, AccessTokenType.OAUTH);
                    AccessTokenInfo at = DA_Ebay_Account.Get_AccessTokenInfo(ConnectionString, AccessTokenType.OAUTH);
                    token = at.AccessToken;
                }
                catch (Exception er)
                {
                    throw er;
                }
                AccountService _accountService = new AccountService(token);
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

                var response = _accountService.FulfilmentPolicyService.GetFulfillmentPolicy(fulfillmentpolicyid).Result;

                switch (response.Item2)
                {
                    case System.Net.HttpStatusCode.OK:
                        {
                            //Add to DB
                              int FulfillmentDBID = DBConnect.DA_Ebay_Account.Add_FPFulfillmentPolicies(ConnectionString,response.Item1.name, "null", int.Parse(response.Item1.handlingTime.value), response.Item1.handlingTime.unit.ToString());
                            
                                foreach (EbaySdkLib.Models.CategoryType _ct in response.Item1.categoryTypes)
                                {
                                    DBConnect.DA_Ebay_Account.Add_FPCategoryType(ConnectionString, FulfillmentDBID, _ct.name.ToString(), _ct.@default);
                                }

                                foreach (EbaySdkLib.Models.ShippingOption _so in response.Item1.shippingOptions)
                                {
                                    foreach (EbaySdkLib.Models.ShippingService _ss in _so.shippingServices)
                                    {

                                        DBConnect.DA_Ebay_Account.Add_FPShippingServices(ConnectionString, FulfillmentDBID, _so.optionType.ToString(), _so.costType.ToString(), int.Parse(_ss.sortOrder), _ss.shippingCarrierCode, _ss.shippingServiceCode, _ss.shippingCost.value.ToString(), _ss.shippingCost.currency.ToString(),
                                            _ss.additionalShippingCost.value.ToString(), _ss.additionalShippingCost.currency.ToString(), bool.Parse(_ss.freeShipping.ToString()), bool.Parse(_ss.buyerResponsibleForShipping), bool.Parse(_ss.buyerResponsibleForPickup), bool.Parse(_so.insuranceOffered), _so.insuranceFee.value.ToString(), _so.insuranceFee.currency.ToString(), bool.Parse(response.Item1.globalShipping), bool.Parse(response.Item1.pickupDropOff), bool.Parse(response.Item1.freightShipping), response.Item1.fulfillmentPolicyId);
                                    }
                                }
                            }

                            return true;

                        

                    case System.Net.HttpStatusCode.InternalServerError:
                        {
                            throw new Exception("Internal Server Error From Api - [GetFulfillmentPolicy] - " + response.Item2.ToString());

                        }
                    case System.Net.HttpStatusCode.BadRequest:
                        {
                            throw new Exception("Bad Request From Api - [GetFulfillmentPolicy] - " + response.Item2.ToString());
                        }

                    default:
                        {
                            throw new Exception("Unrecognised Error Response From Api - [GetFulfillmentPolicy] - " + response.Item2.ToString());

                        }
                }



            }
            catch (Exception er)
            {
                throw er;
            }
        }
        public static bool CreateFulfillmentPolicy(SqlConnectionStringBuilder ConnectionString)
        {
            string token = "";
            try
            {
                try
                {
                    TokenCheckerPreRequest(ConnectionString, AccessTokenType.OAUTH);
                    AccessTokenInfo at = DA_Ebay_Account.Get_AccessTokenInfo(ConnectionString, AccessTokenType.OAUTH);
                    token = at.AccessToken;
                }
                catch (Exception er)
                {
                    throw er;
                }
             AccountService _accountService = new AccountService(token);
             EbaySdkLib.Messages.CreateFulfillmentRequest createFulfillmentRequest = new EbaySdkLib.Messages.CreateFulfillmentRequest();
            createFulfillmentRequest.categoryTypes = new EbaySdkLib.Models.CategoryType[] { new EbaySdkLib.Models.CategoryType() { name = CategoryTypeEnum.ALL_EXCLUDING_MOTORS_VEHICLES } };
            //createFulfillmentRequest.marketplaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US;
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

                switch (response.Item2)
                {
                    case System.Net.HttpStatusCode.OK:
                        {
                            //Add to DB
                            int FulfillmentDBID = DBConnect.DA_Ebay_Account.Add_FPCreateFulfillmentPolicy(ConnectionString, response.Item1.name, "null", int.Parse(response.Item1.handlingTime.value), response.Item1.handlingTime.unit.ToString());

                            foreach (EbaySdkLib.Models.CategoryType _ct in response.Item1.categoryTypes)
                            {
                                DBConnect.DA_Ebay_Account.Add_FPCategoryType(ConnectionString, FulfillmentDBID, _ct.name.ToString(), _ct.@default);
                            }

                            foreach (EbaySdkLib.Models.ShippingOption _so in response.Item1.shippingOptions)
                            {
                                foreach (EbaySdkLib.Models.ShippingService _ss in _so.shippingServices)
                                {

                                    DBConnect.DA_Ebay_Account.Add_FPShippingServices(ConnectionString, FulfillmentDBID, _so.optionType.ToString(), _so.costType.ToString(), int.Parse(_ss.sortOrder), _ss.shippingCarrierCode, _ss.shippingServiceCode, _ss.shippingCost.value.ToString(), _ss.shippingCost.currency.ToString(),
                                            _ss.additionalShippingCost.value.ToString(), _ss.additionalShippingCost.currency.ToString(), bool.Parse(_ss.freeShipping.ToString()), bool.Parse(_ss.buyerResponsibleForShipping), bool.Parse(_ss.buyerResponsibleForPickup), bool.Parse(_so.insuranceOffered), _so.insuranceFee.value.ToString(), _so.insuranceFee.currency.ToString(), bool.Parse(response.Item1.globalShipping), response.Item1.pickupDropOff, bool.Parse(response.Item1.freightShipping), response.Item1.fulfillmentPolicyId);
                                }
                            }
                        }

                        return true;



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
            catch (Exception er)
            {
                throw er;
            }
        }
        public static bool GetFulfillmentPolicyByName(SqlConnectionStringBuilder ConnectionString)
        {
            string token = "";
            try
            {
                try
                {
                    TokenCheckerPreRequest(ConnectionString, AccessTokenType.OAUTH);
                    AccessTokenInfo at = DA_Ebay_Account.Get_AccessTokenInfo(ConnectionString, AccessTokenType.OAUTH);
                    token = at.AccessToken;
                }
                catch (Exception er)
                {
                    throw er;
                }
                AccountService _accountService = new AccountService(token);
                EbaySdkLib.Messages.GetFulfillmentPolicyByNameRequest getFulfillmentPolicyByNameRequest = new EbaySdkLib.Messages.GetFulfillmentPolicyByNameRequest();
                getFulfillmentPolicyByNameRequest.marketplaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US;
                string Id = getFulfillmentPolicyByNameRequest.marketplaceId.ToString();

                string Name = getFulfillmentPolicyByNameRequest.name = "Domestic free shipping";
                var response = _accountService.FulfilmentPolicyService.GetFulfillmentPolicyByName(Name, Id).Result;

                switch (response.Item2)
                {
                    case System.Net.HttpStatusCode.OK:
                        {
                            //Add to DB
                            int FulfillmentDBID = DBConnect.DA_Ebay_Account.Add_FPGetFulfillmentPolicyByName(ConnectionString, response.Item1.name, "null", int.Parse(response.Item1.handlingTime.value), response.Item1.handlingTime.unit.ToString());

                            foreach (EbaySdkLib.Models.CategoryType _ct in response.Item1.categoryTypes)
                            {
                                DBConnect.DA_Ebay_Account.Add_FPCategoryType(ConnectionString, FulfillmentDBID, _ct.name.ToString(), _ct.@default);
                            }

                            foreach (EbaySdkLib.Models.ShippingOption _so in response.Item1.shippingOptions)
                            {
                                foreach (EbaySdkLib.Models.ShippingService _ss in _so.shippingServices)
                                {

                                    DBConnect.DA_Ebay_Account.Add_FPShippingServices(ConnectionString, FulfillmentDBID, _so.optionType.ToString(), _so.costType.ToString(), int.Parse(_ss.sortOrder), _ss.shippingCarrierCode, _ss.shippingServiceCode, _ss.shippingCost.value.ToString(), _ss.shippingCost.currency.ToString(),
                                            _ss.additionalShippingCost.value.ToString(), _ss.additionalShippingCost.currency.ToString(), bool.Parse(_ss.freeShipping.ToString()), bool.Parse(_ss.buyerResponsibleForShipping), bool.Parse(_ss.buyerResponsibleForPickup), bool.Parse(_so.insuranceOffered), _so.insuranceFee.value.ToString(), _so.insuranceFee.currency.ToString(), bool.Parse(response.Item1.globalShipping), bool.Parse(response.Item1.pickupDropOff), bool.Parse(response.Item1.freightShipping), response.Item1.fulfillmentPolicyId);
                                }
                            }
                        }

                        return true;



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
            catch (Exception er)
            {
                throw er;
            }  
        }
        public static bool DeleteFulfillmentPolicy(SqlConnectionStringBuilder ConnectionString)
        {
            string token = "";
            try
            {
                try
                {
                    TokenCheckerPreRequest(ConnectionString, AccessTokenType.OAUTH);
                    AccessTokenInfo at = DA_Ebay_Account.Get_AccessTokenInfo(ConnectionString, AccessTokenType.OAUTH);
                    token = at.AccessToken;
                }
                catch (Exception er)
                {
                    throw er;
                }
                AccountService _accountService = new AccountService(token);
                EbaySdkLib.Messages.DeleteFulfillmentPolicyRequest deleteFulfillmentPolicyRequest = new EbaySdkLib.Messages.DeleteFulfillmentPolicyRequest();
                deleteFulfillmentPolicyRequest.fulfillmentPolicyId = "5446309000";
                string fulfillmentPolicyId = deleteFulfillmentPolicyRequest.fulfillmentPolicyId;
                var response = _accountService.FulfilmentPolicyService.DeleteFulfillmentPolicy(fulfillmentPolicyId).Result;

                switch (response.Item2)
                {
                    case System.Net.HttpStatusCode.OK:
                        {
                            //Add to DB
                            int FulfillmentDBID = DBConnect.DA_Ebay_Account.Add_FPDeleteFulfillmentPolicy(ConnectionString, "Delete Successfully");

                           
                        }

                        return true;



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
            catch (Exception er)
            {
                throw er;
            }
        }
        public static bool UpdateFulfillmentPolicy(SqlConnectionStringBuilder ConnectionString)
        {
            string token = "";
            try
            {
                try
                {
                    TokenCheckerPreRequest(ConnectionString, AccessTokenType.OAUTH);
                    AccessTokenInfo at = DA_Ebay_Account.Get_AccessTokenInfo(ConnectionString, AccessTokenType.OAUTH);
                    token = at.AccessToken;
                }
                catch (Exception er)
                {
                    throw er;
                }
                AccountService _accountService = new AccountService(token);
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

                switch (response.Item2)
                {
                    case System.Net.HttpStatusCode.OK:
                        {
                            //Add to DB
                            int FulfillmentDBID = DBConnect.DA_Ebay_Account.Add_FPUpdateFulfillmentPolicy(ConnectionString, response.Item1.name, "null", int.Parse(response.Item1.handlingTime.value), response.Item1.handlingTime.unit.ToString());

                            foreach (EbaySdkLib.Models.CategoryType _ct in response.Item1.categoryTypes)
                            {
                                DBConnect.DA_Ebay_Account.Add_FPCategoryType(ConnectionString, FulfillmentDBID, _ct.name.ToString(), _ct.@default);
                            }

                            foreach (EbaySdkLib.Models.ShippingOption _so in response.Item1.shippingOptions)
                            {
                                foreach (EbaySdkLib.Models.ShippingService _ss in _so.shippingServices)
                                {

                                    DBConnect.DA_Ebay_Account.Add_FPShippingServices(ConnectionString, FulfillmentDBID, _so.optionType.ToString(), _so.costType.ToString(), int.Parse(_ss.sortOrder), _ss.shippingCarrierCode, _ss.shippingServiceCode, _ss.shippingCost.value.ToString(), _ss.shippingCost.currency.ToString(),
                                            _ss.additionalShippingCost.value.ToString(), _ss.additionalShippingCost.currency.ToString(), bool.Parse(_ss.freeShipping.ToString()), bool.Parse(_ss.buyerResponsibleForShipping), bool.Parse(_ss.buyerResponsibleForPickup), bool.Parse(_so.insuranceOffered), _so.insuranceFee.value.ToString(), _so.insuranceFee.currency.ToString(), bool.Parse(response.Item1.globalShipping), bool.Parse(response.Item1.pickupDropOff), bool.Parse(response.Item1.freightShipping), response.Item1.fulfillmentPolicyId);
                                }
                            }
                        }

                        return true;



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
            catch (Exception er)
            {
                throw er;
            }
        }

        #endregion

        #region "PaymentPolicies"
        
        public static bool GetPaymentPolicies(SqlConnectionStringBuilder ConnectionString, string MarketplaceID)
        {
            string token = "";
            try
            {
                try
                {
                    TokenCheckerPreRequest(ConnectionString, AccessTokenType.OAUTH);
                    AccessTokenInfo at = DA_Ebay_Account.Get_AccessTokenInfo(ConnectionString, AccessTokenType.OAUTH);
                    token = at.AccessToken;
                }
                catch (Exception er)
                {
                    throw er;
                }

                AccountService _accountService = new AccountService(token);
                EbaySdkLib.Messages.GetpaymentpoliciesRequest getPaymentRequest = new EbaySdkLib.Messages.GetpaymentpoliciesRequest();
                getPaymentRequest.marketplaceId = MarketplaceID;
                string Id = getPaymentRequest.marketplaceId.ToString();
                var response = _accountService.PaymentpolicyService.getPaymentpoliciesService(Id).Result;

                switch (response.Item2)
                {
                    case System.Net.HttpStatusCode.OK:
                        {
                            //Add to DB
                             foreach (EbaySdkLib.Models.PaymentPolicy _PP in response.Item1.paymentPolicies)
                            {
                                int PaymentPolicyDBID = DBConnect.DA_Ebay_Account.Add_PPPaymentPolicies(ConnectionString, _PP.name, _PP.description, MarketplaceID);

                                foreach (EbaySdkLib.Models.CategoryType _ct in _PP.categoryTypes)
                                {
                                    DBConnect.DA_Ebay_Account.Add_PPCategoryType(ConnectionString, PaymentPolicyDBID, _ct.name.ToString(), _ct.@default);
                                }

                                foreach (EbaySdkLib.Models.PaymentMethod _so in _PP.paymentMethods)
                                {
                                    DBConnect.DA_Ebay_Account.Add_PPPaymentMethods(ConnectionString, PaymentPolicyDBID, _so.paymentMethodType.ToString(), _so.recipientAccountReference.referenceId.ToString(), _so.recipientAccountReference.referenceType.ToString());
                                }
                            }

                            return true;

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
            catch (Exception er)
            {
                throw er;
            }
        }
        public static  bool GetPaymentPolicy(SqlConnectionStringBuilder ConnectionString, string paymentPolicyId)
        {
           string token = "";
            try
            {
                try
                {
                    TokenCheckerPreRequest(ConnectionString, AccessTokenType.OAUTH);
                    AccessTokenInfo at = DA_Ebay_Account.Get_AccessTokenInfo(ConnectionString, AccessTokenType.OAUTH);
                    token = at.AccessToken;
                }
                catch (Exception er)
                {
                    throw er;
                }

                AccountService _accountService = new AccountService(token);
                EbaySdkLib.Messages.GetPaymentpolicyRequest getPaymentpolicy = new EbaySdkLib.Messages.GetPaymentpolicyRequest();
                getPaymentpolicy.payment_policy_id = paymentPolicyId;
                string Id = getPaymentpolicy.payment_policy_id.ToString();
                var response = _accountService.PaymentpolicyService.getPaymentpolicyService(Id).Result;
                switch (response.Item2)
                {
                    case System.Net.HttpStatusCode.OK:
                        {
                            //Add to DB

                            int PaymentPolicyDBID = DBConnect.DA_Ebay_Account.Add_PPPaymentPolicy(ConnectionString, response.Item1.name, "null", response.Item1.description,response.Item1.immediatePay, response.Item1.paymentPolicyId);

                               foreach (EbaySdkLib.Models.CategoryType _ct in response.Item1.categoryTypes)
                                {
                                    DBConnect.DA_Ebay_Account.Add_PPCategoryType(ConnectionString, PaymentPolicyDBID, _ct.name.ToString(), _ct.@default);
                                }

                                foreach (EbaySdkLib.Models.PaymentMethod _so in response.Item1.paymentMethods)
                                {
                                    DBConnect.DA_Ebay_Account.Add_PPPaymentMethods(ConnectionString, PaymentPolicyDBID, _so.paymentMethodType.ToString(), _so.recipientAccountReference.referenceId.ToString(), _so.recipientAccountReference.referenceType.ToString());
                                }
                            

                            return true;

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
            catch (Exception er)
            {
                throw er;
            }

        }
        public static bool GetPaymentPolicyByName(SqlConnectionStringBuilder ConnectionString)
        {
            string token = "";
            try
            {
                try
                {
                    TokenCheckerPreRequest(ConnectionString, AccessTokenType.OAUTH);
                    AccessTokenInfo at = DA_Ebay_Account.Get_AccessTokenInfo(ConnectionString, AccessTokenType.OAUTH);
                    token = at.AccessToken;
                }
                catch (Exception er)
                {
                    throw er;
                }
                AccountService _accountService = new AccountService(token);
                EbaySdkLib.Messages.GetPaymentPolicyByNameRequest getPaymentPolicyByNameRequest = new EbaySdkLib.Messages.GetPaymentPolicyByNameRequest();
                getPaymentPolicyByNameRequest.name = "default payment policy";
                getPaymentPolicyByNameRequest.marketplaceId = EbaySdkLib.Models.MarketplaceIdEnum.EBAY_US;
                string marketplaceId = getPaymentPolicyByNameRequest.marketplaceId.ToString();
                string name = getPaymentPolicyByNameRequest.name;
                var response = _accountService.PaymentpolicyService.getPaymentPolicyByNameService(name, marketplaceId).Result;

                switch (response.Item2)
                {
                    case System.Net.HttpStatusCode.OK:
                        {
                            //Add to DB

                            int PaymentPolicyDBID = DBConnect.DA_Ebay_Account.Add_PPPaymentPolicyByName(ConnectionString, response.Item1.name, "null", response.Item1.description, response.Item1.immediatePay, response.Item1.paymentPolicyId);

                            foreach (EbaySdkLib.Models.CategoryType _ct in response.Item1.categoryTypes)
                            {
                                DBConnect.DA_Ebay_Account.Add_PPCategoryType(ConnectionString, PaymentPolicyDBID, _ct.name.ToString(), _ct.@default);
                            }

                            foreach (EbaySdkLib.Models.PaymentMethod _so in response.Item1.paymentMethods)
                            {
                                DBConnect.DA_Ebay_Account.Add_PPPaymentMethods(ConnectionString, PaymentPolicyDBID, _so.paymentMethodType.ToString(), _so.recipientAccountReference.referenceId.ToString(), _so.recipientAccountReference.referenceType.ToString());
                            }


                            return true;

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
            catch (Exception er)
            {
                throw er;
            }
        }
        public static bool CreatePaymentPolicy(SqlConnectionStringBuilder ConnectionString)
        {
            string token = "";
            try
            {
                try
                {
                    TokenCheckerPreRequest(ConnectionString, AccessTokenType.OAUTH);
                    AccessTokenInfo at = DA_Ebay_Account.Get_AccessTokenInfo(ConnectionString, AccessTokenType.OAUTH);
                    token = at.AccessToken;
                }
                catch (Exception er)
                {
                    throw er;
                }

                AccountService _accountService = new AccountService(token);
                EbaySdkLib.Messages.CreatePaymerntPolicyRequest createPaymerntPolicyRequest = new EbaySdkLib.Messages.CreatePaymerntPolicyRequest();
                createPaymerntPolicyRequest.categoryTypes = new EbaySdkLib.Models.CategoryType[] { new EbaySdkLib.Models.CategoryType() { name = CategoryTypeEnum.ALL_EXCLUDING_MOTORS_VEHICLES } };
                createPaymerntPolicyRequest.name = "minimal Payment Policy";
                createPaymerntPolicyRequest.paymentMethods = new EbaySdkLib.Models.PaymentMethod[] { new EbaySdkLib.Models.PaymentMethod() { paymentMethodType = PaymentMethodTypeEnum.PERSONAL_CHECK } };
                var response = _accountService.PaymentpolicyService.createPaymentPolicyService(createPaymerntPolicyRequest).Result;

                switch (response.Item2)
                {
                    case System.Net.HttpStatusCode.OK:
                        {
                            //Add to DB
                            int PaymentPolicyDBID = DBConnect.DA_Ebay_Account.Add_PPCreatePaymentPolicy(ConnectionString, response.Item1.name, "null", response.Item1.description, response.Item1.immediatePay, response.Item1.paymentPolicyId);

                            foreach (EbaySdkLib.Models.CategoryType _ct in response.Item1.categoryTypes)
                            {
                                DBConnect.DA_Ebay_Account.Add_PPCategoryType(ConnectionString, PaymentPolicyDBID, _ct.name.ToString(), _ct.@default);
                            }

                            foreach (EbaySdkLib.Models.PaymentMethod _so in response.Item1.paymentMethods)
                            {
                                DBConnect.DA_Ebay_Account.Add_PPPaymentMethods(ConnectionString, PaymentPolicyDBID, _so.paymentMethodType.ToString(), _so.recipientAccountReference.referenceId.ToString(), _so.recipientAccountReference.referenceType.ToString());
                            }


                            return true;
                   

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
            catch (Exception er)
            {
                throw er;
            }
        }
        public static bool DeletePaymentPolicy(SqlConnectionStringBuilder ConnectionString)
        {
            string token = "";
            try
            {
                try
                {
                    TokenCheckerPreRequest(ConnectionString, AccessTokenType.OAUTH);
                    AccessTokenInfo at = DA_Ebay_Account.Get_AccessTokenInfo(ConnectionString, AccessTokenType.OAUTH);
                    token = at.AccessToken;
                }
                catch (Exception er)
                {
                    throw er;
                }

                AccountService _accountService = new AccountService(token);
                string payment_policy_id = "5446270000";
                var response = _accountService.ReturnPolicyService.deleteReturnPolicyService(payment_policy_id).Result;

                switch (response.Item2)
                {
                    case System.Net.HttpStatusCode.OK:
                        {
                            //Add to DB
                            int PaymentPolicyDBID = DBConnect.DA_Ebay_Account.Add_FPDeletePaymentPolicy(ConnectionString, "Delete Successfully");
                            return true;

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
            catch (Exception er)
            {
                throw er;
            }
        }
        public static bool UpdatePaymentPolicy(SqlConnectionStringBuilder ConnectionString)
        {
            string token = "";
            try
            {
                try
                {
                    TokenCheckerPreRequest(ConnectionString, AccessTokenType.OAUTH);
                    AccessTokenInfo at = DA_Ebay_Account.Get_AccessTokenInfo(ConnectionString, AccessTokenType.OAUTH);
                    token = at.AccessToken;
                }
                catch (Exception er)
                {
                    throw er;
                }

                AccountService _accountService = new AccountService(token);
                EbaySdkLib.Messages.updatePaymentPolicyRequest updatePaymentPolicyrequest = new EbaySdkLib.Messages.updatePaymentPolicyRequest();
                updatePaymentPolicyrequest.categoryTypes = new EbaySdkLib.Models.CategoryType[] { new EbaySdkLib.Models.CategoryType() { name = CategoryTypeEnum.ALL_EXCLUDING_MOTORS_VEHICLES } };
                updatePaymentPolicyrequest.description = "Standard payment policy, PP & CC payments";
                updatePaymentPolicyrequest.name = "default payment policy";
                updatePaymentPolicyrequest.paymentMethods = new EbaySdkLib.Models.PaymentMethod[] { new EbaySdkLib.Models.PaymentMethod() { paymentMethodType = PaymentMethodTypeEnum.PERSONAL_CHECK } };
                string policyId = "5458323000";
                var response = _accountService.PaymentpolicyService.updatePaymentPolicyService(updatePaymentPolicyrequest, policyId).Result;

                switch (response.Item2)
                {
                    case System.Net.HttpStatusCode.OK:
                        {
                            //Add to DB
                            int PaymentPolicyDBID = DBConnect.DA_Ebay_Account.Add_PPUpdatePaymentPolicy(ConnectionString, response.Item1.name, "null", response.Item1.description, response.Item1.immediatePay, response.Item1.paymentPolicyId);

                            foreach (EbaySdkLib.Models.CategoryType _ct in response.Item1.categoryTypes)
                            {
                                DBConnect.DA_Ebay_Account.Add_PPCategoryType(ConnectionString, PaymentPolicyDBID, _ct.name.ToString(), _ct.@default);
                            }

                            foreach (EbaySdkLib.Models.PaymentMethod _so in response.Item1.paymentMethods)
                            {
                                DBConnect.DA_Ebay_Account.Add_PPPaymentMethods(ConnectionString, PaymentPolicyDBID, _so.paymentMethodType.ToString(), _so.recipientAccountReference.referenceId.ToString(), _so.recipientAccountReference.referenceType.ToString());
                            }

                            return true;

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
            catch (Exception er)
            {
                throw er;
            }
        }

        #endregion




       
    }
}
