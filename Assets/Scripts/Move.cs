using Scripts;

namespace Assets.Scripts
{
    public class Move : IMove
    {
        public IPosition From { get; private set; }
        public IPosition To { get; private set; }

        public Move(IPosition from , IPosition to)
        {
            this.From = from;
            this.To = to;
        }
    }
}