using EbaySdkLib.Messages;
namespace EbaySdkLib.Models
{
    public class Violation
    {
        public string reasonCode { get; set; }
        public string message { get; set; }
        public Variation[] variation { get; set; }
        public ViolationData[] violationData { get; set; }
        public CorrectiveRecommendations[] correctiveRecommendations { get; set; }
    }
}