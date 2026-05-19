using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PlayerManagerMVC
{
    public class Controller
    {
        private readonly PlayerList playerList;
        public Controller(PlayerList playerList)
        {
            this.playerList = playerList;
        }
        /// <summary>
        /// Start the player listing program instance
        /// </summary>
        public void Run(IView view)
        {
            // We keep the user's option here
            string option;

            // Main program loop
            do
            {
                // Show menu and get user option
                view.ShowMenu();
                option = view.Input();

                // Determine the option specified by the user and act on it
                switch (option)
                {
                    case "1":
                        InsertPlayer(view);
                        break;
                    case "2":
                        ListPlayers(playerList);
                        break;
                    case "3":
                        view.ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        view.ExitMessage();
                        break;
                    default:
                        view.ErrorMessage("Unknown option!");
                        break;
                }

                // Wait for user to press a key...  
                if (option != "4")
                {
                    view.WaitForUser();
                }

                // Loop keeps going until players choses to quit (option 4)
            } while (option != "4");
        }
        /// <summary>
        /// Inserts a new player in the player list.
        /// </summary>
        private void InsertPlayer(IView view)
        {
            (string name, int score) = view.AskPlayerData();

            // Create new player to add it to list
            playerList.Add(new Player(name, score));

            view.InsertMessage("Player");
        }
        /// <summary>
        /// Show all players in a list of players. This method can be static
        /// because it doesn't depend on anything associated with an instance
        /// of the program. Namely, the list of players is given as a parameter
        /// to this method.
        /// </summary>
        /// <param name="playersToList">
        /// An enumerable object of players to show.
        /// </param>
        private static void ListPlayers(IEnumerable<Player> playersToList)
        {
            Console.WriteLine("\nDo you wish to order by alphabetic order?");
            Console.WriteLine("IF so Press '1' for ascending or '2' for descending: ");
            Console.WriteLine("(Leave empty to order by score)");
            Console.Write("\nYour option: ");
            PlayerOrder option = Console.ReadLine();
            view.AskPlayerOrder();

            var list = playersToList.ToList();

            if (option == PlayerOrder.ByScore)
            {
                list.Sort();
            }
            else if (option == PlayerOrder.ByName)
            {
                IComparer<Player> compareByName = new CompareByName(true);
                list.Sort(compareByName);
            }
            else if (option == PlayerOrder.ByNameReverse)
            {
                IComparer<Player> compareByNameReverse = new CompareByName(false);
                list.Sort(compareByNameReverse);
            }

            Console.WriteLine("\nListing Players...\n");
            foreach (Player p in list)
            {
                Console.WriteLine($"- Name: {p.Name} --> Score: {p.Score}");
            }
        }
        /// <summary>
        /// Show all players with a score higher than a user-specified value.
        /// </summary>
        private void ListPlayersWithScoreGreaterThan(IView view)
        {
            Console.Write("\n...higher than: ");
            int minScore = view.AskMinScore();

            ListPlayers(GetPlayersWithScoreGreaterThan(minScore));
        }
        /// <summary>
        /// Get players with a score higher than a given value.
        /// </summary>
        /// <param name="minScore">Minimum score players should have.</param>
        /// <returns>
        /// An enumerable of players with a score higher than the given value.
        /// </returns>
        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            foreach (Player player in playerList)
            {
                if (player.Score > minScore)
                {
                    yield return player;
                }
            }
        }
    }
}