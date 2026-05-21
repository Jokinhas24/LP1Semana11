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
        void ErrorMessage(string msg);
        void WaitForUser();
        (string, int) AskPlayerData();
        void InsertMessage(string Inserter);
        int AskMinScore();
        void ListPlayers(IEnumerable<Player> playersToList);
        PlayerOrder AskPlayerOrder();
    }
}