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
    class Knight : Piece,IKnight
    {
        public Knight(IPosition position, Color color) : base(position, color ) 
        { 
           Type = PiecesTypesEnum.Knight;
        }

        //public bool isLegalMove(IMove move, IBoard board)
        //{
        //    if (move.Distance() == DistanceEnum.OneKnightJump &&
        //        !board.isFieldColor(color, move.Destination))
        //        return true;
        //    return false;
        //}

        //public override bool IsAllowedMove(IMove move, IBoard board, out MoveTypes moveType)
        //{
        //    moveType = MoveTypes.NormalMove;
        //    return isLegalMove(move, board);
        //}

        //public override bool CanAttack(IPosition position, IBoard board)
        //{
        //    if (!currentPosition.AreTheSame(position))
        //    {
        //        return isLegalMove(new Move(currentPosition, position), board);
        //    }
        //    return false;
        //}

        

        public override bool IsAllowedMove(IMove move)
        {
            if(isNormalMove(move)/* || isCastling(move)*/)
            return true;
            return false;
        }

        //private bool isCastling(IMove move)
        //{
        //    if (Moved == false && move.Direction() == MoveDirection.Horizontally)
        //    {
        //        return true;
        //    }
        //    return false;
        //}


        private bool isNormalMove(IMove move)
        {
            if (move.Distance() == DistanceEnum.OneKnightJump)
                return true;
            return false;
        }

        //public override bool Move(IMove move, IBoard board)
        //{
        //    MoveTypes moveType;
        //    if (IsAllowedMove(move, board, out moveType) &&
        //        isLegalMoveIntermsofBord(move, board))
        //    {
        //        IPiece attackedFigure = board.GetFigureAt(move.Destination);
        //        currentPosition = move.Destination;

        //        if (attackedFigure != null)
        //        {
        //            board.figures.Remove(attackedFigure);
        //        }
        //        board.LastMove = move;
        //        Moved = true;
        //        return true;
        //    }
        //    return false;
        //}

    }
}
