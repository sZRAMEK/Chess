using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts.Figures
{
    class Board : IBoard
    {
        private List<IFigure> figures;
        private IFigure whiteKing;
        private IFigure blackKing;

        public Board(IFigure whiteKing, IFigure blackKing, List<IFigure> figures)
        {
            this.whiteKing = whiteKing;
            this.blackKing = blackKing;
            this.figures = figures;
        }


        public Color DetermineWinner()
        {
            if (isCheckMate(whiteKing))
                return Color.Black;
            if (isCheckMate(blackKing))
                return Color.White;
            return Color.None;
        }

        private bool isCheckMate(IFigure whiteKing)
        {
            if (whiteKing.LegalMovesCount() == 0)
                return true;
            return false;
        }

        public void Move(IMove move)
        {
            IFigure figureToMove = GetFigureAt(move.From);
            if (figureToMove.isLegalMove(move.To))
            {
                figureToMove.Move(move.To);
            }
            
        }

        private IFigure GetFigureAt(IPosition from)
        {
            return figures.Find(x => x.position == from);
        }
    }
}
