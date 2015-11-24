using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cauchyeuler.library
{
    public class AuxiliarEquation
    {
        public List<MTerm> Terms { get; set; }
    }

    public class MTerm
    {
        public int Coeficient { get; set; }
        public string Variable { get{ return "m";} }
        public int Exponent {get;set;}
    }
}
