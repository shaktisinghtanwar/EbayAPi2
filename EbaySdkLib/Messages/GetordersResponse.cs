using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
   public  class GetOrdersResponse
    {

        public string href { get; set; }
        public string limit { get; set; }
        public string next { get; set; }
        public string offset { get; set; }
        public List<Order> orders { get; set; }
        public string prev { get; set; }
        public int  total { get; set; }
        public List<Warnings> warnings { get; set; }
    }
}
