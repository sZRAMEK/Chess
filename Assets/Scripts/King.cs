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
    public class King : IKing
    {
        public King(IPosition position,Color color)
        {
            this.position = position;
            this.color = color;
            this.Type = FigureType.King;
            moved = false;
        }

        public IPosition position { get; private set; }

        public Color color { get; private set; }

        public FigureType Type { get; private set; }

        public bool moved;

        

        public bool isPosibleMove(IPosition to)
        {
            if (Math.Abs(to.x - position.x)<=1 && Math.Abs(to.y - position.y)<=1)
            {
                return true;
            }
            return false;
        }

        

        public int LegalMovesCount(IBoard board)
        {
            int result = 0;
            for (int x = 0; x < board.Size; x++)
            {
                for (int y = 0; y < board.Size; y++)
                {
                    IPosition newpos = new Position(x, y);


                    if (isLegalMove(newpos, board))
                        result++;
                }            
            }
            return result;
        }

        public void Move(IPosition to)
        {
            position = to;
            moved = true;
        }

        public bool isLegalMove(IPosition to, IBoard board)
        {
            if (isPosibleMove(to)&& board.isPositionInBoundry(to))
                return true;

            if (!moved && Math.Abs(position.y - to.y) == 2 && position.x == to.x)
            {
                if (position.y - to.y < 0&& board.) { }
            }


            return false;

        }

    }
}
