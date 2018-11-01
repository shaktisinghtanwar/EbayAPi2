using EbaySdkLib.Messages;
using Newtonsoft.Json;
using System.Threading.Tasks;
using EbaySdkLib.Models;
using System.Net;
using System;
using EbaySdkLib.Constants;

namespace EbaySdkLib 
{
  public  class   ProgramService
    {
      private string Token;

      public ProgramService(string Token)
          {
      // TODO: Complete member initialization
      this.Token = Token;
          }

      public async Task<Tuple<GetOptedInProgramsResponse, HttpStatusCode>> GetOptedprogram(GetOptedInProgramsRequest getOptedInProgramsRequest)
      {


      RestHelper helper = new RestHelper(ApplicationConstants.PROGRAM_URL+ "/" + "get_opted_in_programs");
          var response = await helper.Get(Token);

          GetOptedInProgramsResponse getOptedInProgramsResponse = JsonConvert.DeserializeObject<GetOptedInProgramsResponse>(response.Item1);
          return new Tuple<GetOptedInProgramsResponse, HttpStatusCode>(getOptedInProgramsResponse, response.Item2);
      }


     // //Not match this response  with ebay response due to bad filed in taken from programtypeEnum
     // Error not match with ebay
      public async Task<Tuple<OptInToProgramResponse,HttpStatusCode>> OplnToprogram(OptInToProgramRequest optInToProgramRequest)
      {
          var body = JsonConvert.SerializeObject(optInToProgramRequest);

          RestHelper helper = new RestHelper(ApplicationConstants.PROGRAM_URL + "/" + "opt_in");
          var response = await helper.Post(body, Token);

          OptInToProgramResponse optInToProgramResponse = JsonConvert.DeserializeObject<OptInToProgramResponse>(response.Item1);
          return new Tuple<OptInToProgramResponse, HttpStatusCode>(optInToProgramResponse, response.Item2);
      }

   
      
      ////Not match this response  with ebay response due to bad filed in taken from programtypeEnum
      //Not success 
      public async Task<Tuple<OptOutOfProgramResponse, HttpStatusCode>> OutPutOfProgram(OptOutOfProgramRequest optOutOfProgramRequest)
      {
          var body = JsonConvert.SerializeObject(optOutOfProgramRequest);

          RestHelper helper = new RestHelper(ApplicationConstants.PROGRAM_URL + "/" + "opt_out");
          var response = await helper.Post(body, Token);

          OptOutOfProgramResponse optOutOfProgramResponse = JsonConvert.DeserializeObject<OptOutOfProgramResponse>(response.Item1);
          return new Tuple<OptOutOfProgramResponse, HttpStatusCode>(optOutOfProgramResponse, response.Item2);
      }


    }
}
