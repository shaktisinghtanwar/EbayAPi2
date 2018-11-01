using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
    {
   public class UpdateInventoryLocationRequest
        {
        public string locationAdditionalInformation { get; set; }
        public string locationInstructions { get; set; }
        public string locationWebUrl { get; set; }
        public string name { get; set; }
        public OperatingHour[] operatingHours { get; set; }
        public string phone { get; set; }
        public SpecialHour[] specialHours { get; set; }
        }
    }
