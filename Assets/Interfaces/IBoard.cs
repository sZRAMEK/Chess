using Assets.Scripts;
using Scripts.Figures;
using System;
using System.Collections.Generic;

namespace Scripts
{
    public interface IBoard : ICloneable
    {
        int Size { get; }
        IMove LastMove { get; set; }
        

        bool IsFieldAttacked(IPosition field, Color Attacker);
        string BoardToString();
        bool IsCheck(Color color);
        bool isCheckMate(Color color);
        bool AreAnyPiecesBetwen(IPosition A, IPosition B);
        IPiece GetFigureAt(IPosition position);
        void RemovePiece(IPiece pieceToRemove);
        IPiece PromotionRequired();
        Color CurrentTurn();

        IBoard Move(IMove move);
        void ChangePiece(IPiece toPromote, IPiece selected);
        bool isTie(Color color);
    }
}