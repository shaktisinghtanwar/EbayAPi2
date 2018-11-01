using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
    public class RangeValue
    {
       public string  end {get;set;}
       public bool exclusiveEnd { get; set; }
       public bool exclusiveStart{get;set;}
       public bool range {get;set;}
       public string start{get;set;}


    }
}
