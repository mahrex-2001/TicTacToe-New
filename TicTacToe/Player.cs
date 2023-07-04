using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Player
    {
        public string Name;
        public string Symbol;

        // constructor
        public Player(string name, string symbol)
        {
            Name = name;
            Symbol = symbol;
        }
    }
}