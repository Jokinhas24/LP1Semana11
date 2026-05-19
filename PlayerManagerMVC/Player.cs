using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManagerMVC
{
    public class Player : IComparable<Player>
    {
        public string Name {get; }
        public int Score {get; set;}

        public Player (string name, int score)
        {
            Name = name;
            Score = score;
        }
        public int CompareTo(Player other)
        {
            return Score.CompareTo(other.Score);
        }
    }
}