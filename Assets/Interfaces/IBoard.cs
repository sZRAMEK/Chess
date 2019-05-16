using Scripts.Figures;

namespace Scripts
{
    public interface IBoard
    {
        Color? DetermineWinner();
        void Move(IMove move);
        bool isUnderPreasure(IPosition to, Color color);
        bool isPositionInBoundry(IPosition to);
        int Size { get;}
        string BoardToString();
    }
}