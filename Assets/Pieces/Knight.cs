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

        public override bool IsAllowedMove(IMove move)
        {
            if(isNormalMove(move))
            return true;
            return false;
        }

        private bool isNormalMove(IMove move)
        {
            if (move.Distance() == DistanceEnum.OneKnightJump)
                return true;
            return false;
        }
    }
}
