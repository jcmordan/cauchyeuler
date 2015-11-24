using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cauchyeuler.library;

namespace cauchyeuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Couchy Euler's Ecuation Solver");
            Console.WriteLine("a1 * x^n * d(n)y/dx^n + a2 * x^n-1 * d(n-1)y/dx^n-1 + ... + a3 * y(0)}");
            Console.Write("Enter the diferential equation: ");
            string equation = Console.ReadLine();

            if (equation.Trim() == "")
            {
                Console.WriteLine("Invalid ecuation!");
            }

            var cauchy = new CauchyEuler(equation);
            var result = cauchy.Solve();
            Console.ReadLine();
        }
    }
}
