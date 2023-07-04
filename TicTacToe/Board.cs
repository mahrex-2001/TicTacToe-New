using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Board
    {
        private string[,] _playBoard;

        private string[,] _showBoard =
        {
            { "1", "2", "3"},
            { "4", "5", "6"},
            { "7", "8", "9"}
        };

        // constructor 
        public Board()
        {
            Initialize();
        }   

        // initializing the board
        private void Initialize()
        {
            _playBoard = new string[,]
            {
                { " ", " ", " "},
                { " ", " ", " "},
                { " ", " ", " "}
            };
        }

        // displaying the board on the console
        public void Display()
        {
            Console.WriteLine(" {0} | {1} | {2} ", _playBoard[0,0], _playBoard[0,1], _playBoard[0,2]);
            Console.WriteLine("-----------");
            Console.WriteLine(" {0} | {1} | {2} ", _playBoard[1,0], _playBoard[1,1], _playBoard[1,2]);
            Console.WriteLine("-----------");
            Console.WriteLine(" {0} | {1} | {2} ",_playBoard[2,0], _playBoard[2,1], _playBoard[2,2]);
        }

        // display board for demo position
        public void DisplayUser()
        {
            Console.WriteLine(" {0} | {1} | {2} ", _showBoard[0, 0], _showBoard[0, 1], _showBoard[0, 2]);
            Console.WriteLine("-----------");
            Console.WriteLine(" {0} | {1} | {2} ", _showBoard[1, 0], _showBoard[1, 1], _showBoard[1, 2]);
            Console.WriteLine("-----------");
            Console.WriteLine(" {0} | {1} | {2} ", _showBoard[2, 0], _showBoard[2, 1], _showBoard[2, 2]);
        }

        // updating the board with 'X' or 'O'
        public void Update(int row, int col, string sym)
        {
            // updating the board
            _playBoard[row, col] = sym;
        }

        // position is out of bounds
        public bool BeyondLimit(int row, int col)
        {
            // checking if user enterted wrong positions in the board
            if(row > 3 || row < 0 || col > 3 || col < 0)
                return true;

            return false;
        }

        // positon already occupied earlier
        public bool Occupied(int row, int col) 
        {
            // checking if user placed in an occupied place
            if (_playBoard[row, col] != " ")
                return true;
            
            return false;
        }

        public bool CheckForWin(string sym)
        {
            // check rows for a win
            for (int row = 0; row < 3; row++)
            {
                if (_playBoard[row, 0] == sym && _playBoard[row, 1] == sym && _playBoard[row, 2] == sym)
                    return true;
            }

            // check columns for a win
            for (int col = 0; col < 3; col++)
            {
                if (_playBoard[0,col] == sym && _playBoard[1,col] == sym && _playBoard[2,col] == sym)
                    return true;
            }

            // checking for diagonal wins
            if ((_playBoard[0, 0] == sym && _playBoard[1, 1] == sym && _playBoard[2, 2] == sym) ||
          (_playBoard[0, 2] == sym && _playBoard[1, 1] == sym && _playBoard[2, 0] == sym))
            {
                return true;
            }

            return false;
        }

        public bool CheckForTie()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (_playBoard[row, column] == " ")
                    {
                        // if there is an empty space, the game is not a tie yet
                        return false;
                    }
                }
            }

            // all positions on the board are filled and it's a tie
            return true;
        }
    }
}