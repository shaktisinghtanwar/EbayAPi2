using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
   public  class GetListingSetResponse
    {
        public string href { get; set; }
        public string limit { get; set; }
        public List<Listing> listings { get; set; }
        public string next { get; set; }
        public string offset { get; set; }
        public string prev { get; set; }
        public string total { get; set; }
        public List<Warnings> warnings { get; set; }
    }
}
