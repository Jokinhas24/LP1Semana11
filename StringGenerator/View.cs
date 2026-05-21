using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StringGenerator
{
    public class View
    {
        public void Output(string output)
        {
            Console.WriteLine(output);
        }
        public void Exit()
        {
            Console.WriteLine("Nope");
        }
    }
}