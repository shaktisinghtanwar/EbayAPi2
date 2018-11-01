using SellingTools_Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTools_Lib.Models
{
    public class AccessTokenInfo
    {

        public AccessTokenType AccessType { get; set; }
        public string AccessToken { get; set;}
        public string RefreshToken { get; set; }
        public DateTime AccessTokenExpiryDate { get; set; }
        public DateTime RefreshTokenExpiryDate { get; set; }


    }
}
