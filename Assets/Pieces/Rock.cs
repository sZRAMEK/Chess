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
    public class Rock : Piece,IRock
    {
        

        public Rock(IPosition position, Color color) : base(position,color)
        {
            Type = PiecesTypesEnum.Rock;
           
        }

        public override bool IsAllowedMove(IMove move)
        {
            if (move.Direction() == MoveDirection.Horizontally ||
                move.Direction() == MoveDirection.Verticaly)
                return true;
            return false;
        }



        //private bool IsLegalMove(IMove move, IBoard board)
        //{
        //    if (move.Direction() == MoveDirection.Horizontally ||
        //        move.Direction()== MoveDirection.Verticaly)
        //    {
        //        if (!board.AreAnyPiecesBetwen(currentPosition, move.Destination) &&
        //            !board.isFieldColor(color, move.Destination))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}



        //public override bool IsAllowedMove(IMove move, IBoard board)
        //{

        //    return IsLegalMove(move, board);
        //}

        //public override bool CanAttack(IPosition position, IBoard board)
        //{
        //    if (!currentPosition.AreTheSame(position))
        //    {
        //        return IsLegalMove(new Move(currentPosition, position), board);
        //    }
        //    return false;
        //}

        //public override bool Move(IMove move, IBoard board)
        //{
        //    if (IsLegalMove(move, board) &&
        //        isLegalMoveIntermsofBord(move, board))
        //    {
        //        IPiece attackedPiece = board.GetFigureAt(move.Destination);
        //        currentPosition = move.Destination;

        //        if (attackedPiece != null)
        //        {
        //            board.figures.Remove(attackedPiece);
        //        }

        //        board.LastMove = move;
        //        Moved = true;
        //        return true;
        //    }
        //    return false;
        //}
    }
}
