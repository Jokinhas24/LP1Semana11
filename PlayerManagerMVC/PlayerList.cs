using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManagerMVC
{
    public class PlayerList : List<Player>
    {
        
    }
    private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            foreach (Player player in this)
            {
                if (player.Score > minScore)
                {
                    yield return player;
                }
            }
        }
}