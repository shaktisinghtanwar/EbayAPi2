using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Collections.Generic;
using EbaySdkLib.Constants;
using EbaySdkLib.Models;

namespace EbaySdkLib.Rest
{
    public class EbayToken
    {
        public async Task<EbayAccessToken> GetAPI(string AuthToken)
        {            
            var baseUri = new Uri(ApplicationConstants.TokenUrl);
            var encodedConsumerKey = HttpUtility.UrlEncode(ApplicationConstants.AppID);
            var encodedConsumerKeySecret = HttpUtility.UrlEncode(ApplicationConstants.AppSecretkey);
            var encodedPair = Base64Encode(String.Format("{0}:{1}", encodedConsumerKey, encodedConsumerKeySecret));
            var encodedAuthToken = HttpUtility.UrlDecode(AuthToken);
            encodedAuthToken = HttpUtility.UrlDecode(encodedAuthToken);

            var requestToken = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(baseUri, "oauth2/token"),
                Content = new StringContent("grant_type=authorization_code&code=" + encodedAuthToken + "&redirect_uri=BGUK_Logistics_-BGUKLogi-Seller-irgjzrql")
            };
            requestToken.Headers.TryAddWithoutValidation("Authorization", String.Format("Basic {0}", encodedPair));
            requestToken.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded");
            
            HttpClient httpClient = new HttpClient();


                var bearerResult = await httpClient.SendAsync(requestToken).ConfigureAwait(false);


            var bearerData = await bearerResult.Content.ReadAsStringAsync();

            if (JObject.Parse(bearerData)["error_description"] != null)
            {
                var error = JObject.Parse(bearerData)["error_description"].ToString();
                EbayAccessToken objReturn = new EbayAccessToken() { IsError = true, AccessToken = null, ErrorDescription = error, ExpiredTime = null };
                var tReturn = new Task<EbayAccessToken>(() => { return objReturn; });
                tReturn.Start();
                return tReturn.Result;
            }
            else
            {
                var bearerToken = JObject.Parse(bearerData)["access_token"].ToString();
                int ExpiredIn = Convert.ToInt32(JObject.Parse(bearerData)["expires_in"].ToString() ?? "0");
                var refreshToken = JObject.Parse(bearerData)["refresh_token"].ToString();
                int refreshTokenExpires = Convert.ToInt32(JObject.Parse(bearerData)["refresh_token_expires_in"].ToString() ?? "0");
                EbayAccessToken objReturn = new EbayAccessToken() { IsError = false, AccessToken = bearerToken, ErrorDescription = null, ExpiredTime = ExpiredIn, RefreshToken = refreshToken, RefreshTokenExpires = refreshTokenExpires };
                var tReturn = new Task<EbayAccessToken>(() => { return objReturn; });
                tReturn.Start();
                return tReturn.Result;
            }

            

        }

        public async Task<EbayAccessToken> GetRefreshToken(string RefreshToken)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("grant_type", "refresh_token");
            dictionary.Add("refresh_token", RefreshToken);
            //dictionary.Add("refresh_token", await GetAPI());

            var baseUri = new Uri(ApplicationConstants.TokenUrl);
            var encodedConsumerKey = HttpUtility.UrlEncode(ApplicationConstants.AppID);
            var encodedConsumerKeySecret = HttpUtility.UrlEncode(ApplicationConstants.AppSecretkey);
            var encodedPair = Base64Encode(String.Format("{0}:{1}", encodedConsumerKey, encodedConsumerKeySecret));

            var requestToken = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(baseUri, "oauth2/token"),
                Content = new StringContent("grant_type=refresh_token&refresh_token=" + RefreshToken + "&scope=https://api.ebay.com/oauth/api_scope https://api.ebay.com/oauth/api_scope/sell.marketing.readonly https://api.ebay.com/oauth/api_scope/sell.marketing https://api.ebay.com/oauth/api_scope/sell.inventory.readonly https://api.ebay.com/oauth/api_scope/sell.inventory https://api.ebay.com/oauth/api_scope/sell.account.readonly https://api.ebay.com/oauth/api_scope/sell.account https://api.ebay.com/oauth/api_scope/sell.fulfillment.readonly https://api.ebay.com/oauth/api_scope/sell.fulfillment https://api.ebay.com/oauth/api_scope/sell.analytics.readonly"
                )
            };
            requestToken.Content=   new FormUrlEncodedContent(dictionary);

            requestToken.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded") { CharSet = "UTF-8" };
            requestToken.Headers.TryAddWithoutValidation("Authorization", String.Format("Basic {0}", encodedPair));
            HttpClient httpClient = new HttpClient();
            
            var bearerResult = await httpClient.SendAsync(requestToken).ConfigureAwait(false);
            var bearerData = await bearerResult.Content.ReadAsStringAsync();

            //Checking error
            if (JObject.Parse(bearerData)["error_description"] != null)
            {
                var error = JObject.Parse(bearerData)["error_description"].ToString();
                var errorID = JObject.Parse(bearerData)["errorID"].ToString();
                

                EbayAccessToken objReturn = new EbayAccessToken() {IsError = true, AccessToken = null, ErrorDescription = error, ErrorID = errorID, ExpiredTime = null};
                
                var tReturn = new Task<EbayAccessToken>(()=> { return objReturn; });
                tReturn.Start();
                return tReturn.Result;
            }
            else
            {
                var bearerToken = JObject.Parse(bearerData)["access_token"].ToString();
                int ExpiredIn = Convert.ToInt32(JObject.Parse(bearerData)["expires_in"].ToString() ?? "0");
                EbayAccessToken objReturn = new EbayAccessToken() { IsError = false, AccessToken = bearerToken, ErrorDescription = null, ExpiredTime = ExpiredIn };
                var tReturn = new Task<EbayAccessToken>(() => { return objReturn; });
                tReturn.Start();
                return tReturn.Result;
            }
            
        }
        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}