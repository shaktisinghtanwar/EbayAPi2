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
  public   class CancelRequest
    {

        public string cancelCompletedDate { get; set; }
        public string cancelInitiator { get; set; }
        public string cancelReason { get; set; }
        public string cancelRequestedDate { get; set; }
        public string cancelRequestId { get; set; }
         [JsonConverter(typeof(StringEnumConverter))]
        public CancelRequestStateEnum cancelRequestState { get; set; }
    }
}
