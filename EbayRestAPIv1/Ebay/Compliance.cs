using EbaySdkLib;
using SellingTools_Lib.DBConnect;
using SellingTools_Lib.Enums;
using SellingTools_Lib.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTools_Lib.Ebay
{
    public class Compliance
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
                    DA_Ebay_Compliance.AddUpdate_AccessToken(connectionString, AccessTokenType.OAUTH, AccessToken, RefreshToken, AccessTokenExpiryTime, RefreshTokenExpiryTime);
                    return true;
                }
                else
                {

                    throw new Exception("Mint Access Token Failed: " + ErrorDescription);
                }

            }
            catch (Exception er)
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

            AccessTokenInfo at = DA_Ebay_Compliance.Get_AccessTokenInfo(connectionString, AccessTokenType.OAUTH);


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


                DA_Ebay_Compliance.AddUpdate_AccessToken(connectionString, AccessTokenType.OAUTH, AccessToken, at.RefreshToken, AccessTokenExpiryTime, at.RefreshTokenExpiryDate);


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
            AccessTokenInfo at = DA_Ebay_Compliance.Get_AccessTokenInfo(connectionString, AccessType);

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
    }
}
