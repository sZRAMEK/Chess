using Scripts.Figures;
using System.Collections.Generic;

namespace Scripts
{
    public interface IBoard
    {

       
        List<IFigure> figures{ get; set; }
        Color? DetermineWinner();
        void Move(IMove move);
        bool isUnderPreasure(IPosition to, Color color);
        bool isPositionInBoundry(IPosition to);
        int Size { get;}
        string BoardToString();
        bool isFieldColor(Color color, IPosition from);
        bool isSomethingBetwen(IPosition position, IPosition to);
        IFigure.
    }
}