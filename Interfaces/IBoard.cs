using Scripts.Figures;

namespace Scripts
{
    public interface IBoard
    {
        Color DetermineWinner();
        void Move(IMove move);
    }
}