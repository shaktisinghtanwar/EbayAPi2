using EbaySdkLib.Constants;
using EbaySdkLib.Messages;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Threading.Tasks;
namespace EbaySdkLib
{
   public  class PrivilegeService
    {
       private string Token;
      
       public PrivilegeService(string Token)
           {
       // TODO: Complete member initialization
              this.Token = Token;
           
           }
      
     public async Task<Tuple<GetPrivilegesResponse,HttpStatusCode>>  GetPrivilage()
     {


     RestHelper helper = new RestHelper(ApplicationConstants.PRIVILAGE_URL + "/");
         var response = await helper.Get(Token);

         GetPrivilegesResponse getPrivilegesResponse = JsonConvert.DeserializeObject<GetPrivilegesResponse>(response.Item1);
         return new Tuple<GetPrivilegesResponse, HttpStatusCode>(getPrivilegesResponse, response.Item2);

     }

    }
}
