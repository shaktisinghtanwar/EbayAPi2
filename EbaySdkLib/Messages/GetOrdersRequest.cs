using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
  public   class GetOrdersRequest
    {
      public string offset { get; set; }
      public string limit { get; set; }
      public FilterField[] filterField { get; set; }
      public string[] ordersiId { get; set; }
    }
}
