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
   public  class DA_Ebay_Fullfillment
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
    }
}
