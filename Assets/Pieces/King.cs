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
    public class King : Piece, IKing
    {


        public King(IPosition position, Color color) : base(position, color)
        {
            Type = PiecesTypesEnum.King;

        }

        public List<IMove> Castling(IMove move , IBoard board)
        {
            
                //var distance = PoweredDistance(position, destination);
                if (move.Distance() == DistanceEnum.TwoSquares &&
                    move.Direction() == MoveDirection.Horizontally &&
                   !Moved)
                {
                    Position rookPosition;
                    int castlingDirection = move.SenseHorizontal();
                    if (castlingDirection == 1)
                        rookPosition = new Position(7, currentPosition.y);
                    else
                        rookPosition = new Position(0, currentPosition.y);


                    IPiece rock = board.GetFigureAt(rookPosition);
                    if (rock != null)
                    {
                        if (rock.Type == PiecesTypesEnum.Rock &&
                            !rock.Moved &&
                            !board.AreAnyPiecesBetwen(currentPosition, rock.currentPosition) &&
                            !board.IsCheck(color) &&
                            !board.IsFieldAttacked(new Position(currentPosition.x + castlingDirection, currentPosition.y), color) &&
                            !board.IsFieldAttacked(new Position(currentPosition.x + 2 * castlingDirection, currentPosition.y), color) &&
                            !board.IsFieldAttacked(move.Destination, color))
                        {
                        List<IMove> result = new List<IMove>();
                        result.Add(move);
                        result.Add(new Move(rookPosition, new Position(currentPosition.x + castlingDirection, currentPosition.y)));
                        return result;
                        }
                    }
                }
                return null;

            
        }

        public override bool IsAllowedMove(IMove move)
        {
            if (move.Distance() == DistanceEnum.OneSquare)
                return true;
            return false;
        }

        //public override bool Move(IMove move, IBoard board)
        //{
        //    throw new NotImplementedException();
        //}


        //public override bool CanAttack(IPosition position, IBoard board)
        //{
        //    if (!currentPosition.AreTheSame(position))
        //    {

        //        if (new Move(currentPosition, position).Distance() == DistanceEnum.OneSquare)
        //        {
        //            return true;
        //        } 
        //    }
        //    return false;

        //}




        //public bool isCastling(IMove move, IBoard board)
        //{
        //    //var distance = PoweredDistance(position, destination);
        //    if (move.Distance() == DistanceEnum.TwoSquares &&
        //        move.Direction() == MoveDirection.Horizontally &&
        //       !Moved)
        //    {
        //        Position rookPosition;
        //        int castlingDirection = move.SenseHorizontal();
        //        if (castlingDirection == 1)
        //            rookPosition = new Position(7, currentPosition.y);
        //        else
        //            rookPosition = new Position(0, currentPosition.y);


        //        IPiece rock = board.GetFigureAt(rookPosition);
        //        if (rock != null)
        //        {
        //            if (rock.Type == PiecesTypesEnum.Rock &&
        //                !rock.Moved &&
        //                !board.AreAnyPiecesBetwen(currentPosition, rock.currentPosition) &&
        //                !board.IsCheck(color) &&
        //                !board.IsFieldAttacked(new Position(currentPosition.x + castlingDirection, currentPosition.y), color) &&
        //                !board.IsFieldAttacked(new Position(currentPosition.x + 2 * castlingDirection, currentPosition.y), color) &&
        //                !board.IsFieldAttacked(move.Destination, color))
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;

        //}




        //public bool isLegalMove(IMove move, IBoard board)
        //{
        //    if (board.IsFieldAttacked(move.Destination, color) ||
        //       board.isFieldColor(color, move.Destination)) return false;

        //    if (move.Distance() == DistanceEnum.OneSquare)
        //    {
        //        return true;
        //    }
        //    return false;

        //}

        //public override bool IsAllowedMove(IMove move, IBoard board, out MoveTypes moveType)
        //{
        //    moveType = MoveTypes.NormalMove;
        //    if (isLegalMove(move, board)) return true;
        //    moveType = MoveTypes.Roszada;
        //    if (isCastling(move, board)) return true;
        //    return false;
        //}

        //public override bool Move(IMove move, IBoard board)
        //{
        //    MoveTypes moveType;
        //    if (IsAllowedMove(move, board, out moveType)&&
        //        isLegalMoveIntermsofBord(move, board))  
        //    {
        //            IPiece attackedFigure = board.GetFigureAt(move.Destination);

        //            switch (moveType)
        //            {
        //                case MoveTypes.NormalMove:
        //                    currentPosition = move.Destination;
        //                    break;

        //                case MoveTypes.Roszada:
        //                    int direction = move.SenseHorizontal();
        //                    Position rookPosition;
        //                    if (direction == 1)
        //                    {
        //                        rookPosition = new Position(7, currentPosition.y);
        //                    }
        //                    else
        //                    {
        //                        rookPosition = new Position(0, currentPosition.y);
        //                    }
        //                    currentPosition = move.Destination;
        //                    board.GetFigureAt(rookPosition).currentPosition = new Position(currentPosition.x - direction, currentPosition.y);
        //                    break;
        //            }

        //            if (attackedFigure != null)
        //            {
        //                board.figures.Remove(attackedFigure);
        //            }
        //            board.LastMove = move;
        //            Moved = true;
        //            return true; 
        //    }
        //    return false;
        //}
    }
}
