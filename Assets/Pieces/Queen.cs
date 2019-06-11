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
    public class Queen : Piece, IQueen
    {
        public Queen(IPosition position, Color color) : base(position, color)
        {
            Type = PiecesTypesEnum.Queen;
        }

        public override bool IsAllowedMove(IMove move)
        {
            if (move.Direction() == MoveDirection.Diagonally ||
                move.Direction() == MoveDirection.Horizontally ||
                move.Direction() == MoveDirection.Verticaly)
                return true;
            return false;
        }
    }
}
