
namespace Battleship
{
    class Pieces
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Size { get; private set; }
        public char Symbol { get; private set; }

        public static Pieces Battleship = new(1, 'B', nameof(Battleship), 4);
        public static Pieces Carrier = new(2, 'A', nameof(Carrier), 5);
        public static Pieces Cruiser = new(3, 'C', nameof(Cruiser), 3);
        public static Pieces Destroyer = new(4, 'D', nameof(Destroyer), 2);
        public static Pieces Submarine = new(5, 'S', nameof(Submarine), 3);

        private Pieces(int id, char symbol, string name, int size)
        {
            Id = id;
            Symbol = symbol;
            Name = name;
            Size = size;

        }

        public override string ToString()
        {
            return Name;
        }
    }
}