using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace PlayerManagerMVC
{
    /// <summary>
    /// The player listing program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Program begins here.
        /// </summary>
        /// <param name="args">Not used.</param>
        private static void Main()
        {
            // Initialize the player list with two players using collection
            // initialization syntax
            PlayerList playerList = new PlayerList() {
                new Player("Best player ever", 100),
                new Player("An even better player", 500),
                new Player("Freddy", 125),
                new Player("Chica", 200),
                new Player("Daniel", 150)
            };

            IView view = new ConsoleView();

            // Instantiate Controller
            Controller controller = new Controller(playerList);

            // Start the program instance
            controller.Run(view);
        }
    }
}