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
    public class TaxonomyApiService
        {
        public string Token { get; private set; }
        public TaxonomyApiService(string token)
            {
        this.Token = Token;
            }

        public async Task<Tuple<GetDefaultCategoryTreeIdResponse,HttpStatusCode>> GetDefaultCategoryTreeId(GetDefaultCategoryTreeIdRequest request)
            {
        string url = "commerce/taxonomy/v1_beta/get_default_category_tree_id?marketplace_id={0}";

        RestHelper helper = new RestHelper(string.Format(url, request.marketplace_id));
        var response = await helper.Get(Token);

        GetDefaultCategoryTreeIdResponse getFulfillmentPolicyByNameResponse = JsonConvert.DeserializeObject<GetDefaultCategoryTreeIdResponse>(response.Item1);
        return new Tuple<GetDefaultCategoryTreeIdResponse, HttpStatusCode>(getFulfillmentPolicyByNameResponse, response.Item2);

            }
        public async Task<Tuple<GetItemAspectsForCategoryResponse,HttpStatusCode>> GetItemAspectsForCategory(GetItemAspectsForCategoryRequest request)
            {
        string url = "commerce/taxonomy/v1_beta/category_tree/{0}/get_item_aspects_for_category?category_id ={1}";

        RestHelper helper = new RestHelper(string.Format(url, request.category_tree_id, request.category_id));
        var response = await helper.Get(Token);

        GetItemAspectsForCategoryResponse serlializedResponse = JsonConvert.DeserializeObject<GetItemAspectsForCategoryResponse>(response.Item1);
        return new Tuple<GetItemAspectsForCategoryResponse, HttpStatusCode>(serlializedResponse, response.Item2);

            }

        public async Task<Tuple<GetCategorySuggestionsResponse,HttpStatusCode>> GetCategorySuggestions(GetCategorySuggestionsRequest request)
            {
        string url = "commerce/taxonomy/v1_beta/category_tree/{0}/get_category_suggestions?q={1}";

        RestHelper helper = new RestHelper(string.Format(url, request.category_tree_id, request.q));
        var response = await helper.Get(Token);

        GetCategorySuggestionsResponse serlializedResponse = JsonConvert.DeserializeObject<GetCategorySuggestionsResponse>(response.Item1);
        return new Tuple<GetCategorySuggestionsResponse, HttpStatusCode>(serlializedResponse, response.Item2);

            }

        public async Task<Tuple<GetCategorySubtreeResponse,HttpStatusCode>> GetCategorySubtree(GetCategorySubtreeRequest request)
            {
        string url = "commerce/taxonomy/v1_beta/category_tree/{0}/get_category_subtree?category_id ={1}";

        RestHelper helper = new RestHelper(string.Format(url, request.category_tree_id, request.category_id));
        var response = await helper.Get(Token);

        GetCategorySubtreeResponse serlializedResponse = JsonConvert.DeserializeObject<GetCategorySubtreeResponse>(response.Item1);
        return new Tuple<GetCategorySubtreeResponse, HttpStatusCode>(serlializedResponse, response.Item2);

            }

        public async Task<Tuple<GetCategoryTreeResponse, HttpStatusCode>> GetCategoryTree()
            {
        string url = "commerce/taxonomy/v1_beta/category_tree/{0}";

        RestHelper helper = new RestHelper(string.Format(url));
        var response = await helper.Get(Token);

        GetCategoryTreeResponse serlializedResponse = JsonConvert.DeserializeObject<GetCategoryTreeResponse>(response.Item1);
        return new Tuple<GetCategoryTreeResponse, HttpStatusCode>(serlializedResponse, response.Item2);

            }
        }








    }
