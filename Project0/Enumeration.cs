namespace Battleship
{
    public abstract class Enumeration
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Size { get; private set; }

        // protected Enumeration(int id, string name, int size) => (Id, Name, Size) = (id, name, size);
        protected Enumeration(int id, string name, int size)
        {
            Id = id;
            Name = name;
            Size = size;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}