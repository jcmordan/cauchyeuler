using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cauchyeuler.library
{
    public class Term
    {
        public int Coeficient { get; set; }
        public string X { get; set; }
        public int XExponent { get; set; }
        public string Y { get; set; }        
        public int DerivateOrder { get; set; }

        public Term(string x, string y, int coeficient, int exponent, int derivateOrder)
        {
            this.X = x;
            this.Y = y;
            this.Coeficient = coeficient;
            this.XExponent = exponent;
            this.DerivateOrder = derivateOrder;
        }
    }
}
