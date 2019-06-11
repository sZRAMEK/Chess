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
    }
}
