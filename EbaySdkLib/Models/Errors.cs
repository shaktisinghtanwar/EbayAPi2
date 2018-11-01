
namespace EbaySdkLib.Models
{
    public class Errors
    {

        public int errorId { get; set; }

        public string domain { get; set; }

        public string subDomain { get; set; }

        public string category { get; set; }

        public string message { get; set; }

        public Parameters[] parameters  {get;set;}

    }
}
