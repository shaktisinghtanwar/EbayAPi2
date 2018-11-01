using EbaySdkLib.Constants;
using EbaySdkLib.Messages;
using EbaySdkLib.Models;
using EbaySdkLib.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib
    {
    class RestHelper
        {
        private readonly string url;

        public RestHelper(string url)
            {
            this.url = url;// string.Format("{0}{1}", _baseUrl, url);
            }

        public async Task<EbayAccessToken> GetToken(string AuthToken)
        {
            EbayToken ebayToken = new EbayToken();
            return await ebayToken.GetAPI(AuthToken).ConfigureAwait(false);
         

        }

        public async Task<EbayAccessToken> GetRefreshToken(string ExpiredAccessToken)
        {
            EbayToken ebayToken = new EbayToken();
            return await ebayToken.GetRefreshToken(ExpiredAccessToken).ConfigureAwait(false);
        }

        public async Task<Tuple<string, HttpStatusCode>> Get(string Token)
            {
            try
            {
                string resultContent = null;
                HttpStatusCode statusCode;
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(ApplicationConstants.BASE_URL + url);
                httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", Token));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
                var response = await httpClient.GetAsync(ApplicationConstants.BASE_URL + url).ConfigureAwait(false);
                statusCode = response.StatusCode;
                resultContent = await response.Content.ReadAsStringAsync();
                return new Tuple<String, HttpStatusCode>(resultContent, statusCode);
            }
            catch(AggregateException AgEx)
            {
                throw;
            }
            catch(WebException WebEx)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw;

            }

        }

        public async Task<Tuple<string, HttpStatusCode>> Post(string body, string Token)
            {
            string resultContent = null;
            HttpStatusCode statusCode;
            try
                {

                

                using (var client = new HttpClient())
                    {

                    var request = new HttpRequestMessage() { RequestUri = new Uri(ApplicationConstants.BASE_URL + url), Method = HttpMethod.Post};

                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(ApplicationConstants.CONTENT_TYPE));

                 
                    //request.Content.Headers.Add("Content-Language", "en-GB");
                    request.Headers.Add("Authorization", String.Format("Bearer {0}", Token));
                    

                   // client.BaseAddress = new Uri(ApplicationConstants.BASE_URL);
                   // client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", Token));
                    //client.DefaultRequestHeaders.Add("Content-Language", "en-GB");
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApplicationConstants.CONTENT_TYPE));
                    HttpContent hc = new StringContent(body, UnicodeEncoding.UTF8, "application/json"); 
                    //var stringContent = new StringContent(body, UnicodeEncoding.UTF8, "application/json");
                    hc.Headers.Add("Content-Language",  "en-GB");

                    request.Content = hc;

                    // var result = client.PostAsync(url, stringContent).Result;
                    var result = client.SendAsync(request).Result;
                    statusCode = result.StatusCode;
                    resultContent = await result.Content.ReadAsStringAsync();
                    
                    }
                }
           
            catch (AggregateException ex)
            {
                throw;
            }
            catch(WebException webEx)
            {
                throw;
            }
            catch (Exception ex)
                {
                

                throw;
                }

            return new Tuple<string, HttpStatusCode>(resultContent, statusCode);
            }


        public async Task<Tuple<String, HttpStatusCode>> Delete(string ID, string Token)
            {

            string resultContent = null;
            HttpStatusCode statusCode;
            try
                {
                using (var client = new HttpClient())
                    {
                    client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", Token));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApplicationConstants.CONTENT_TYPE));
                    client.BaseAddress = new Uri(ApplicationConstants.BASE_URL);
                    var content = new FormUrlEncodedContent(new[]
                    {
                new KeyValuePair<string, string>("", ID)
                });
                    var result = await client.DeleteAsync(url);
                    statusCode = result.StatusCode;
                    resultContent = await result.Content.ReadAsStringAsync();

                    }
                }
            catch (Exception ex)
                {

                throw;
                }

            return new Tuple<string, HttpStatusCode>(resultContent, statusCode);

            }


        public async Task<Tuple<String, HttpStatusCode>> Put(string body, string Token)
            {
            string resultContent = null;
            System.Net.HttpStatusCode statusCode;
            try
                {
                using (var client = new HttpClient())
                    {


                    client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", Token));
                    
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApplicationConstants.CONTENT_TYPE));

                    HttpContent hc = new StringContent(body, UnicodeEncoding.UTF8, "application/json");
                        
                        hc.Headers.Add("Content-Language", "en-GB");

               
                    var result = client.PutAsync(ApplicationConstants.BASE_URL + url, hc).Result;
                        statusCode = result.StatusCode;
                        resultContent = await result.Content.ReadAsStringAsync();





                    //    client.BaseAddress = new Uri(ApplicationConstants.BASE_URL);
                    //client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", Token));
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApplicationConstants.CONTENT_TYPE));


                    //var stringContent = new StringContent(body, UnicodeEncoding.UTF8, "application/json");
                    //var result = client.PutAsync(url, stringContent).Result;
                    //statusCode = result.StatusCode;
                    //resultContent = result.Content.ReadAsStringAsync().Result;
                    }
                }
            catch (Exception ex)
                {

                throw;
                }

            return new Tuple<string, HttpStatusCode>(resultContent, statusCode);
            }


        }
    }
