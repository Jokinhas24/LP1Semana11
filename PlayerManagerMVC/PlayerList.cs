using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManagerMVC
{
    /// <summary>
    /// The PlayerList class is part of the Model in this MVC implementation.
    /// </summary>
    public class PlayerList : List<Player>
    {
        // Player comparers (these are part of the Model)
        private readonly IComparer<Player> compareByName;
        private readonly IComparer<Player> compareByNameReverse;

        /// <summary>
        /// The constructor, invokes the base (List<T>) constructor, and
        /// initializes the player comparers.
        /// </summary>
        public PlayerList() : base()
        {
            // Initialize player comparers (also part of the model)
            compareByName = new CompareByName(true);
            compareByNameReverse = new CompareByName(false);
        }

        /// <summary>
        /// Get players with a score higher than a given value.
        /// </summary>
        /// <param name="minScore">Minimum score players should have.</param>
        /// <returns>
        /// An enumerable of players with a score higher than the given value.
        /// </returns>
        public IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            // Cycle all players in the original player list
            foreach (Player p in this)
            {
                // If the current player has a score higher than the
                // given value....
                if (p.Score > minScore)
                {
                    // ...return him as a member of the player enumerable
                    yield return p;
                }
            }
        }

        public void SortByName()
        {
            // Invokes Sort() on the base List<T> class
            Sort(compareByName);
        }

        public void SortByNameReverse()
        {
            // Invokes Sort() on the base List<T> class
            Sort(compareByNameReverse);
        }

    }
}