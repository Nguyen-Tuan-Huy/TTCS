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
            string continueRun = "1";
            while(continueRun.CompareTo("1") == 0)
            {
                Console.Clear();
                s.getInfix();
                Console.WriteLine("\n------------------------\nKet qua: \n" + s.countEvaluate());

                Console.WriteLine("------------------------\nNhan '1' de tiep tuc\n------------------------");
                continueRun = Console.ReadLine();
            }


            Console.ReadKey();

        }
    }
}
