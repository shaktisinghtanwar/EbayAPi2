using SellingTools_Lib.DBConnect;
using SellingTools_Lib.Enums;
using SellingTools_Lib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTools_Lib.DBConnect
{
    public class DA_Ebay_Account
    {

        #region "Access Tokens"

        public static bool AddUpdate_AccessToken(SqlConnectionStringBuilder ConnectionString, AccessTokenType AccessType, string AccessToken, string RefreshToken, DateTime AccessTokenExpiryDate, DateTime RefreshTokenExpiryDate)
        {
            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
           // comm.CommandText = "Ebay_TokenAddUpdate";
            comm.CommandText = "Update TblAccess_TokenInfo set AccessType='" + AccessType + "',AccessToken='" + AccessToken + "',RefreshToken='" + RefreshToken + "',AccessTokenExpiryDate='" + AccessTokenExpiryDate + "',RefreshTokenExpiryDate='" + RefreshTokenExpiryDate + "' ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@AccessType";
            param.Value = AccessType;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@AccessToken";
            param.Value = AccessToken;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@RefreshToken";
            param.Value = RefreshToken;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@AccessTokenExpiryDate";
            param.Value = AccessTokenExpiryDate;
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@RefreshTokenExpiryDate";
            param.Value = RefreshTokenExpiryDate;
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);

            // returns true in case of success or false in case of an error
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return (DataAccess.ExecuteNonQuery(comm) != -1);
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return false;
            }
        }

        public static AccessTokenInfo Get_AccessTokenInfo(SqlConnectionStringBuilder ConnectionString, AccessTokenType AccessType)
        {
            // get a configured DbCommand object
            //  string loginInfo = "select  from Ebay_Login";
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            comm.CommandText = "select * from TblAccess_TokenInfo";
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@AccessType";
            param.Value = AccessType;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            DataTable dt = DataAccess.SelectDT(comm);
            AccessTokenInfo ac = new Models.AccessTokenInfo();
            ac.AccessToken = dt.Rows[0]["AccessToken"].ToString();
            ac.AccessType = (AccessTokenType)Enum.Parse(typeof(AccessTokenType), AccessType.ToString());
            ac.AccessTokenExpiryDate = DateTime.Parse(dt.Rows[0]["AccessTokenExpiryDate"].ToString());
            ac.RefreshToken = dt.Rows[0]["RefreshToken"].ToString();
            ac.RefreshTokenExpiryDate = DateTime.Parse(dt.Rows[0]["RefreshTokenExpiryDate"].ToString());

            return ac;
        }
        public static int Add_InsertTokenDetails(SqlConnectionStringBuilder ConnectionString, string accessType, string accessToken, string refreshToken, int? accessTokenExpiryDate, int? refreshTokenExpiryDate)
        {

            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentPolicies";
            comm.CommandText = "Insert into TblAccess_TokenInfo(AccessType,AccessToken,RefreshToken,AccessTokenExpiryDate,RefreshTokenExpiryDate) values('" + accessType + "','" + accessToken + "','" + refreshToken + "','" + accessTokenExpiryDate + "','" + refreshTokenExpiryDate + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@accessType";
            param.Value = accessType;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            param = comm.CreateParameter();

            param.ParameterName = "@accessToken";
            param.Value = accessToken;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            param = comm.CreateParameter();

            param.ParameterName = "@refreshToken";
            param.Value = refreshToken;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            param = comm.CreateParameter();

            param.ParameterName = "@accessTokenExpiryDate";
            param.Value = accessTokenExpiryDate;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            param = comm.CreateParameter();

            param.ParameterName = "@refreshTokenExpiryDate";
            param.Value = refreshTokenExpiryDate;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            try
            {
                //execute the stored procedure and return true if it executes
                //successfully, or false otherwise
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                //prevent the exception from propagating, but return false to
                //signal the error
                return 0;
            }
        }
        public static int Add_RefreshTokenDetails(SqlConnectionStringBuilder ConnectionString, string accessType, string accessToken, string refreshToken, int? accessTokenExpiryDate, int? refreshTokenExpiryDate)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentPolicies";
            comm.CommandText = "Update  TblAccess_TokenInfo RefreshToken='" + refreshToken + "' where Accesstoken='" + accessToken + "'";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@refreshToken";
            param.Value = refreshToken;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            param = comm.CreateParameter();

            
            try
            {
                //execute the stored procedure and return true if it executes
                //successfully, or false otherwise
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                //prevent the exception from propagating, but return false to
                //signal the error
                return 0;
            }
        }
        #endregion

        #region "FP FulfillmentPolicy"
       public static int Add_FPFulfillmentPolicy(SqlConnectionStringBuilder ConnectionString,  string FPName, string FPMarketPlaceID, int FPHandlingTimeValue, string FPHandlingTimeUnit)
        {
                // get a configured DbCommand object
                DbCommand comm = DataAccess.CreateCommand(ConnectionString);
                // set the stored procedure name
               // comm.CommandText = "Ebay_FPAddFulfillmentPolicies";
                comm.CommandText = "Insert into FulfillmentPolicy (Name,MarketPlaceId,HandlingTimeValue,HandlingTimeUnit) values('" + FPName + "','" + FPMarketPlaceID + "','" + FPHandlingTimeValue + "','" + FPHandlingTimeUnit + "')";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@FPName";
                param.Value = FPName;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@FPMarketPlaceID";
                param.Value = FPMarketPlaceID;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@FPHandlingTimeValue";
                param.Value = FPHandlingTimeValue;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@FPHandlingTimeUnit";
                param.Value = FPHandlingTimeUnit;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                // returns true in case of success or false in case of an error
                try
                {
                    // execute the stored procedure and return true if it executes
                    // successfully, or false otherwise
                    return int.Parse(DataAccess.SelectString(comm));
                }
                catch
                {
                    // prevent the exception from propagating, but return false to
                    // signal the error
                    return 0;
                }


            }

       public static bool Add_FPCategoryType(SqlConnectionStringBuilder ConnectionString, int FPFulfillmentPoliciesID, string FPName, bool FPDefault)
        {
            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_FPAddCategoryTypes";
            comm.CommandText = "Insert into FullfillPlolicy_CategoryTypes (FulfillmentPoliciesID,Name,Default)values('" + FPFulfillmentPoliciesID + "','" + FPName + "','" + FPDefault + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@FPName";
            param.Value = FPName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPFulfillmentPoliciesID";
            param.Value = FPFulfillmentPoliciesID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPDefault";
            param.Value = FPDefault;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            // returns true in case of success or false in case of an error
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return (DataAccess.ExecuteNonQuery(comm) != -1);
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return false;
            }


        }

       public static bool Add_FPShippingServices(SqlConnectionStringBuilder ConnectionString, int FPFulfillmentPoliciesID, string FPOptionType, string FPCostType, int FPSortOrder, string FPShippingCarrierCode, string FPShippingServiceCode,
            string FPShippingCostValue, string FPShippingCostCurrency, string FPAdditionalShippingCostValue, string FPAdditionalShippingCurrency, bool FPFreeShipping, bool FPBuyerResponsibleForShipping, bool FPBuyerResponsibleForPickup, bool FPInsuranceOffered, string FPInsuranceFeeValue,
            string FPInsuranceFeeCurrency, bool FPGlobalShipping, bool FPPickupDropOff, bool FPFreightShipping, string FPFulfillmentPolicyId)
             {

            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
           // comm.CommandText = "Ebay_FPAddShippingOptions";
            comm.CommandText = "Insert into FullfillmentPlolicy_ShippingService(FulfillmentPoliciesID,OptionType,CostType,SortOrder,ShippingCarrierCode,ShippingServiceCode,ShippingCostValue,ShippingCostCurrency,FreeShipping,BuyerResponsibleForShipping,BuyerResponsibleForPickup,InsuranceOffered,InsuranceFeeValue,InsuranceFeeCurrency,GlobalShipping,PickupDropOff,FreightShipping,FulfillmentPolicyId) values('" + FPFulfillmentPoliciesID + "','" + FPOptionType + "','" + FPCostType + "','" + FPSortOrder + "','" + FPShippingCarrierCode + "','" + FPShippingServiceCode + "','" + FPShippingCostValue + "','" + FPShippingCostCurrency + "','" + FPAdditionalShippingCostValue + "','" + FPAdditionalShippingCurrency + "','" + FPFreeShipping + "','" + FPBuyerResponsibleForShipping + "','" + FPBuyerResponsibleForPickup + "','" + FPInsuranceOffered + "','" + FPInsuranceFeeValue + "','" + FPInsuranceFeeCurrency + "','" + FPGlobalShipping + "','" + FPPickupDropOff + "','" + FPFreightShipping + "','" + FPFulfillmentPolicyId + "') ";
            

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@FPFulfillmentPoliciesID";
            param.Value = FPFulfillmentPoliciesID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPOptionType";
            param.Value = FPOptionType;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPCostType";
            param.Value = FPCostType;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPSortOrder";
            param.Value = FPSortOrder;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPShippingCarrierCode";
            param.Value = FPShippingCarrierCode;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPShippingServiceCode";
            param.Value = FPShippingServiceCode;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPShippingCostValue";
            param.Value = FPShippingCostValue;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPShippingCostCurrency";
            param.Value = FPShippingCostCurrency;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPAdditionalShippingCostValue";
            param.Value = FPAdditionalShippingCostValue;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPAdditionalShippingCurrency";
            param.Value = FPAdditionalShippingCurrency;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPFreeShipping";
            param.Value = FPFreeShipping;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPBuyerResponsibleForShipping";
            param.Value = FPBuyerResponsibleForShipping;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPBuyerResponsibleForPickup";
            param.Value = FPBuyerResponsibleForPickup;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPInsuranceOffered";
            param.Value = FPInsuranceOffered;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPInsuranceFeeValue";
            param.Value = FPInsuranceFeeValue;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPInsuranceFeeCurrency";
            param.Value = FPInsuranceFeeCurrency;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPGlobalShipping";
            param.Value = FPGlobalShipping;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPPickupDropOff";
            param.Value = FPPickupDropOff;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPFreightShipping";
            param.Value = FPFreightShipping;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPFulfillmentPolicyId";
            param.Value = FPFulfillmentPolicyId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // returns true in case of success or false in case of an error
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return (DataAccess.ExecuteNonQuery(comm) != -1);
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return false;
            }


        }
        public static int Add_FPFulfillmentPolicies(SqlConnectionStringBuilder ConnectionString, string FPName, string FPMarketPlaceID, int FPHandlingTimeValue, string FPHandlingTimeUnit)
        {
                // get a configured DbCommand object
                DbCommand comm = DataAccess.CreateCommand(ConnectionString);
                // set the stored procedure name
               // comm.CommandText = "Ebay_FPAddFulfillmentPolicies";
                comm.CommandText = "Insert into GetFulfillmentPolicies (Name,MarketPlaceId,HandlingTimeValue,HandlingTimeUnit) values('" + FPName + "','" + FPMarketPlaceID + "','" + FPHandlingTimeValue + "','" + FPHandlingTimeUnit + "')";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@FPName";
                param.Value = FPName;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@FPMarketPlaceID";
                param.Value = FPMarketPlaceID;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@FPHandlingTimeValue";
                param.Value = FPHandlingTimeValue;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@FPHandlingTimeUnit";
                param.Value = FPHandlingTimeUnit;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                // returns true in case of success or false in case of an error
                try
                {
                    // execute the stored procedure and return true if it executes
                    // successfully, or false otherwise
                    return int.Parse(DataAccess.SelectString(comm));
                }
                catch
                {
                    // prevent the exception from propagating, but return false to
                    // signal the error
                    return 0;
                }

        }
        public static int Add_FPCreateFulfillmentPolicy(SqlConnectionStringBuilder ConnectionString, string FPName, string FPMarketPlaceID, int FPHandlingTimeValue, string FPHandlingTimeUnit)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            // comm.CommandText = "Ebay_FPAddFulfillmentPolicies";
            comm.CommandText = "Insert into CreateFulfillmentPolicy(Name,MarketPlaceId,HandlingTimeValue,HandlingTimeUnit) values('" + FPName + "','" + FPMarketPlaceID + "','" + FPHandlingTimeValue + "','" + FPHandlingTimeUnit + "')";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@FPName";
            param.Value = FPName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPMarketPlaceID";
            param.Value = FPMarketPlaceID;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPHandlingTimeValue";
            param.Value = FPHandlingTimeValue;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPHandlingTimeUnit";
            param.Value = FPHandlingTimeUnit;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // returns true in case of success or false in case of an error
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return 0;
            }

        }
        public static int Add_FPGetFulfillmentPolicyByName(SqlConnectionStringBuilder ConnectionString, string FPName, string FPMarketPlaceID, int FPHandlingTimeValue, string FPHandlingTimeUnit)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            // comm.CommandText = "Ebay_FPAddFulfillmentPolicies";
            comm.CommandText = "Insert into getFulfillmentPolicyByName(Name,MarketPlaceId,HandlingTimeValue,HandlingTimeUnit) values('" + FPName + "','" + FPMarketPlaceID + "','" + FPHandlingTimeValue + "','" + FPHandlingTimeUnit + "')";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@FPName";
            param.Value = FPName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPMarketPlaceID";
            param.Value = FPMarketPlaceID;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPHandlingTimeValue";
            param.Value = FPHandlingTimeValue;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPHandlingTimeUnit";
            param.Value = FPHandlingTimeUnit;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            try
            {
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                return 0;
            }

        }
        public static int Add_FPDeleteFulfillmentPolicy(SqlConnectionStringBuilder ConnectionString, string statusCode)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            // comm.CommandText = "Ebay_FPAddFulfillmentPolicies";
            comm.CommandText = "Insert into DeleteFulfillmentPolicy(StatusCode) values('" + statusCode + "')";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@statusCode";
            param.Value = statusCode;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            try
            {
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                return 0;
            }
        }
        public static int Add_FPUpdateFulfillmentPolicy(SqlConnectionStringBuilder ConnectionString, string FPName, string FPMarketPlaceID, int FPHandlingTimeValue, string FPHandlingTimeUnit)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            // comm.CommandText = "Ebay_UpdateFulfillmentPolicy";
            comm.CommandText = "Insert into UpdateFulfillmentPolicy(Name,MarketPlaceId,HandlingTimeValue,HandlingTimeUnit) values('" + FPName + "','" + FPMarketPlaceID + "','" + FPHandlingTimeValue + "','" + FPHandlingTimeUnit + "')";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@FPName";
            param.Value = FPName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPMarketPlaceID";
            param.Value = FPMarketPlaceID;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPHandlingTimeValue";
            param.Value = FPHandlingTimeValue;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FPHandlingTimeUnit";
            param.Value = FPHandlingTimeUnit;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            try
            {
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                return 0;
            }

        }
        #endregion

        #region "PP PaymentPolicy"


        public static int Add_PPPaymentPolicy(SqlConnectionStringBuilder ConnectionString, string PPName, string PPMarketPlaceID,string PPDescription, bool PPImmediatePay, string PPPaymentPolicyId)
        {



            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentPolicies";
            comm.CommandText = "Insert into PaymentPolicy(Name,MarketPlaceId,Description,ImmediatePay,PaymentPolicyId) values('" + PPName + "','" + PPMarketPlaceID + "','" + PPDescription + "','" + PPImmediatePay + "','" + PPPaymentPolicyId + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@PPName";
            param.Value = PPName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PPMarketPlaceID";
            param.Value = PPMarketPlaceID;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            //param = comm.CreateParameter();
            //param.ParameterName = "@PPDefault";
            //param.Value = PPDefault;
            //param.DbType = DbType.Boolean;
            //comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PPDescription";
            param.Value = PPDescription;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PPImmediatePay";
            param.Value = PPImmediatePay;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PPPaymentPolicyId";
            param.Value = PPPaymentPolicyId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // returns true in case of success or false in case of an error
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return 0;
            }


        }

        public static int Add_PPPaymentPolicies(SqlConnectionStringBuilder ConnectionString, string PPName, string PPDescription, string PPMarketPlaceID)
        {
            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentPolicies";
            comm.CommandText = "Insert into PaymentPolicies (Name,Description,MarketPlaceId) values('" + PPName + "','" + PPDescription + "','" + PPMarketPlaceID + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@PPName";
            param.Value = PPName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

           

            param = comm.CreateParameter();
            param.ParameterName = "@PPMarketPlaceID";
            param.Value = PPMarketPlaceID;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return 0;
            }

        }
        public static int Add_PPPaymentPolicyByName(SqlConnectionStringBuilder ConnectionString, string PPName, string PPMarketPlaceID, string PPDescription, bool PPImmediatePay, string PPPaymentPolicyId)
        {



            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
           // comm.CommandText = "Ebay_PPAddPaymentPolicies";
            comm.CommandText = "Insert into PaymentPolicyByName(Name,MarketPlaceId,Description,ImmediatePay,PaymentPolicyId) values('" + PPName + "','" + PPMarketPlaceID + "','" + PPDescription + "','" + PPImmediatePay + "','" + PPPaymentPolicyId + "') ";


            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@PPName";
            param.Value = PPName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PPMarketPlaceID";
            param.Value = PPMarketPlaceID;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PPDescription";
            param.Value = PPDescription;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PPImmediatePay";
            param.Value = PPImmediatePay;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PPPaymentPolicyId";
            param.Value = PPPaymentPolicyId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // returns true in case of success or false in case of an error
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return 0;
            }


        }
        public static int Add_PPCreatePaymentPolicy(SqlConnectionStringBuilder ConnectionString, string PPName, string PPMarketPlaceID, string PPDescription, bool PPImmediatePay, string PPPaymentPolicyId)
        {



            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentPolicies";

            comm.CommandText = "Insert into CreatePaymentPolicy(Name,MarketPlaceId,Description,ImmediatePay,PaymentPolicyId) values('" + PPName + "','" + PPMarketPlaceID + "','" + PPDescription + "','" + PPImmediatePay + "','" + PPPaymentPolicyId + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@PPName";
            param.Value = PPName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PPMarketPlaceID";
            param.Value = PPMarketPlaceID;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            param = comm.CreateParameter();
            param.ParameterName = "@PPDescription";
            param.Value = PPDescription;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PPImmediatePay";
            param.Value = PPImmediatePay;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PPPaymentPolicyId";
            param.Value = PPPaymentPolicyId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // returns true in case of success or false in case of an error
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return 0;
            }


        }
        public static int Add_FPDeletePaymentPolicy(SqlConnectionStringBuilder ConnectionString, string PPStatusCode)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            comm.CommandText = "Insert into DeleteFulfillmentPolicy(StatusCode) values('" + PPStatusCode + "')";
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@PPStatusCode";
            param.Value = PPStatusCode;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            try
            {
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                return 0;
            }


        }
        public static int Add_PPUpdatePaymentPolicy(SqlConnectionStringBuilder ConnectionString, string PPName, string PPMarketPlaceID, string PPDescription, bool PPImmediatePay, string PPPaymentPolicyId)
        {



            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentPolicies";

            comm.CommandText = "Insert into UpdatePaymentPolicy(Name,MarketPlaceId,Description,ImmediatePay,PaymentPolicyId) values('" + PPName + "','" + PPMarketPlaceID + "','" + PPDescription + "','" + PPImmediatePay + "','" + PPPaymentPolicyId + "',) ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@PPName";
            param.Value = PPName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PPMarketPlaceID";
            param.Value = PPMarketPlaceID;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            param = comm.CreateParameter();
            param.ParameterName = "@PPDescription";
            param.Value = PPDescription;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PPImmediatePay";
            param.Value = PPImmediatePay;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PPPaymentPolicyId";
            param.Value = PPPaymentPolicyId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // returns true in case of success or false in case of an error
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return 0;
            }


        }
        public static bool Add_PPCategoryType(SqlConnectionStringBuilder ConnectionString, int PPPaymentPoliciesID, string PPName, bool PPDefault)
        {
            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddCategoryTypes";
            comm.CommandText = "Insert into PaymentCategoryType(PaymentPoliciesID,Name,Default) values('" + PPPaymentPoliciesID + "','" + PPName + "','" + PPDefault + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@PPName";
            param.Value = PPName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PPPaymentPoliciesID";
            param.Value = PPPaymentPoliciesID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PPDefault";
            param.Value = PPDefault;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            // returns true in case of success or false in case of an error
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return (DataAccess.ExecuteNonQuery(comm) != -1);
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return false;
            }
        }
        public static bool Add_PPPaymentMethods(SqlConnectionStringBuilder ConnectionString,int PPPaymentPoliciesID, string PPPaymentMethodType, string PPRecipientAccountReferenceType, string PPRecipientAccountReferenceId)
        {



            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentMethods";
            comm.CommandText = "Insert into PaymentMethods(PaymentPoliciesID,PaymentMethodType,RecipientAccountReferenceType,RecipientAccountReferenceId) values('" + PPPaymentPoliciesID + "','" + PPPaymentMethodType + "','" + PPRecipientAccountReferenceType + "','" + PPRecipientAccountReferenceId + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@PPPaymentPoliciesID";
            param.Value = PPPaymentPoliciesID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PPPaymentMethodType";
            param.Value = PPPaymentMethodType;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PPRecipientAccountReferenceType";
            param.Value = PPRecipientAccountReferenceType;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PPRecipientAccountReferenceId";
            param.Value = PPRecipientAccountReferenceId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // returns true in case of success or false in case of an error
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return (DataAccess.ExecuteNonQuery(comm) != -1);
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return false;
            }


        }

        #endregion

        #region "Privileges"
       
        public static int Add_GetPrivilage(SqlConnectionStringBuilder ConnectionString, string value, EbaySdkLib.Models.CurrencyCodeEnum currencyCodeEnum, string quantity, bool sellerRegistrationCompleted)
        {

            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentPolicies";
            comm.CommandText = "Insert into GetPrivilage(Value,Currency,Quality,sellerRegistrationCompleted) values('" + value + "','" + currencyCodeEnum + "','" + quantity + "','" + sellerRegistrationCompleted + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@value";
            param.Value = value;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@currencyCodeEnum";
            param.Value = currencyCodeEnum;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            

            param = comm.CreateParameter();
            param.ParameterName = "@quantity";
            param.Value = quantity;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@sellerRegistrationCompleted";
            param.Value = sellerRegistrationCompleted;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            // returns true in case of success or false in case of an error
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return 0;
            }
        }

        #endregion

        #region "Program"

        public static int Add_GetOptedInPrograms(SqlConnectionStringBuilder ConnectionString, EbaySdkLib.Models.ProgramTypeEnum programType)
        {
   
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentPolicies";
            comm.CommandText = "Insert into GetOptedInPrograms(ProgramType) values('" + programType + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@programType";
            param.Value = programType;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            try
            {
                
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                return 0;
            }
        }
        public static int Add_OpInToPrograms(SqlConnectionStringBuilder ConnectionString, EbaySdkLib.Models.ProgramTypeEnum programType)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentPolicies";
            comm.CommandText = "Insert into OpInToPrograms(ProgramType) values('" + programType + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@programType";
            param.Value = programType;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

          
            try
            {

                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                return 0;
            }
        }
        public static int Add_OutPutOfPrograms(SqlConnectionStringBuilder ConnectionString, EbaySdkLib.Models.ProgramTypeEnum programType)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentPolicies";
            comm.CommandText = "Insert into OutPutOfPrograms(ProgramType) values('" + programType + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@programType";
            param.Value = programType;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            try
            {

                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region "SalesTax"

        public static int Add_GetSalesTax(SqlConnectionStringBuilder ConnectionString, string salesTaxJurisdictionId, string salesTaxPercentage, EbaySdkLib.Enums.CountryCodeEnum countryCode, bool shippingAndHandlingTaxed)
        {
            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentPolicies";
            comm.CommandText = "Insert into GetSalesTax(SalesTaxJurisdictionId,salesTaxPercentage,CountryCode,ShippingAndHandlingTaxed) values('" + salesTaxJurisdictionId + "','" + salesTaxPercentage + "','" + countryCode + "','" + shippingAndHandlingTaxed + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@salesTaxJurisdictionId";
            param.Value = salesTaxJurisdictionId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@salesTaxPercentage";
            param.Value = salesTaxPercentage;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@countryCode";
            param.Value = countryCode;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@shippingAndHandlingTaxed";
            param.Value = shippingAndHandlingTaxed;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return 0;
            }
        }

        public static int Add_GetSalesTaxes(SqlConnectionStringBuilder ConnectionString, string salesTaxJurisdictionId, string salesTaxPercentage, EbaySdkLib.Enums.CountryCodeEnum countryCode, bool shippingAndHandlingTaxed)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentPolicies";
            comm.CommandText = "Insert into GetSalesTaxs(SalesTaxJurisdictionId,salesTaxPercentage,CountryCode,ShippingAndHandlingTaxed) values('" + salesTaxJurisdictionId + "','" + salesTaxPercentage + "','" + countryCode + "','" + shippingAndHandlingTaxed + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@salesTaxJurisdictionId";
            param.Value = salesTaxJurisdictionId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@salesTaxPercentage";
            param.Value = salesTaxPercentage;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@countryCode";
            param.Value = countryCode;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@shippingAndHandlingTaxed";
            param.Value = shippingAndHandlingTaxed;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return 0;
            }
        }
        public static int Add_DeleteSalesTaxs(SqlConnectionStringBuilder ConnectionString, string statusCode)
        {
            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentPolicies";
            comm.CommandText = "Insert into DeleteSalesTaxs(StatusCode) values('" + statusCode + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@statusCode";
            param.Value = statusCode;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return 0;
            }
        }

        #endregion

        #region "RateTables"

        public static int Add_GetRateTables(SqlConnectionStringBuilder ConnectionString, string countryCode, string name, string locality, string rateTableId)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentPolicies";
            comm.CommandText = "Insert into GetRateTables(CountryCode,Name,Locality,RateTableId) values('" + countryCode + "','" + name + "','" + locality + "','" + rateTableId + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@countryCode";
            param.Value = countryCode;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@name";
            param.Value = name;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@locality";
            param.Value = locality;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@rateTableId";
            param.Value = rateTableId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return 0;
            }
        }

        #endregion

        #region "ReturnPolicies"

        public static int Add_GetReturnPolicies(SqlConnectionStringBuilder ConnectionString, string RPName, string RPDescription, string RpMarketplaceId)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentPolicies";
            comm.CommandText = "Insert into GetReturnPolicies(Name,Description,MarketplaceId) values('" + RPName + "','" + RPDescription + "','" + RpMarketplaceId + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@RPName";
            param.Value = RPName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@RPDescription";
            param.Value = RPDescription;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@RpMarketplaceId";
            param.Value = RpMarketplaceId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return 0;
            }
        }

        public static bool Add_RPCategoryType(SqlConnectionStringBuilder ConnectionString, int ReturnPolicyDBID, string RPName, bool RPDefault)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddCategoryTypes";
            comm.CommandText = "Insert into RPCategoryType(RerurnPoliciesID,Name,Default) values('" + ReturnPolicyDBID + "','" + RPName + "','" + RPName + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ReturnPolicyDBID";
            param.Value = ReturnPolicyDBID;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@RPName";
            param.Value = RPName;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@RPDefault";
            param.Value = RPDefault;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            // returns true in case of success or false in case of an error
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return (DataAccess.ExecuteNonQuery(comm) != -1);
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return false;
            }
        }

        public static bool Add_RPServiceMethod(SqlConnectionStringBuilder ConnectionString, int ReturnPolicyDBID, bool RPReturnsAccepted, string ReturnPeriodUnit, string ReturnPeriodValue, string RefundMethod, string ReturnShippingCostPayer, bool InternationalOverrideReturnsAccepted, string internationalOverrideReturnPeriodUnit, string internationalOverrideReturnPeriodValue, string internationalOverrideReturnShippingCostPayer, string ReturnPolicyId)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddCategoryTypes";
            comm.CommandText = "Insert into RPServiceMethod(RerurnPoliciesID,RPReturnsAccepted,ReturnPeriodUnit,ReturnPeriodValue,RefundMethod,ReturnShippingCostPayer,IOReturnsAccepted,IOReturnPeriodUnit,IOReturnPeriodValue,IOReturnShippingCostPayer,ReturnPolicyId) values('" + ReturnPolicyDBID + "','" + RPReturnsAccepted + "','" + ReturnPeriodUnit + "','" + ReturnPeriodValue + "','" + RefundMethod + "','" + ReturnShippingCostPayer + "','" + InternationalOverrideReturnsAccepted + "','" + internationalOverrideReturnPeriodUnit + "','" + internationalOverrideReturnPeriodValue + "','" + internationalOverrideReturnShippingCostPayer + "','" + ReturnPolicyId + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ReturnPolicyDBID";
            param.Value = ReturnPolicyDBID;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@RPReturnsAccepted";
            param.Value = RPReturnsAccepted;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@ReturnPeriodUnit";
            param.Value = ReturnPeriodUnit;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@ReturnPeriodValue";
            param.Value = ReturnPeriodValue;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@RefundMethod";
            param.Value = RefundMethod;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@ReturnShippingCostPayer";
            param.Value = ReturnShippingCostPayer;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@InternationalOverrideReturnsAccepted";
            param.Value = InternationalOverrideReturnsAccepted;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);
            param = comm.CreateParameter();
            param.ParameterName = "@internationalOverrideReturnPeriodUnit";
            param.Value = internationalOverrideReturnPeriodUnit;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@internationalOverrideReturnPeriodValue";
            param.Value = internationalOverrideReturnPeriodValue;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@internationalOverrideReturnShippingCostPayer";
            param.Value = internationalOverrideReturnShippingCostPayer;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@ReturnPolicyId";
            param.Value = ReturnPolicyId;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            // returns true in case of success or false in case of an error
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return (DataAccess.ExecuteNonQuery(comm) != -1);
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return false;
            }
        }

        

        public static int Add_GetReturnPolicy(SqlConnectionStringBuilder ConnectionString, string RPName, string RPDescription, string RpMarketplaceId)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentPolicies";
            comm.CommandText = "Insert into GetReturnPolicy(Name,Description,MarketplaceId) values('" + RPName + "','" + RPDescription + "','" + RpMarketplaceId + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@RPName";
            param.Value = RPName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@RPDescription";
            param.Value = RPDescription;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@RpMarketplaceId";
            param.Value = RpMarketplaceId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return 0;
            }
        }

        public static int Add_GetReturnPoliciesByName(SqlConnectionStringBuilder ConnectionString, string RPName, string RpMarketplaceId)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentPolicies";
            comm.CommandText = "Insert into GetReturnPoliciesByName(Name,MarketplaceId) values('" + RPName + "','" + RpMarketplaceId + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@RPName";
            param.Value = RPName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@RpMarketplaceId";
            param.Value = RpMarketplaceId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return 0;
            }
        }

        public static int Add_createReturnPolicy(SqlConnectionStringBuilder ConnectionString, string RPName, string RPDescription, string RpMarketplaceId)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentPolicies";
            comm.CommandText = "Insert into CreateReturnPolicy(Name,Description,MarketplaceId) values('" + RPName + "','" + RPDescription + "','" + RpMarketplaceId + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@RPName";
            param.Value = RPName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@RPDescription";
            param.Value = RPDescription;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@RpMarketplaceId";
            param.Value = RpMarketplaceId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return 0;
            }
        }

        public static int Add_UpdateReturnPolicy(SqlConnectionStringBuilder ConnectionString, string RPName, string RPDescription, string RpMarketplaceId)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            //comm.CommandText = "Ebay_PPAddPaymentPolicies";
            comm.CommandText = "Insert into UpdateReturnPolicy(Name,Description,MarketplaceId) values('" + RPName + "','" + RPDescription + "','" + RpMarketplaceId + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@RPName";
            param.Value = RPName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@RPDescription";
            param.Value = RPDescription;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@RpMarketplaceId";
            param.Value = RpMarketplaceId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, or false otherwise
                return int.Parse(DataAccess.SelectString(comm));
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return 0;
            }
        }
        #endregion




      
    }
}
