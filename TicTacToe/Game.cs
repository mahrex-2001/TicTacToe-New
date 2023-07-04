using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Game
    {
        private Board board;
        private Player playerOne;
        private Player playerTwo;
        private Player currentPlayer;

        public string gameRules = @"Game Rules:
1. Tic-Tac-Toe is played on a 3x3 grid.
2. Two players take turns marking empty cells with their respective symbols ('X' or 'O').
3. The goal is to get three of your symbols in a row (horizontally, vertically, or diagonally).
4. The game ends in a tie if all cells are filled without any player winning.
5. Players cannot overwrite their opponent's symbol.
6. Invalid moves will be rejected.
";

        public string gameInstruct = @"Instructions:
1. Each turn, enter the position (1-9) in which you want to place.
2. The game will display the current state of the board after each move.
3. Pay attention to the prompts and messages to track your progress.
4. Enjoy the game and have fun!
";

        // constructor
        public Game()
        {
            board = new Board();
        }

        // starting of the game! 
        public void Start()
        {
            // first player 
            Console.Write("\nEnter first player's name: ");
            string userName1 = Console.ReadLine();
            playerOne = new Player(userName1, "X");

            // second player
            Console.Write("\nEnter second player's name: ");
            string userName2 = Console.ReadLine();
            playerTwo = new Player(userName2, "O");

            // to keep record of which player is playing currently
            currentPlayer = playerOne;

            // game logic implementation
            bool isGameOver = false;

            Console.WriteLine("\nEnter your position as shown below...\n");
            board.DisplayUser();

            Console.WriteLine("\nEnter any key to start...");
            char placeHolder;
            placeHolder = Console.ReadKey().KeyChar;

            Console.Clear();

            while (!isGameOver) 
            {
                // displaying the current state of the board
                Console.WriteLine();
                board.Display();

                int row, column;

                while (true)
                {
                    // asking users to give the input
                    Console.WriteLine($"\n{currentPlayer.Name}'s turn");

                    Console.Write("Enter the position (1-9): ");
                    int userVal = Convert.ToInt32(Console.ReadLine());

                    // giving the co-ordinates of the matrix
                    if (userVal == 1)
                    {
                        row = 0; column = 0;
                    }
                    else if (userVal == 2)
                    {
                        row = 0; column = 1;
                    }
                    else if (userVal == 3)
                    {
                        row = 0; column = 2;
                    }
                    else if (userVal == 4)
                    {
                        row = 1; column = 0;
                    }
                    else if (userVal == 5)
                    {
                        row = 1; column = 1;
                    }
                    else if (userVal == 6)
                    {
                        row = 1; column = 2;
                    }
                    else if (userVal == 7)
                    {
                        row = 2; column = 0;
                    }
                    else if (userVal == 8)
                    {
                        row = 2; column = 1;
                    }
                    else if (userVal == 9)
                    {
                        row = 2; column = 2;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input! Please enter again.");
                        continue;
                    }


                    // error handling of users!

                    // user entered in a wrong place
                    if (board.BeyondLimit(row, column))
                    {
                        Console.WriteLine("\nInvalid input! Please try again.");
                        continue;
                    }

                    // user entered in an occupied place
                    if (board.Occupied(row, column)) 
                    {
                        Console.WriteLine("\nInvalid move. Position already occupied. Choose a different position.");
                        continue;
                    }

                    break;
                }

                // updating the board with the current player's move
                board.Update(row, column, currentPlayer.Symbol);

                // checking for win or tie 
                if (board.CheckForWin(currentPlayer.Symbol))
                {
                    Console.WriteLine($"\nCongratulations to {currentPlayer.Name} for winning the game!");
                    isGameOver = true;
                }
                else if (board.CheckForTie())
                {
                    Console.WriteLine("\nIt's a tie!");
                    isGameOver = true;
                }

                // switching to the other player
                if (currentPlayer == playerOne)
                    currentPlayer = playerTwo;
                else 
                    currentPlayer = playerOne;
            }
        }

    }
}