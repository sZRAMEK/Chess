using Scripts;

namespace Assets.Scripts
{
    public class Position : IPosition
    {
        public int x { get; private set; }
        public int y { get; private set; }

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

    }
}