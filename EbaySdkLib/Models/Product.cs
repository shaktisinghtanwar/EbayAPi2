using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
    {
  public  class Product
        {
        public AspectValues[] aspects { get; set; }
        public string brand { get; set; }
        public string description { get; set; }
        public string[] imageUrls { get; set; }
        public string mpn { get; set; }
        public string subtitle { get; set; }
        public string title { get; set; }
        public string[] isbn { get; set; }
        public string[] upc { get; set; }
        public string[] ean { get; set; }
        public string epid { get; set; }
        }
    }
