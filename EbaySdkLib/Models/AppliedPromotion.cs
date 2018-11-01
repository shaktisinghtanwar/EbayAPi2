using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
  public   class AppliedPromotion
    {
    public string  description {get;set;}
    public Amount discountAmount {get;set;}
    public string promotionId { get; set; }

    }
}
