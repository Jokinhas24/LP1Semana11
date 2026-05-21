using System;
using System.Text;

namespace StringGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate View
            View view = new View();

            // Instantiate Controller
            Controller controller = new Controller(int.Parse(args[0]));

            // Start the program instance
            controller.Run(view);
        }
    }
}