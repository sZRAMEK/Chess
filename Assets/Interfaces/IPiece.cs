using Assets.Enums;
using Assets.Interfaces;
using Scripts.Figures;
using System;

namespace Scripts
{
    public interface IPiece : ICloneable
    {
        bool Moved { get;  }
        IPosition currentPosition { get; set; }
        Color color { get; }
        PiecesTypesEnum Type { get; }
        
        void Move(IPosition moveDestination);
        bool IsAllowedMove(IMove move);
        bool IsAllowedCapture(IMove move);
    }
}