using EbaySdkLib.Constants;
using EbaySdkLib.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Services
    {
    public class AnalyticsService
        {
        public string Token { get; private set; }
        public AnalyticsService(string token)
            {
        this.Token = Token;
            }


        //Shilpa Work
        public async Task<Tuple<GetTrafficReportResponse, HttpStatusCode>> getAnalyticsService(string filter, string dimension, string metric, string sort)
            {
        RestHelper helper = new RestHelper(ApplicationConstants.ANALYTICS_URL + filter + dimension + metric);
        var response = await helper.Get(Token);
        GetTrafficReportResponse getAnalyticsResponse = JsonConvert.DeserializeObject<GetTrafficReportResponse>(response.Item1);
        return new Tuple<GetTrafficReportResponse, HttpStatusCode>(getAnalyticsResponse, response.Item2);
            }


        public async Task<Tuple<FindSellerStandardsProfilesResponse, HttpStatusCode>> findSellerStandardsProfilesResponseAnalyticsService()
            {
        RestHelper helper = new RestHelper(ApplicationConstants.SELLER_STANDARDS_URL);
        var response = await helper.Get(Token);
        FindSellerStandardsProfilesResponse findSellerStandardsProfilesAnalyticsResponse = JsonConvert.DeserializeObject<FindSellerStandardsProfilesResponse>(response.Item1);
        return new Tuple<FindSellerStandardsProfilesResponse, HttpStatusCode>(findSellerStandardsProfilesAnalyticsResponse, response.Item2);
            }

        //LodhiSir
        public async Task<Tuple<getSellerStandardsProfileResponse, HttpStatusCode>> getSellerStandards(getSellerStandardsProfileResponse getSellerStandards, string cycle)
            {
        RestHelper helper = new RestHelper(ApplicationConstants.SELLER_ANALYTICS_URL + "/" + getSellerStandards.cycle + "/" + cycle);
        var response = await helper.Get(Token);
        getSellerStandardsProfileResponse getSellerStandardsResponse = JsonConvert.DeserializeObject<getSellerStandardsProfileResponse>(response.Item1);
        return new Tuple<getSellerStandardsProfileResponse, HttpStatusCode>(getSellerStandardsResponse, response.Item2);
            }
        }
    }
