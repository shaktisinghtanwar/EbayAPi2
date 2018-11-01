using EbaySdkLib.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
   public  class CancelStatus
    {

        public string cancelledDate { get; set; }
        public  CancelRequest[] cancelRequests { get; set; }
         [JsonConverter(typeof(StringEnumConverter))]
        public CancelStateEnum cancelState { get; set; }
    }
}
