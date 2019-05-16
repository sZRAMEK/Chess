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


    }
}