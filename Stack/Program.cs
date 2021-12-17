using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack s = new Stack();
            s.getInfix();
            //s.countEvaluate();
            Console.WriteLine("\nKet qua: " + s.countEvaluate());

            Console.ReadKey();

        }
    }
}
