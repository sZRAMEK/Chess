using Assets.Scripts;
using Newtonsoft.Json;
using Scripts.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    public class Board : IBoard
    {
        public List<IFigure> figures { get; set; }
        public int Size { get; private set; }
        

        public Board(List<IFigure> figures, int size)
        {
            this.Size = size;
            this.figures = figures; 
        }


        public Color? DetermineWinner()
        {
            if (isCheckMate(Color.White))
                return Color.Black;
            if (isCheckMate(Color.Black))
                return Color.White;
            return null;
        }

        private bool isCheckMate(Color color)
        {
            foreach (IFigure item in figures)
            {
                if (item.color ==color)
                {
                    if (item.LegalMovesCount(this) != 0)
                    {
                        return false;
                    }
                }
               
            }
            return true;

        }

        public void Move(IMove move)
        {
            IFigure figureToMove = GetFigureAt(move.From);

            if (figureToMove.isLegalMove(move.To, this))
            {
                figureToMove.Move(move.To);
                if (isCheck(GetKing(figureToMove.color)))
                {
                    figureToMove.Move(move.From);
                    throw new InvalidMoveException("Your King will be checked after that move");
                }
            }
            
        }

        private IFigure GetKing(Color color)
        {
            return figures.Find(x => x.color == color && (x is IKing));
        }

        private bool isCheck(IFigure king)
        {
            
            foreach (var item in figures)
            {
                if (item.color!=king.color && item.isLegalMove(king.position, this))
                    return true;
                
            }
            return false;
        }

        private IFigure GetFigureAt(IPosition from)
        {
            return figures.Find(x => x.position.x == from.x && x.position.y == from.y);
        }

        

        public bool isUnderPreasure(IPosition to, Color color)
        {
            foreach (IFigure item in figures)
            {
                if (item.color != color && item.isLegalMove(to, this))
                    return true;
            }
            return false;
        }

        public bool isPositionInBoundry(IPosition to)
        {
            if(to.x<Size && to.y<Size)
            return true;
            return false;
        }

        public string BoardToString()
        {
            
            string result = "";
            foreach (var item in figures)
            {
                result += $"{item.position.x},{item.position.y},{item.Type},{item.color}.";
            }
            result = result.Remove(result.Length - 1, 1);
            

            
            return result;

        }
    }
}
