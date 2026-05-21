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
                        view.ListPlayers(playerList);
                        break;
                    case "3":
                        ListPlayersWithScoreGreaterThan(view);
                        break;
                    case "4":
                        SortPlayerList(view);
                        break;
                    case "0":
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
        /// Show all players with a score higher than a user-specified value.
        /// </summary>
        private void ListPlayersWithScoreGreaterThan(IView view)
        {
            Console.Write("\n...higher than: ");
            int minScore = view.AskMinScore();

            view.ListPlayers(GetPlayersWithScoreGreaterThan(minScore));
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
        private void SortPlayerList(IView view)
        {
            PlayerOrder playerOrder = view.AskPlayerOrder();

            switch (playerOrder)
            {
                case PlayerOrder.ByScore:
                    playerList.Sort();
                    break;
                case PlayerOrder.ByName:
                    playerList.SortByName();
                    break;
                case PlayerOrder.ByNameReverse:
                    playerList.SortByNameReverse();
                    break;
                default:
                    view.ErrorMessage("Unknown player order!");
                    break;
            }
        }
    }
}