using System;
using System.Text;

namespace Battleship
{
    class Board
    {
        public char[,] board { get; set; }

        public Board(int size)
        {
            this.board = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    this.board[i, j] = ' ';
                }
            }

        }

        public char GetCoord(int x, int y)
        {
            return board[x, y];
        }

        public void SetCoord(char c, int x, int y)
        {
            this.board[x, y] = c;
        }

        private bool NPlacement(int x, int y, char letter, int size)
        {
            for (int i = 0; i < size; i++)
            {
                if (board[x - i, y] != ' ') return false;
            }

            for (int i = 0; i < size; i++)
            {
                SetCoord(letter, x - i, y);
            }
            return true;
        }

        private bool SPlacement(int x, int y, char letter, int size)
        {
            for (int i = 0; i < size; i++)
            {
                if (board[x + i, y] != ' ') return false;
            }

            for (int i = 0; i < size; i++)
            {
                SetCoord(letter, x + i, y);
            }
            return true;
        }

        private bool WPlacement(int x, int y, char letter, int size)
        {
            for (int j = 0; j < size; j++)
            {
                if (board[x, y - j] != ' ') return false;
            }

            for (int j = 0; j < size; j++)
            {
                SetCoord(letter, x, y - j);
            }
            return true;
        }

        private bool EPlacement(int x, int y, char letter, int size)
        {
            for (int j = 0; j < size; j++)
            {
                if (board[x, y + j] != ' ') return false;
            }

            for (int j = 0; j < size; j++)
            {
                SetCoord(letter, x, y + j);
            }
            return true;
        }

        public bool SetPiece(int x, int y, char letter, int size, char direction)
        {
            if ((x >= board.GetLength(0) && x < 0) &&
                       (y >= board.GetLength(1) && y < 0))
            {
                return false;
            }

            switch (direction)
            {
                case ('N'):
                    if (x < size)
                    {
                        return false;
                    }
                    else
                    {
                        return NPlacement(x, y, letter, size);
                    }
                case ('S'):
                    if (x > this.board.GetLength(0) - size - 1)
                    {
                        return false;
                    }
                    else
                    {
                        return SPlacement(x, y, letter, size);
                    }
                case ('W'):
                    if (y < size)
                    {
                        return false;
                    }
                    else
                    {
                        return WPlacement(x, y, letter, size);
                    }

                case ('E'):
                    if (y > this.board.GetLength(1) - size - 1)
                    {
                        return false;
                    }
                    else
                    {
                        return EPlacement(x, y, letter, size);
                    }
                default:
                    return false;
            }
        }

        public string GetRow(int x)
        {
            StringBuilder response = new StringBuilder();
            response.Append($" {x} ");
            for (int j = 0; j < board.GetLength(1); j++)
            {
                response.Append($"| {board[x, j]} ");
            }
            response.Append("|");
            return response.ToString();
        }
    }
}