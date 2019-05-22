using Assets.Enums;
using Assets.Interfaces;
using Scripts.Figures;

namespace Scripts
{
    public interface IFigure
    {
        bool moved { get;  }
        IPosition position { get; set; }
        Color color { get; }
        FigureType Type { get; }

        int LegalMovesCount(IBoard board);
        
        void Move(IPosition to, IBoard board);
        bool isLegalMove(IPosition to, IBoard board, out MoveTypes moveType);
    }
}