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
    public class ComplianceService
        {
        public string Token { get; private set; }
        public ComplianceService(string token)
            {
        this.Token = Token;
            }

        public async Task<Tuple<GetListingViolationsSummaryResponse, HttpStatusCode>> getListingViolationsSummary(string compliance_type)
            {
        RestHelper helper = new RestHelper(ApplicationConstants.COMPLIANCE_URL + " ?compliance_type = " + compliance_type);
        var response = await helper.Get(Token);
        GetListingViolationsSummaryResponse getListingViolationsSummaryResponse = JsonConvert.DeserializeObject<GetListingViolationsSummaryResponse>(response.Item1);
        return new Tuple<GetListingViolationsSummaryResponse, HttpStatusCode>(getListingViolationsSummaryResponse, response.Item2);
            }


        public async Task<Tuple<GetListingViolationsResponse, HttpStatusCode>> getListingViolations(string compliance_type, int offset, string listing_id, int limit)
            {
        RestHelper helper = new RestHelper(ApplicationConstants.LISTINGVIOLATION_URL + "?compliance_type=" + compliance_type + "offset" + offset + "listing_id" + listing_id + "limit" + limit);
        var response = await helper.Get(Token);
        GetListingViolationsResponse getListingViolationsResponse = JsonConvert.DeserializeObject<GetListingViolationsResponse>(response.Item1);
        return new Tuple<GetListingViolationsResponse, HttpStatusCode>(getListingViolationsResponse, response.Item2);
            }


        }
    }
