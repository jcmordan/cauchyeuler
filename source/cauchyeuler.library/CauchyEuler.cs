using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cauchyeuler.library
{
    public class CauchyEuler
    {
        private string equation;
        public CauchyEuler(string equation)
        {
            this.equation = equation;
        }

        public string Solve()
        {
            var terms = GetEcuationTerms(this.equation);
            var ecuationOrder = terms.Max(term => term.DerivateOrder);

            if (ecuationOrder > 3)
            {
                return "El order de la ecuacon esta fuera del alacence de esta applicacion, favor introduzca una ecuacion de orden 3 o menor!";
            }

            return "";
        }

        private List<Term> GetEcuationTerms(string equation)
        {
            var terms = new List<Term>();
            foreach (var character in equation)
            {
                var sing = equation[0] == '-' ? '-' : '+';
                if (equation[0] == '-' || equation[0] == '+')
                {
                    equation = equation.Remove(0, 1).Trim();
                }
               
                if (character == '+' || character == '-')
                {
                    var stringTerm = equation.Substring(0, equation.IndexOf(character));

                    var term = CreateTerm(stringTerm.Trim(), sing);
                    terms.Add(term);
                    equation = equation.Remove(0, equation.IndexOf(character));                 
                }                
            }
            return terms;
        }

        private Term CreateTerm(string stringTerm, char sing)
        {          
            var termElements = stringTerm.Split('*').ToList();
            var coeficient =  1;

            if(termElements.Count == 3)
            {
                coeficient = int.Parse(termElements[0].Trim());
                termElements.RemoveAt(0);
            }           
            coeficient = sing == '+' ? coeficient : -1 * coeficient;

            var x = "x";
            var xExponent = 0;
            if (termElements.Count == 2)
            {
                var variableParts = termElements[0].Trim().Split('^');             
                xExponent = variableParts.Length == 2 ? int.Parse(variableParts[1]) : 0;
                termElements.RemoveAt(0);
            }

            var y = "y";
            var derevateTerm = termElements[0].Trim().Substring(1, termElements[0].Trim().Length - 1);

            return new Term(x, y, coeficient, xExponent, derevateTerm.Length);
        }

        private AuxiliarEquation GetAuxiliarEquation(List<Term> terms)
        {
            var y1 =  new List<MTerm> { new MTerm {Coeficient = 1, Exponent= 1}};
            var y2 = new List<MTerm> {new MTerm {Coeficient = 1, Exponent= 2} ,new MTerm {Coeficient = -1, Exponent= 1} };
            var y3 = new List<MTerm> {new MTerm {Coeficient = 1, Exponent= 2} ,new MTerm {Coeficient = -1, Exponent= 1} };
            var nDerivate = new List<List<MTerm>> { y1, y2, y3 };

            foreach (var term in terms)
            {
               var derivate = nDerivate[terms.IndexOf(term)];
               foreach (var mTerm in derivate)
               {
                   mTerm.Coeficient *= term.Coeficient;
               }
            }

            foreach (var y3Term in y3)
            {
                var y2EquvalentTerm = y2.FirstOrDefault(mTerm => mTerm.Exponent == y3Term.Exponent);
                var y1EquivalentTerm = y1.FirstOrDefault(mTerm => mTerm.Exponent == y3Term.Exponent);

                y3Term.Coeficient += y2EquvalentTerm != null ? y2EquvalentTerm.Coeficient : 0;
                y3Term.Coeficient += y1EquivalentTerm != null ? y1EquivalentTerm.Coeficient : 0;
            }

            y3 = y3.Where(mTerm => mTerm.Coeficient != 0).ToList();

            return new AuxiliarEquation { Terms = y3 };
        }
    }
}
