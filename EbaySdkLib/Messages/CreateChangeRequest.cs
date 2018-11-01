using EbaySdkLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
    public class CreateChangeRequest
    {
        public ChangeRequestTypeEnum changeRequestType { get; set; }
        public string reasonForChangeRequest { get; set; }
        public string referenceId { get; set; }
        public ReferenceTypeEnum referenceType { get; set; }
        public SuggestedProduct suggestedProduct { get; set; }
    }
}
