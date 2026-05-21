using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;

namespace StringGenerator
{
    public class Controller
    {
        private readonly string chars;
        private readonly int seed;
        public Controller(int seed)
        {
            // Keep the player list (part of the model)
            this.seed = seed;
        }
        public string Generate(int seed, int length = 16)
        {
            Random rng = new Random(seed);

            StringBuilder result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = rng.Next(Model.chars.Length);
                result.Append(Model.chars[index]);
            }

            return result.ToString();
        }
        public void Run(View view)
        {
            view.Output(Generate(seed));
        }
    }
}