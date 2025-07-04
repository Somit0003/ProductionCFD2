
namespace ProductionCFD2.Models
{
    internal class PrecisionAttribute : Attribute
    {
        private int v1;
        private int v2;

        public PrecisionAttribute(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}