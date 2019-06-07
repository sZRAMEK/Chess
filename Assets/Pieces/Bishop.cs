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
    public class Bishop : Piece,IBishop
    {

        public Bishop(IPosition position, Color color) : base(position, color)
        {
            Type = PiecesTypesEnum.Bishop;
        }

        public override bool IsAllowedMove(IMove move)
        {
            if (move.Direction() == MoveDirection.Diagonally)
            {
                return true;
            }
            return false;
        }

        //private        bool IsAllowedMove(IMove move, IBoard board)
        //{

        //    if (move.Direction() == MoveDirection.Diagonally)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public override bool CanAttack(IPosition position, IBoard board)
        //{
        //    if (!currentPosition.AreTheSame(position))
        //    {
        //        return IsAllowedMove(new Move(currentPosition, position), board);
        //    }
        //    return false;
        //}


        //private void standardMove(IMove move, IBoard board)
        //{
        //    IPiece attackedPiece = board.GetFigureAt(move.Destination);
        //    IPiece movedPiece = board.GetFigureAt(currentPosition);
        //    movedPiece.currentPosition = move.Destination;

           
        //    if (attackedPiece != null)
        //    {
        //        board.figures.Remove(attackedPiece);
        //    }
        //    board.LastMove = move;
        //    Moved = true;
            
        //}



        //public override bool Move(IMove move, IBoard board)
        //{
        //    if (IsLegalMove(move, board)&&
        //        isLegalMoveIntermsofBord(move, board)) 
        //    {
        //        standardMove(move, board);
        //        return true;
        //    }
        //    return false;
        //}

        //public override bool isLegalMoveIntermsofBord(IMove move, IBoard board)
        //{
            

        //    if (!board.AreAnyPiecesBetwen(currentPosition, move.Destination) &&
        //            !board.isFieldColor(color, move.Destination)&&
        //            board.CurrentTurn() == color)

        //    {
        //        IBoard testboard = board.Clone() as IBoard;

        //        standardMove(move, testboard);

        //            if (!testboard.IsCheck(color))
        //                return true;
        //            return false;
        //    }
        //    return false;
        //}


    }
}
