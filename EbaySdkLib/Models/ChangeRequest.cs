using EbaySdkLib.Enums;
using EbaySdkLib.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
    public class ChangeRequest
    {
        public string changeRequestId { get; set; }
        public ChangeRequestStatusEnum changeRequestStatus { get; set; }
        public ChangeRequestTypeEnum changeRequestType { get; set; }
        public string creationDate { get; set; }
        public string expectedCompletionDate { get; set; }
        public ProcessResolution processResolution { get; set; }
        public string processStatusMessage { get; set; }
        public string reasonForChangeRequest { get; set; }
        public string referenceId { get; set; }
        public ReferenceTypeEnum referenceType { get; set; }
        public string resolutionDate { get; set; }
        public SuggestedProduct[] suggestedProduct { get; set; }
    }
}
