using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManagerMVC
{
    public class ConsoleView : IView
    {
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
            Console.WriteLine("Press '4' to Order Players;");
            Console.WriteLine("Press '0' to Quit.\n");
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
        public int AskMinScore()
        {
            // Ask the user what is the minimum score
            Console.Write("\n... higher than: ");
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
        public void ListPlayers(IEnumerable<Player> playersToList)
        {
            var list = playersToList.ToList();

            Console.WriteLine("\nListing Players...\n");
            foreach (Player p in list)
            {
                Console.WriteLine($"- Name: {p.Name} --> Score: {p.Score}");
            }
        }
        public PlayerOrder AskPlayerOrder()
        {
            //default or something
            Console.WriteLine("\nPlayer order");
            Console.WriteLine("------------");
            Console.WriteLine(
                $"{(int)PlayerOrder.ByScore}. Order by score");
            Console.WriteLine(
                $"{(int)PlayerOrder.ByName}. Order by name");
            Console.WriteLine(
                $"{(int)PlayerOrder.ByNameReverse}. Order by name (reverse)");
            Console.WriteLine("");
            Console.Write("> ");

            return Enum.Parse<PlayerOrder>(Console.ReadLine());
        }
    }
}