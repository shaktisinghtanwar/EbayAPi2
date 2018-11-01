using EbaySdkLib.Services;
namespace EbaySdkLib
{
   public  class  FulFillmentApiService
   {
        public string Token { get;private set; }
        public FulFillmentApiService(string token)
            {
            Token = token;
        OrderService = new OrderService(token);
            }

       
       public OrderService OrderService { get; set; }
   }

}
