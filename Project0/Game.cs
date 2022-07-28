using System.Text;
namespace Battleship
{
    class Game
    {
        private Player playerA;

        private Player playerB;

        private int x;
        private int y;

        private string Winner;

        public Game(int width, string nameA, string nameB)
        {
            this.x = this.y = width;
            playerA = new Player(nameA, width);
            playerB = new Player(nameB, width);
            InitializeGame();

        }

        private void InitializeGame()
        {
            Console.Clear();
            playerA.InitializeBoard();
            Console.Clear();
            playerB.InitializeBoard();
        }

        public void Run()
        {
            string input;
            char[] coordinates;
            int x;
            int y;
            Player temp;

            do
            {
                PrintBoards();
                Console.Write($"{playerA.Name}, please give provide coordinates: ");
                input = Console.ReadLine();

                if (input != "exit")
                {
                    try
                    {
                        coordinates = input.ToCharArray();
                        x = (int)char.GetNumericValue(coordinates[0]);
                        y = (int)char.GetNumericValue(coordinates[coordinates.GetLength(0) - 1]);

                        if (playerB.Hit(x, y))
                        {
                            Console.WriteLine("HIT !!!");
                            playerA.Points++;
                        }
                        else
                        {
                            Console.WriteLine("MISS !!!");
                        }

                        temp = playerA;
                        this.playerA = this.playerB;
                        this.playerB = temp;
                        Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("INVALID INPUT: Try again!");
                    }

                    if (playerA.Points == 17)
                    {
                        Console.WriteLine($"{playerA.Name} has won !!!");
                        input = "exit";
                    }
                }
                Console.Clear();
            } while (input != "exit");

        }

        private void PrintBoards()
        {

            StringBuilder response = new StringBuilder();
            response.Append(Header());
            response.Append(GenerateDivider());

            for (int i = 0; i < this.x; i++)
            {
                response.Append(playerA.ActualBoard.GetRow(i));
                response.Append("    |   ");
                response.Append(playerB.VisualBoard.GetRow(i));
                response.Append("\n");
                response.Append(GenerateDivider());
            }

            Console.WriteLine(response.ToString());
        }

        private string GenerateDivider()
        {
            string divider = "   ";
            for (int i = 0; i < this.y; i++)
            {
                divider += "+ - ";
            }

            divider += "+    |   " + divider + "+" + "\n";
            return divider;
        }

        private string Header()
        {
            string header = "   ";
            for (int j = 0; j < this.y; j++)
            {
                header += $"  {j} ";
            }
            return header + "     |   " + header + "\n";
        }
    }
}