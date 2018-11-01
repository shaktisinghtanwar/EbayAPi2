using EbaySdkLib.Models;

namespace EbaySdkLib.Messages
{
    public class Aspect
    {
        public string localizedName { get; set; }
        public string[] localizedValues { get; set; }

        public string aspectHelpText { get; set; }
        public Constraint[] constraint { get; set; }
        public bool droppable { get; set; }
        public string name { get; set; }
        public Value[] values { get; set; }
        public string[] valuesAssociatedWithProduct { get; set; }
    }
}