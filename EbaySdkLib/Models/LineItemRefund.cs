using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
   public  class LineItemRefund
    {
       
    public Amount amount { get; set; }
    public string refundDate { get; set; }
    public string refundReferenceId { get; set; }
    }
}
