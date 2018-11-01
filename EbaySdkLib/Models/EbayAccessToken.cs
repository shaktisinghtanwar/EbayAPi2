using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
    public class EbayAccessToken
    {
        public bool IsError { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorID { get; set; }
        public string Domain { get; set;}

        public string SubDomain { get; set; }
        
        public string ErrorCategory { get; set; }
        public string Message { get; set;}
        public string LongMessage { get; set; }
        public string InputRefIds { get; set; }  //Array
        public string OutputRefIds { get; set; } //array
        public string ErrorParameters { get; set; } //array

        public string AccessToken { get; set; }
        public int? ExpiredTime { get; set; }

        public string RefreshToken { get; set; }

        public int? RefreshTokenExpires { get; set; }


      
    }

   
}
