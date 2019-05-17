﻿using Assets.Enums;
using Assets.Interfaces;
using Assets.Scripts;
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

        IMove lastMove;



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
            if (move.From.x > 7 || move.From.y > 7 || move.To.x < 0 || move.To.y < 0 || move.To.x > 7 || move.To.y > 7 || move.To.x < 0 || move.To.y < 0)
            {
                throw new OutOfBoundaryException("wspolrzedna poza boardem");
            }

            IFigure figureToMove = GetFigureAt(move.From);
            

            if (lastMove != null)
            {
                IFigure lastMovedFigure = GetFigureAt(lastMove.To);
                if (figureToMove.color == lastMovedFigure.color)
                    throw new InvalidMoveException($"{figureToMove.color} cant move second time in row");
            }

            if (figureToMove.isLegalMove(move.To, this))
            {
                figureToMove.Move(move.To);
                if (isCheck(GetKing(figureToMove.color)))
                {
                    figureToMove.Move(move.From);
                    throw new InvalidMoveException("Your King will be checked after that move");
                }
                lastMove = move;
            }
            
        }

        private IFigure GetKing(Color color)
        {
            return figures.Find(x => x.color == color && x.Type==FigureType.King);
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
            IFigure returned= figures.Find(x => x.position.x == from.x && x.position.y == from.y);
            if (returned == null) { throw new NoFigureException("nie masz tam figury"); }
            return returned;
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

        public bool isFieldColor(Color color, IPosition from)
        {
            if (GetFigureAt(from).color == color)
                return true;
            return false;
        }
    }
}
