using System.Collections.Generic;

namespace Scripts.Figures
{
    public interface IKing : IPiece
    {
        List<IMove> Castling(IMove move, IBoard board);
    }
}