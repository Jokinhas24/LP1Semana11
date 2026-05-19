using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManagerMVC
{
    public interface IView
    {
        string Input();
        void ShowMenu();
        void Welcome();
        void ExitMessage();
        void ErrorMessage();
        void WaitForUser();
        (string, int) AskPlayerData();
        int AskMinScore();
        void InsertMessage(string Inserter);
        void ListPlayers(IEnumerable<Player> playersToList);
    }
}