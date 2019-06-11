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
    }
}
