using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManagerMVC
{
    public class ConsoleView : IView
    {
        public ConsoleView(Controller controller)
        {
            
        }
        public string Input()
        {
            return Console.ReadLine();
        }
        /// <summary>
        /// Shows the main menu.
        /// </summary>
        public void ShowMenu()
        {
            Console.WriteLine("Choose one:\n");
            Console.WriteLine("Press '1' to Insert a new Player;");
            Console.WriteLine("Press '2' to List all Players;");
            Console.WriteLine("Press '3' to Show Players with scores higher than...;");
            Console.WriteLine("Press '4' to Quit.\n");
            Console.Write("Your option: ");
        }
        public void Welcome()
        {
            Console.WriteLine("\n>>>> Welcome to Jokinhas24's Player Manager! <<<<\n");
        }
        public void ExitMessage()
        {
            Console.WriteLine("\nQuitting...");
        }
        public void ErrorMessage(string msg)
        {
            Console.Error.WriteLine($"\n>>> {msg} <<<\n");
        }
        public void WaitForUser()
        {
            // Wait for user to press a key...
            Console.Write("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine("\n");
        }
        public (string, int) AskPlayerData()
        {
            Console.Write("\nInsert that Player's name: ");
            string name = Console.ReadLine();
            Console.Write("Insert that Player's score: ");
            int score = int.Parse(Console.ReadLine());

            return (name, score);
        }
        public void InsertMessage(string Inserter)
        {
            Console.WriteLine($"\nInserting New {Inserter}...");
        }
        public PlayerOrder AskPlayerOrder()
        {
            Console.WriteLine("\nDo you wish to order by alphabetic order?");
            Console.WriteLine("IF so Press '1' for ascending or '2' for descending: ");
            Console.WriteLine("(Leave empty to order by score)");
            Console.Write("\nYour option: ");
            PlayerOrder option = Console.ReadLine();
        }
        public int AskMinScore()
        {
            Console.Write("\n...higher than: ");
            return int.Parse(Console.ReadLine());
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
            PlayerOrder option = AskPlayerOrder();

            var list = playersToList.ToList();
            // Aqui fazer Case 

            if (option == PlayerOrder.ByScore)
            {
                list.Sort();
            }
            else if (option == PlayerOrder.ByName)
            {
                list.Sort(compareByName);
            }
            else if (option == PlayerOrder.ByNameReverse)
            {
                list.Sort(compareByNameReverse);
            }
            //default or something

            Console.WriteLine("\nListing Players...\n");
            foreach (Player p in list)
            {
                Console.WriteLine($"- Name: {p.Name} --> Score: {p.Score}");
            }
        }
        public PlayerOrder AskPlayerOrder()
        {
            Console.WriteLine("\nDo you wish to order by alphabetic order?");
            Console.WriteLine("IF so Press '1' for ascending or '2' for descending: ");
            Console.WriteLine("(Leave empty to order by score)");
            Console.Write("\nYour option: ");
            Console.ReadLine();
        }
    }
}