using Assets.Scripts;
using Scripts.Figures;
using System.Collections.Generic;

namespace Scripts
{
    public interface IBoard
    {

       
        List<IFigure> figures{ get; set; }
        Color? DetermineWinner();
        bool isUnderPreasure(IPosition to, Color color);
        bool isPositionInBoundry(IPosition to);
        int Size { get;}
        string BoardToString();
        bool isFieldColor(Color color, IPosition from);
        bool isSomethingBetwen(IPosition position, IPosition to);
        IFigure GetFigureAt(IPosition position);
        IMove LastMove { get; set; }
        bool IsCheck(Color color);
        bool isFigureAt(IPosition rookPosition);
    }
}