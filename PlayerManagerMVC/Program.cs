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
        /// The list of all players.
        /// </summary>
        private PlayerList playerList;
        private IView view;
        /// <summary>
        /// Program begins here.
        /// </summary>
        private static void Main()
        {
            // Create a new instance of the player listing program
            Program prog = new Program();

            IView view = new ConsoleView(controller, model);
        }

        /// <summary>
        /// Creates a new instance of the player listing program.
        /// </summary>
        private Program()
        {
            // Instantialize player comparers
            IComparer<Player> compareByName = new CompareByName(true);
            IComparer<Player> compareByNameReverse = new CompareByName(false);

            // Initialize the player list with two players using collection
            // initialization syntax
            playerList = new PlayerList() {
                new Player("Best player ever", 100),
                new Player("An even better player", 500),
                new Player("Freddy", 125),
                new Player("Chica", 200),
                new Player("Daniel", 150)
            };
            // Instantiate Controller
            Controller controller = new controller;

            view = new ConsoleView(controller);

            // Start the program instance
            controller.Run(view);
        }
    }
}