namespace Battleship
{
    class Player
    {
        public Board ActualBoard { get; set; }

        public Board VisualBoard { get; set; }

        public string Name { get; set; }

        public int Points { get; set; }

        public Player(string name, int size)
        {
            this.Name = name;
            this.ActualBoard = new Board(size);
            this.VisualBoard = new Board(size);
            Points = 0;
        }

        private void SetPiece(Pieces piece)
        {

            char[] input;
            int x = 0;
            int y = 0;

            bool ValidInput = false;

            while (!ValidInput)
            {
                Console.Write($"{this.Name}, provide a coordinate for {piece.Name}: ");
                input = Console.ReadLine().ToCharArray();
                try
                {
                    x = (int)char.GetNumericValue(input[0]);
                    y = (int)char.GetNumericValue(input[input.Length - 1]);
                    if (ActualBoard.GetCoord(x, y) != ' ')
                    {
                        throw new Exception();
                    }
                    else
                    {
                        ValidInput = true;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("INVALID INPUT. Try Again !!!");
                }
            }

            ValidInput = false;
            while (!ValidInput)
            {
                Console.Write($"{this.Name}, provide facing direction for {piece.Name} (N, S, W, E): ");
                input = Console.ReadLine().ToCharArray();

                ValidInput = ActualBoard.SetPiece(x, y, piece.Symbol, piece.Size, input[0]);
                if (!ValidInput) Console.WriteLine("INVALID INPUT. Try Again !!!");
            }

        }

        public void InitializeBoard()
        {
            SetPiece(Pieces.Battleship);
            SetPiece(Pieces.Carrier);
            SetPiece(Pieces.Cruiser);
            SetPiece(Pieces.Submarine);
            SetPiece(Pieces.Destroyer);

        }

        public bool Hit(int x, int y)
        {
            if (ActualBoard.GetCoord(x, y) != ' ')
            {
                VisualBoard.SetCoord('X', x, y);
                return true;
            }
            else
            {
                VisualBoard.SetCoord('O', x, y);
                return false;
            }
        }
    }
}