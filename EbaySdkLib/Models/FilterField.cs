using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
   public  class FilterField
    {
    public string  field {get;set;}
    public RangeValue[] range{get; set;}
    public string[] set{get;set;}
    public string value {get;set;}

    }
}
