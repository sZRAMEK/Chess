using Scripts;

namespace Assets.Scripts
{
    public class Position : IPosition
    {
        public int x { get; private set; }
        public int y { get; private set; }

        public object Clone()
        {
            return new Position(x, y);
        }

        public Position(int x, int y)
        {
            if (x < 8 && y < 8)
            {
                this.x = x;
                this.y = y;
            }
            else
            {
                throw new OutOfBoundaryException("pozycja poza szachownica");
            }
        }

        public bool AreTheSame(IPosition obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                IPosition p = obj;
                return (x == p.x) && (y == p.y);
            }
        }

        public string AsString()
        {
            return $"{x},{y}";
        }

        
    }
}