using System;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a board width: ");
            int size = int.Parse(Console.ReadLine());

            Console.Write("Please provide name for player 1: ");
            string nameA = Console.ReadLine();

            Console.Write("Please provide name for player 2: ");
            string nameB = Console.ReadLine();

            Game game = new Game(size, nameA, nameB);
            Console.Clear();
            game.Run();

        }
    }
}
