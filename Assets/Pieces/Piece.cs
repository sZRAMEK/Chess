using Assets.Enums;
using Assets.Interfaces;
using Scripts;
using Scripts.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public abstract class Piece : IPiece
    {
        public bool Moved { get; protected set; }
        public IPosition currentPosition { get; set; }
        public Color color { get; protected set; }
        public PiecesTypesEnum Type { get; protected set; }

        public object Clone()
        {
            var clone = (Piece)MemberwiseClone();
            clone.currentPosition = (IPosition)this.currentPosition.Clone();
            return clone;

        }

        public void Move(IPosition moveDestination)
        {
            currentPosition = moveDestination;
            Moved = true;
        }

        public abstract bool IsAllowedMove(IMove move);

        public virtual bool IsAllowedCapture(IMove move)
        {
            return IsAllowedMove(move);
        }

        public Piece(IPosition position, Color color)
        {
            this.currentPosition = position;
            this.color = color;
            this.Moved = false;
        }
        // public abstract bool Move(IMove move, IBoard board);

        //public bool AnyLegalMoves(IBoard board)
        //{
        //    /*
        //    for (int x = 0; x < board.Size; x++)
        //    {
        //        for (int y = 0; y < board.Size; y++)
        //        {
        //            var positionToCheck = new Position(x, y);
        //            if (!currentPosition.AreTheSame(positionToCheck))
        //            {
        //                IMove move = new Move(currentPosition, positionToCheck); 
        //                if (/*IsLegalMove(move, board) && isLegalMoveIntermsofBord(move, board))
        //                    return true;
        //            }
        //        }
        //    }
        //    return false;
        //    */
        //    throw new NotImplementedException();
        //}

        /* public virtual bool isLegalMoveIntermsofBord(IMove move, IBoard board)
         {
             //board po ruchu is legal czyli 
             List<IPiece> figuresCopy = new List<IPiece>(board.figures);

             IBoard testboard = new Board(figuresCopy,8);
             testboard.LastMove = board.LastMove;



             if (testboard.CurrentTurn()==color)
             {
                 MoveTypes moveType;
                 if (IsAllowedMove(move, testboard))
                 {



                     IPiece rock = null;
                     IPosition temp = currentPosition;
                     Position rookPosition = null;
                     IPiece figure = testboard.GetFigureAt(move.Destination);

                     switch (moveType)
                     {
                         case MoveTypes.NormalMove:
                             currentPosition = move.Destination;
                             break;

                         case MoveTypes.Roszada:
                             int direction = move.SenseHorizontal();

                             if (direction == 1)
                             {
                                 rookPosition = new Position(7, currentPosition.y);
                             }
                             else
                             {
                                 rookPosition = new Position(0, currentPosition.y);
                             }
                             currentPosition = move.Destination;
                             rock = testboard.GetFigureAt(rookPosition);
                             rock.currentPosition = new Position(currentPosition.x - direction, currentPosition.y);
                             break;
                         case MoveTypes.BicieWPrzelocie:
                             currentPosition = move.Destination;
                             figure = testboard.GetFigureAt(new Position(move.Destination.x, move.Start.y));
                             break;
                     }

                     if (figure != null)
                     {
                         testboard.figures.Remove(figure);
                     }

                     if (!testboard.IsCheck(color))
                     {

                         //
                         currentPosition = temp;
                         if (figure != null)
                             testboard.figures.Add(figure);
                         //
                         //
                         if (rookPosition != null && rock != null)
                         {
                             rock.currentPosition = rookPosition;
                         }
                         //

                         return true;
                     }
                     currentPosition = temp;
                     if (figure != null)
                         testboard.figures.Add(figure);
                     return false;
                     //throw new InvalidMoveException("Your King will be checked after that move");
                 }
                 return false;
                 //else throw new InvalidMoveException("you cnat move like that");   
             }
             return false;
             //else throw new InvalidMoveException($"{color} cant move second time in row");

         }*/



        //public abstract CanAttack(IPosition position);

    }
}

