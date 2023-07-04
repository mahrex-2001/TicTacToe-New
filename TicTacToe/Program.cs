using TicTacToe;

Console.WriteLine("Welcome to Tic Tac Toe game");
Console.WriteLine("------------------------------");

Game game = new Game();

while (true)
{
    Console.WriteLine("------------------------------");
    Console.WriteLine("Press 1 to view rules & instructions\n" +
    "Press 2 to start the game\n" +
    "Press 3 to exit");
    Console.WriteLine("------------------------------");

    Console.Write("Enter value: ");

    string userDef = Console.ReadLine();

    if (userDef == "1")
    {
        Console.WriteLine(game.gameRules);
        Console.WriteLine(game.gameInstruct);
    }
    else if (userDef == "2")
    {
        Console.WriteLine("\nStarting the game in just a sec!");

        // pausing the program for 2 seconds
        Thread.Sleep(2000); 
        Console.Clear();

        game.Start();
    }
    else if (userDef == "3")
    {
        Console.WriteLine("\n\nThanks for playing with us!\nHave a great day :D");
        break;
    }
    else
        Console.WriteLine("\nInvalid input! Please try again.");
}