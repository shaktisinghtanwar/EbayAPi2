using EbaySdkLib.Enums;
using EbaySdkLib.Models;
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
   public  class DA_Ebay_Inventory
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

        #endregion

        #region "Inventory Item"

        public static int Add_GetInventoryItem(SqlConnectionStringBuilder ConnectionString, string sku, ConditionEnum conditionEnum)
        {
            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
       
            // comm.CommandText = "Ebay_FPAddFulfillmentPolicies";
            comm.CommandText = "Insert into GetInventoryItem (SKU,Condition) values('" + sku + "','" + conditionEnum + "')";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@sku";
            param.Value = sku;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@conditionEnum";
            param.Value = conditionEnum;
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


        public static bool Add_InventoryProduct(SqlConnectionStringBuilder _cstr, int InventoryDBID, string productTitle, string productDescription, string productImageUrl)
        {
            throw new NotImplementedException();
        }

        public static int Add_InventoryItems(SqlConnectionStringBuilder ConnectionString, string inventoryReferenceId, InventoryReferenceTypeEnum inventoryReferenceType)
        {
            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);

            // comm.CommandText = "Ebay_FPAddFulfillmentPolicies";
            comm.CommandText = "Insert into GetInventoryItems (InventoryReferenceId,InventoryReferenceType) values('" + inventoryReferenceId + "','" + inventoryReferenceType + "')";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@inventoryReferenceId";
            param.Value = inventoryReferenceId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@inventoryReferenceType";
            param.Value = inventoryReferenceType;
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
        public static int Add_BulkPriceQuality(SqlConnectionStringBuilder ConnectionString, string sku, string offerId, OfferStatusEnum offerStatus)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // comm.CommandText = "Ebay_FPAddFulfillmentPolicies";
            comm.CommandText = "Insert into BulkPriceQuality(Sku,OfferId,offerStatus) values('" + sku + "','" + offerId + "','" + offerStatus + "')";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@sku";
            param.Value = sku;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param.ParameterName = "@offerId";
            param.Value = offerId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param.ParameterName = "@offerStatus";
            param.Value = offerStatus;
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
        public static int Add_CreateorReplaceItem(SqlConnectionStringBuilder ConnectionString, ConditionEnum condition, int quantity)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);

            // comm.CommandText = "Ebay_FPAddFulfillmentPolicies";
            comm.CommandText = "Insert into CreateorReplaceItem (Condition,ShipToLocationAvailability) values('" + condition + "','" + quantity + "')";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@condition";
            param.Value = condition;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@quantity";
            param.Value = quantity;
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

        public static bool Add_ProductDetails(SqlConnectionStringBuilder ConnectionString, int inventoryDBID, string description, string title, string brand, string[] ean, string[] imageUrls)
        {
            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            // comm.CommandText = "Ebay_FPAddShippingOptions";
            comm.CommandText = "Insert into Inventory_ProductDetails(InventoryDBID,Description,Title,Brand,Ean,ImageUrls) values('" + inventoryDBID + "','" + description + "','" + title + "','" + brand + "','" + ean + "','" + imageUrls + "') ";


            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@inventoryDBID";
            param.Value = inventoryDBID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@description";
            param.Value = description;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@title";
            param.Value = title;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@brand";
            param.Value = brand;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@ean";
            param.Value = ean;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@imageUrls";
            param.Value = imageUrls;
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

        #region "Location"

        public static int Add_GetInventoryLocations(SqlConnectionStringBuilder ConnectionString, string name, StatusEnum merchantLocationStatus, string merchantLocationKey)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);

            // comm.CommandText = "Ebay_FPAddFulfillmentPolicies";
            comm.CommandText = "Insert into InventoryLocations(Name,MerchantLocationStatus,MerchantLocationKey) values('" + name + "','" + merchantLocationStatus + ",'" + merchantLocationKey + "'')";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@name";
            param.Value = name;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@merchantLocationStatus";
            param.Value = merchantLocationStatus;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@merchantLocationKey";
            param.Value = merchantLocationKey;
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

        public static bool Add_GetAddress(SqlConnectionStringBuilder ConnectionString, int locationDBID, string loactionid, string city, string stateOrProvince, string postalCode, CountryCodeEnum country)
        {
            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            // comm.CommandText = "Ebay_FPAddShippingOptions";
            comm.CommandText = "Insert into LocationAddress(LocationDBID,LoactionId,City,StateOrProvince,PostalCode,Country) values('" + locationDBID + "','" + loactionid + "','" + city + "','" + stateOrProvince + "','" + postalCode + "','" + country + "') ";


            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@locationDBID";
            param.Value = locationDBID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@loactionid";
            param.Value = loactionid;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@city";
            param.Value = city;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@stateOrProvince";
            param.Value = stateOrProvince;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@postalCode";
            param.Value = postalCode;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@country";
            param.Value = country;
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
    
        public static int Add_GetInventoryLocation(SqlConnectionStringBuilder _cstr, string p1, StatusEnum statusEnum, string p2)
        {
            throw new NotImplementedException();
        }

        public static bool Add_LocationAddress(SqlConnectionStringBuilder ConnectionString, int locationDBID, string loactionid, string addressLine1, string addressLine2, string city, string stateOrProvince, string postalCode, CountryCodeEnum country)
        {
            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            // comm.CommandText = "Ebay_FPAddShippingOptions";
            comm.CommandText = "Insert into Location_Details(LocationDBID,Loactionid,AddressLine1,AddressLine2,City,StateOrProvince,PostalCode,Country) values('" + locationDBID + "','" + loactionid + "','" + addressLine1 + "','" + addressLine2 + "','" + city + "','" + stateOrProvince + "','" + postalCode + "','" + country + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@locationDBID";
            param.Value = locationDBID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@loactionid";
            param.Value = loactionid;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@addressLine1";
            param.Value = addressLine1;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@addressLine2";
            param.Value = addressLine2;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@city";
            param.Value = city;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@stateOrProvince";
            param.Value = stateOrProvince;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@postalCode";
            param.Value = postalCode;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@country";
            param.Value = country;
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

        public static bool Add_CreateInventoryLocation(SqlConnectionStringBuilder ConnectionString, string locInstructions, string name, StatusEnum marchentStatus, string p3, string addressLine1, string addressLine2, string city, string stateOrProvince, string postalCode, CountryCodeEnum country)
        {
            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            // comm.CommandText = "Ebay_FPAddShippingOptions";
            comm.CommandText = "Insert into CreateLocation(AddressLine1,AddressLine2,City,StateOrProvince,PostalCode,Country,LocInstructions,Name,MarchentStatus) values('" + addressLine1 + "','" + addressLine2 + "','" + city + "','" + stateOrProvince + "','" + postalCode + "','" + country + "','" + locInstructions + "','" + name + "','" + marchentStatus + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@addressLine1";
            param.Value = addressLine1;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@addressLine2";
            param.Value = addressLine2;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@city";
            param.Value = city;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@stateOrProvince";
            param.Value = stateOrProvince;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@postalCode";
            param.Value = postalCode;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@country";
            param.Value = country;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@locInstructions";
            param.Value = locInstructions;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@name";
            param.Value = name;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@marchentStatus";
            param.Value = marchentStatus;
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



        public static bool Add_LocationsAddress(SqlConnectionStringBuilder ConnectionString, int locationDBID, string locationId, string city, string stateOrProvince, string postalCode, string country)
        {
            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            // comm.CommandText = "Ebay_FPAddShippingOptions";
            comm.CommandText = "Insert into Locations_Address(LocationDBID,Loactionid,City,StateOrProvince,PostalCode,Country) values('" + locationDBID + "','" + locationId + "','" + city + "','" + stateOrProvince + "','" + postalCode + "','" + country + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@locationDBID";
            param.Value = locationDBID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@locationId";
            param.Value = locationId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            param = comm.CreateParameter();
            param.ParameterName = "@city";
            param.Value = city;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@stateOrProvince";
            param.Value = stateOrProvince;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@postalCode";
            param.Value = postalCode;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@country";
            param.Value = country;
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


        #region "Offers"

        public static int Add_GetOffers(SqlConnectionStringBuilder ConnectionString, string offerId, string sku, MarketplaceIdEnum marketplaceId, FormatTypeEnum format, int availableQuantity, string categoryId, int quantityLimitPerBuyer, OfferStatusEnum offerStatus)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // comm.CommandText = "Ebay_FPAddFulfillmentPolicies";
            comm.CommandText = "Insert into GetOffers(OfferId,Sku,MarketplaceId,Format,AvailableQuantity,CategoryId,QuantityLimitPerBuyer,OfferStatus) values('" + offerId + "','" + sku + ",'" + marketplaceId + "','" + format + "','" + availableQuantity + "','" + categoryId + "','" + quantityLimitPerBuyer + "','" + offerStatus + "'')";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@offerId";
            param.Value = offerId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@sku";
            param.Value = sku;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@marketplaceId";
            param.Value = marketplaceId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@format";
            param.Value = format;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@availableQuantity";
            param.Value = availableQuantity;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@marketplaceId";
            param.Value = marketplaceId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@categoryId";
            param.Value = categoryId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@quantityLimitPerBuyer";
            param.Value = quantityLimitPerBuyer;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@offerStatus";
            param.Value = offerStatus;
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

        public static bool Add_ListingOffers(SqlConnectionStringBuilder ConnectionString, int offerDBID, string listingId, string listingStatus, string soldQuantity)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            // comm.CommandText = "Ebay_FPAddShippingOptions";
            comm.CommandText = "Insert into ListingOffers(OfferDBID,ListingId,ListingStatus,SoldQuantity) values('" + offerDBID + "','" + listingId + "','" + listingStatus + "','" + soldQuantity + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@offerDBID";
            param.Value = offerDBID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@listingId";
            param.Value = listingId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            param = comm.CreateParameter();
            param.ParameterName = "@listingStatus";
            param.Value = listingStatus;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@soldQuantity";
            param.Value = soldQuantity;
            param.DbType = DbType.Int32;
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

        public static bool Add_ListingPolicies(SqlConnectionStringBuilder ConnectionString, int offerDBID, string paymentPolicyId, string returnPolicyId, CurrencyCodeEnum currency, string value)
        {
   
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            // comm.CommandText = "Ebay_FPAddShippingOptions";
            comm.CommandText = "Insert into ListingPolicy(OfferDBID,PaymentPolicyId,ReturnPolicyId,Currency,Value) values('" + offerDBID + "','" + paymentPolicyId + "','" + returnPolicyId + "','" + currency + "','" + value + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@offerDBID";
            param.Value = offerDBID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@paymentPolicyId";
            param.Value = paymentPolicyId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            param = comm.CreateParameter();
            param.ParameterName = "@returnPolicyId";
            param.Value = returnPolicyId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@currency";
            param.Value = currency;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@value";
            param.Value = value;
            param.DbType = DbType.Int32;
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

        public static int Add_GetOffer(SqlConnectionStringBuilder ConnectionString, string offerId, string sku, MarketplaceIdEnum marketplaceId, FormatTypeEnum format, int availableQuantity, string categoryId, string quantityLimitPerBuyer, StatusEnum offerStatus)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // comm.CommandText = "Ebay_FPAddFulfillmentPolicies";
            comm.CommandText = "Insert into GetOffer(OfferId,Sku,MarketplaceId,Format,AvailableQuantity,CategoryId,QuantityLimitPerBuyer,OfferStatus) values('" + offerId + "','" + sku + ",'" + marketplaceId + "','" + format + "','" + availableQuantity + "','" + categoryId + "','" + quantityLimitPerBuyer + "','" + offerStatus + "'')";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@offerId";
            param.Value = offerId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@sku";
            param.Value = sku;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@marketplaceId";
            param.Value = marketplaceId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@format";
            param.Value = format;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@availableQuantity";
            param.Value = availableQuantity;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@marketplaceId";
            param.Value = marketplaceId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@categoryId";
            param.Value = categoryId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@quantityLimitPerBuyer";
            param.Value = quantityLimitPerBuyer;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@offerStatus";
            param.Value = offerStatus;
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
      
        public static bool Add_ListingOffer(SqlConnectionStringBuilder ConnectionString, int offerDBID, string listingId, string listingStatus, string soldQuantity, string paymentPolicyId, string returnPolicyId, CurrencyCodeEnum currency, string value)
        {
            // get a configured DbCommand object
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            // comm.CommandText = "Ebay_FPAddShippingOptions";
            comm.CommandText = "Insert into ListingOffer(OfferDBID,ListingId,ListingStatus,SoldQuantity,PaymentPolicyId,ReturnPolicyId,Currency,Value) values('" + offerDBID + "','" + listingId + "','" + listingStatus + "','" + soldQuantity + "','" + paymentPolicyId + "','" + returnPolicyId + "','" + currency + "','" + value + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@offerDBID";
            param.Value = offerDBID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@listingId";
            param.Value = listingId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@listingStatus";
            param.Value = listingStatus;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@soldQuantity";
            param.Value = soldQuantity;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@paymentPolicyId";
            param.Value = paymentPolicyId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@returnPolicyId";
            param.Value = returnPolicyId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@currency";
            param.Value = currency;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@value";
            param.Value = value;
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

       public static int Add_GetListFee(SqlConnectionStringBuilder ConnectionString, MarketplaceIdEnum marketplaceId)
        {

            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // comm.CommandText = "Ebay_FPAddFulfillmentPolicies";
            comm.CommandText = "Insert into ListFees(MarketplaceId) values('" + marketplaceId + "')";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@marketplaceId";
            param.Value = marketplaceId;
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

        public static bool Add_FeeDetails(SqlConnectionStringBuilder ConnectionString, int feeDBID, CurrencyCodeEnum currency, string value, string feeType)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // set the stored procedure name
            // comm.CommandText = "Ebay_FPAddShippingOptions";
            comm.CommandText = "Insert into FeeDetails(FeeDBID,Currency,Value,FeeType) values('" + feeDBID + "','" + currency + "','" + value + "','" + feeType + "') ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@feeDBID";
            param.Value = feeDBID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@currency";
            param.Value = currency;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            param = comm.CreateParameter();
            param.ParameterName = "@value";
            param.Value = value;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@feeType";
            param.Value = feeType;
            param.DbType = DbType.Int32;
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

        #region "GetInventoryItemGroup"

        public static int Add_GetItemGroup(SqlConnectionStringBuilder ConnectionString, string inventoryItemGroupKey, string title, string description)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // comm.CommandText = "Ebay_FPAddFulfillmentPolicies";
            comm.CommandText = "Insert into GetInventoryItemGroup(InventoryItemGroupKey,Title,Description) values('" + inventoryItemGroupKey + "','" + title + "','" + description + "')";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@inventoryItemGroupKey";
            param.Value = inventoryItemGroupKey;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param.ParameterName = "@title";
            param.Value = title;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param.ParameterName = "@description";
            param.Value = description;
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

        #region "GetProdCompatibility"

        public static int Add_GetProdCompatibility(SqlConnectionStringBuilder ConnectionString, string sku, string notes, string make, string model, string engine, string trim, string year)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // comm.CommandText = "Ebay_FPAddFulfillmentPolicies";
            comm.CommandText = "Insert into GetProdCompatibility(Sku,Notes,Make,Model,Engine,Trim,Year) values('" + sku + "','" + notes + "','" + make + "','" + model + "','" + engine + "','" + trim + "','" + year + "')";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@sku";
            param.Value = sku;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param.ParameterName = "@notes";
            param.Value = notes;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param.ParameterName = "@make";
            param.Value = make;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param.ParameterName = "@model";
            param.Value = model;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param.ParameterName = "@engine";
            param.Value = engine;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param.ParameterName = "@trim";
            param.Value = trim;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param.ParameterName = "@year";
            param.Value = year;
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

        #region "Listing"

        public static int Add_bulkMigrateListing(SqlConnectionStringBuilder ConnectionString, int statusCode, string listingId, MarketplaceIdEnum marketplaceId, string inventoryItemGroupKey)
        {
            DbCommand comm = DataAccess.CreateCommand(ConnectionString);
            // comm.CommandText = "Ebay_FPAddFulfillmentPolicies";
            comm.CommandText = "Insert into BulkMigrateListing(StatusCode,ListingId,MarketplaceId,ItemGroupKey) values('" + statusCode + "','" + listingId + "','" + marketplaceId + "','" + inventoryItemGroupKey + "')";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@statusCode";
            param.Value = statusCode;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param.ParameterName = "@listingId";
            param.Value = listingId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param.ParameterName = "@marketplaceId";
            param.Value = marketplaceId;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param.ParameterName = "@inventoryItemGroupKey";
            param.Value = inventoryItemGroupKey;
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
    }
}
