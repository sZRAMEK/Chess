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
    public abstract class Piece : IPiece
    {
        public bool Moved { get; protected set; }
        public IPosition currentPosition { get; set; }
        public Color color { get; protected set; }
        public PiecesTypesEnum Type { get; protected set; }

        public object Clone()
        {
            var clone = (Piece)MemberwiseClone();
            clone.currentPosition = (IPosition)this.currentPosition.Clone();
            return clone;

        }

        public void Move(IPosition moveDestination)
        {
            currentPosition = moveDestination;
            Moved = true;
        }

        public abstract bool IsAllowedMove(IMove move);

        public virtual bool IsAllowedCapture(IMove move)
        {
            return IsAllowedMove(move);
        }

        public Piece(IPosition position, Color color)
        {
            this.currentPosition = position;
            this.color = color;
            this.Moved = false;
        }
    }
}

