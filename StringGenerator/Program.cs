using System;
using System.Text;

namespace StringGenerator
{

    public class Generator
    {
        private const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string Generate(int seed, int length = 16)
        {
            Random rng = new Random(seed);

            StringBuilder result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = rng.Next(chars.Length);
                result.Append(chars[index]);
            }

            return result.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int seed = int.Parse(args[0]);

            string output = Generator.Generate(seed);

            Console.WriteLine(output);
        }
    }
}