using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PlayerManagerMVC
{
    public class CompareByName : IComparer<Player>
    {
        private bool ascending;
        public CompareByName(bool ascending)
        {
            this.ascending = ascending;
        }
        public int Compare(Player player, Player other)
        {
            if (player == null || other == null) return 0;

            int result = player.Name.CompareTo(other.Name);

            return ascending ? result : -result;
        }
    }
}