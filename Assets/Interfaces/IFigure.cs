using Scripts.Figures;

namespace Scripts
{
    public interface IFigure
    {
        IPosition position { get; }
        Color color { get; }

        int LegalMovesCount(IBoard board);
        
        void Move(IPosition to);
        bool isLegalMove(IPosition to, IBoard board);
    }
}