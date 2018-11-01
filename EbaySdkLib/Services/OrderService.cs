using EbaySdkLib.Constants;
using EbaySdkLib.Messages;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
namespace EbaySdkLib.Services
    {
    public class OrderService
        {
        private string Token;

        public OrderService(string Token)
            {
        // TODO: Complete member initialization
        this.Token = Token;
            }

        public async Task<Tuple<GetOrderResponse, HttpStatusCode>> GetOrder(string orderId)
            {
        RestHelper helper = new RestHelper(ApplicationConstants.ORDER_URL + orderId);
        var response = await helper.Get(Token);
        GetOrderResponse getOrderResponse = JsonConvert.DeserializeObject<GetOrderResponse>(response.Item1);
        return new Tuple<GetOrderResponse, HttpStatusCode>(getOrderResponse, response.Item2);
            }
        public async Task<Tuple<GetOrdersResponse, HttpStatusCode>> GetOrders(string filter, string limit, string offset)
            {
        RestHelper helper = new RestHelper(ApplicationConstants.ORDERS_URL + "?filter=creationdate:" + filter + "&limit=" + limit + "&offset=" + offset);
            var response = await helper.Get(Token).ConfigureAwait(false) ;
        GetOrdersResponse getOrdersResponse = JsonConvert.DeserializeObject<GetOrdersResponse>(response.Item1);
        return new Tuple<GetOrdersResponse, HttpStatusCode>(getOrdersResponse, response.Item2);

            }



        public async Task<Tuple<CreateShippingFulfillmentResponse, HttpStatusCode>> CreateShippingFullfilment(CreateShippingFulfillmentRequest createShippingFulfillmentRequest, string orderId)
            {
        var body = JsonConvert.SerializeObject(createShippingFulfillmentRequest);
        RestHelper helper = new RestHelper(ApplicationConstants.ORDER_URL + orderId + "/" + "shipping_fulfillment");
        var response = await helper.Post(body, Token);
        CreateShippingFulfillmentResponse createShippingFulfillmentResponse = JsonConvert.DeserializeObject<CreateShippingFulfillmentResponse>(response.Item1);
        return new Tuple<CreateShippingFulfillmentResponse, HttpStatusCode>(createShippingFulfillmentResponse, response.Item2);
            }
        public async Task<Tuple<GetShippingFulfillmentResponse, HttpStatusCode>> GetShippingFulfillment(string orderid, string fulfillmentId)
            {
        RestHelper helper = new RestHelper(ApplicationConstants.ORDER_URL + orderid + "/" + "shipping_fulfillment" + "/" + fulfillmentId);
        var response = await helper.Get(Token);
        GetShippingFulfillmentResponse getShippingFulfillmentResponse = JsonConvert.DeserializeObject<GetShippingFulfillmentResponse>(response.Item1);
        return new Tuple<GetShippingFulfillmentResponse, HttpStatusCode>(getShippingFulfillmentResponse, response.Item2);
            }
        public async Task<Tuple<GetShippingFulfillmentsResponse, HttpStatusCode>> GetShippingFulfillments(string orderId)
            {
        RestHelper helper = new RestHelper(ApplicationConstants.ORDER_URL + orderId + "/" + "shipping_fulfillment");
        var response = await helper.Get(Token);
        GetShippingFulfillmentsResponse getShippingFulfillmentsResponse = JsonConvert.DeserializeObject<GetShippingFulfillmentsResponse>(response.Item1);
        return new Tuple<GetShippingFulfillmentsResponse, HttpStatusCode>(getShippingFulfillmentsResponse, response.Item2);
            }



        }
    }
