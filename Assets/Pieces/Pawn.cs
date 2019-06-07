using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Enums;
using Assets.Interfaces;
using Scripts;
using Scripts.Figures;

namespace Assets.Scripts
{
    public class Pawn : Piece, IPawn
    {

        private int pawnForwardSense;
        
        public Pawn(IPosition position, Color color) : base(position, color)
        {
            Type = PiecesTypesEnum.Pawn;
            if (color == Color.White) { pawnForwardSense = 1; } else pawnForwardSense = -1;
            
        }

        public override bool IsAllowedMove(IMove move)
        {
            if(isNormalMove(move) || isLongFirsrMove(move))
                return true;
            return false;
        }

        public override bool IsAllowedCapture(IMove move)
        {
            if (move.Direction() == MoveDirection.Diagonally &&
            move.SenseVertical() == pawnForwardSense &&
            move.Distance() == DistanceEnum.OneSquare)
                return true;
            return false;
        }

        private bool isNormalMove(IMove move)
        {
            if (move.Direction() == MoveDirection.Verticaly &&
                move.SenseVertical() == pawnForwardSense &&
                move.Distance() == DistanceEnum.OneSquare)
            {
                return true;
            }
            return false;
        }

        private bool isLongFirsrMove(IMove move)
        {
            if (move.Direction() == MoveDirection.Verticaly &&
                move.SenseVertical() == pawnForwardSense &&
                move.Distance() == DistanceEnum.TwoSquares&&
                Moved == false)
            {
                return true;
            }
            return false;
        }

        



        //public override bool Move(IMove move, IBoard board)
        //{
        //    throw new NotImplementedException();
        //}

        //private bool longFirstMove(IMove move, IBoard board)
        //{
        //    if (move.Direction() == MoveDirection.Verticaly &&
        //            move.Distance() == DistanceEnum.TwoSquares &&
        //            board.GetFigureAt(move.Destination)==null &&
        //            !Moved)
        //    {
        //        return true;
        //    }
        //    return false;
        //}


        //private bool EnPassant(IMove move, IBoard board)
        //{
        //    if (move.Direction() == MoveDirection.Diagonally &&
        //                move.SenseVertical() == pawnForwardSense &&
        //                board.GetFigureAt(move.Destination)==null)
        //    {
        //        IMove expectedLastMove;
        //        try
        //        {
        //         expectedLastMove = new Move(new Position(move.Destination.x, move.Destination.y + pawnForwardSense), new Position(move.Destination.x, move.Destination.y - pawnForwardSense));//change needed

        //        }
        //        catch (Exception)
        //        {
        //            return false;
        //        }
        //        if (board.LastMove!=null && 
        //            board.LastMove.Start.AreTheSame(expectedLastMove.Start)&&
        //            board.LastMove.Destination.AreTheSame(expectedLastMove.Destination))
        //        {
        //            IPiece atackedPawn = board.GetFigureAt(expectedLastMove.Destination);
        //            if (atackedPawn!=null && atackedPawn.Type == PiecesTypesEnum.Pawn) { return true; }
        //        }
        //    }
        //    return false;
        //}

        //private bool normalAttack(IMove move, IBoard board)
        //{
        //    IPiece target = board.GetFigureAt(move.Destination);
        //    if ((move.Direction()==MoveDirection.Diagonally) &&
        //             move.SenseVertical() == pawnForwardSense &&
        //             move.Distance() == DistanceEnum.OneSquare &&
        //             target!=null &&
        //             target.color != color)


        //    {
        //        return true;
        //    }
        //    return false;
        //}




        //private bool isLegalMove(IMove move, IBoard board)
        //{
        //    if (isNormalMove(move,board) || 
        //        normalAttack(move, board)||
        //        longFirstMove(move, board)||
        //        EnPassant(move, board))
        //    {
        //        return true;
        //    }
        //    return false;
        //}



        //public override bool IsAllowedMove(IMove move, IBoard board, out MoveTypes moveType)
        //{
        //    moveType = MoveTypes.NormalMove;
        //    if (normalAttack(move, board)|| isNormalMove(move, board))
        //    {
        //        return true;
        //    }
        //    else if (longFirstMove(move, board))
        //    {
        //        moveType = MoveTypes.NormalMove;
        //        return true;
        //    }
        //    else if (EnPassant(move, board))
        //    {
        //        moveType = MoveTypes.BicieWPrzelocie;
        //        return true;
        //    }
        //    return false;
        //}

        //public override bool CanAttack(IPosition position, IBoard board)
        //{
        //    if (!currentPosition.AreTheSame(position))
        //    {
        //        return normalAttack(new Move(currentPosition, position), board);   // change needed
        //    }
        //    return false;

        //}

        //public override bool Move(IMove move, IBoard board)
        //{
        //    MoveTypes moveType;
        //    if (IsAllowedMove(move, board, out moveType) && isLegalMoveIntermsofBord(move, board)) 
        //    {
        //            IPiece figure = board.GetFigureAt(move.Destination);
        //            switch (moveType)
        //            {
        //                case MoveTypes.NormalMove:
        //                    currentPosition = move.Destination;
        //                    break;

        //                case MoveTypes.BicieWPrzelocie:
        //                    currentPosition = move.Destination;
        //                    figure = board.GetFigureAt(new Position(move.Destination.x, move.Start.y));
        //                    break;
        //            }

        //            if (figure != null)
        //            {
        //                board.figures.Remove(figure);
        //            }
        //            board.LastMove = move;
        //            Moved = true;
        //            return true;
        //    }
        //    return false;
        //}
    }
}
