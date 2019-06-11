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
    }
}
