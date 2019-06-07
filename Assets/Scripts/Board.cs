using Assets.Enums;
using Assets.Interfaces;
using Assets.Scripts;
using Scripts.Figures;
using System;
using System.Collections.Generic;

namespace Scripts
{
    public class Board : IBoard
    {
        private List<IPiece> figures;
        public IMove LastMove { get; set; }

        

        public Board(List<IPiece> figures, int size)
        {
            this.Size = size;
            this.figures = figures;
        }
        public object Clone()
        {
            var clone = (Board)MemberwiseClone();
            if (LastMove != null)
                clone.LastMove = (IMove)this.LastMove.Clone();
            clone.figures = new List<IPiece>();
            foreach (var item in this.figures)
            {
                clone.figures.Add((IPiece)item.Clone());
            }
            return clone;
        }





        public int Size { get; private set; }

        public bool isTie(Color color)
        {
            foreach (IPiece item in figures)
            {
                if (item.color == color)
                {
                    if (AnyPosibleMove(item))
                    {
                        return false;
                    }
                }
            }
            if (IsCheck(color))
            {
                return false;
            }
            return true;
        }

        public bool isCheckMate(Color color)
        {
            if (IsCheck(color))
            {
                foreach (IPiece item in figures)
                {
                    if (item.color == color)
                    {
                        if (AnyPosibleMove(item))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;

        }

        private bool AnyPosibleMove(IPiece item)
        {
                for (int x = 0; x < Size; x++)
                {
                    for (int y = 0; y < Size; y++)
                    {
                        var positionToCheck = new Position(x, y);
                        if (!positionToCheck.AreTheSame(item.currentPosition))
                        {
                            IMove move = new Move(item.currentPosition, positionToCheck);
                            if (Move(move) != null)
                                return true;
                        }
                    
                    }
                }
                return false;
        }

        //public bool IsCheck(Color color)
        //{
        //    IPiece king = GetKing(color);
        //    return IsFieldAttacked(king.currentPosition, king.color);
        //}

        public IPiece GetFigureAt(IPosition from)
        {
            return figures.Find(x => x.currentPosition.x == from.x && x.currentPosition.y == from.y);
        }

        public string BoardToString()
        {
            
            string result = "";
            foreach (var item in figures)
            {
                if (item != null)
                {
                    result += $"{item.currentPosition.x},{item.currentPosition.y},{item.Type},{item.color}.";
                }
            }
            result = result.Remove(result.Length - 1, 1);
            
            return result;

        }
        
        public bool isFieldColor(Color color, IPosition from)
        {
            IPiece figure = figures.Find(x => x.currentPosition.x == from.x && x.currentPosition.y == from.y);
            
            if (figure!=null && figure.color == color)
                return true;
            return false;
        }

        public bool AreAnyPiecesBetwen(IPosition A, IPosition B)
        {
            IMove Move = new Move(A, B);

            if (Move.Direction() == MoveDirection.Orher) return false;
            if(Move.Start.AreTheSame(Move.Destination)) return false;


            //zamienic na do while
            int multipler = 1;// nazwa do zmiany
            IPosition checkedPosition/*nazwa do zmiany*/ = new Position(Move.Start.x + Move.SenseHorizontal() * multipler, Move.Start.y + Move.SenseVertical() * multipler);
            while (!checkedPosition.AreTheSame( Move.Destination))
            {
                if (GetFigureAt(checkedPosition)!=null)
                    return true;
               
                multipler++;
                checkedPosition = new Position(Move.Start.x + Move.SenseHorizontal() * multipler, Move.Start.y + Move.SenseVertical() * multipler);
            }
            return false;
        }

        

        

        public Color CurrentTurn()
        {
            if (LastMove != null)
            {
               
               
                    if (GetFigureAt(LastMove.Destination).color == Color.White)
                        return Color.Black;
               
                
               
                
            }
            return Color.White;  //before first move lastMove is null  // ale to powinno byc jakos inaczej napisane
        }




        private IPiece GetKing(Color color)
        {
            return figures.Find(x => x.color == color && x.Type == PiecesTypesEnum.King);
        }

        IPiece IBoard.PromotionRequired()
        {
            IPiece pawnToPromote = (figures.Find(x => x.Type == PiecesTypesEnum.Pawn && (x.currentPosition.y == 0 || x.currentPosition.y == 7))); 
            return pawnToPromote;
        }

        public IBoard Move(IMove move)
        {
            IBoard result = this.Clone() as Board;

            IPiece pieceToMove = result.GetFigureAt(move.Start);
            IPiece attackedPiece = result.GetFigureAt(move.Destination);



            if (!AreAnyPiecesBetwen(move.Start, move.Destination))
            {

                if (attackedPiece == null)
                {
                    if (pieceToMove.IsAllowedMove(move))
                    {






                        pieceToMove.Move(move.Destination);
                        if (!result.IsCheck(pieceToMove.color))
                        {
                            result.LastMove = move;
                            return result;
                        }
                    }
                    else if (pieceToMove.Type == PiecesTypesEnum.Pawn && pieceToMove.IsAllowedCapture(move))
                    {
                        IPiece lastMovedPiece = result.GetFigureAt(LastMove.Destination);
                        if (lastMovedPiece.Type == PiecesTypesEnum.Pawn &&
                            LastMove.Distance() == DistanceEnum.TwoSquares &&
                            (LastMove.Destination.x == move.Start.x - 1 || LastMove.Destination.x == move.Start.x + 1) &&
                            LastMove.Destination.y == move.Start.y)
                        {
                            result.RemovePiece(lastMovedPiece);
                            pieceToMove.Move(move.Destination);

                            if (!result.IsCheck(pieceToMove.color))
                            {
                                result.LastMove = move;
                                return result;
                            }
                        }
                    }
                    else if (pieceToMove.Type == PiecesTypesEnum.King)
                    {
                        IKing  king= pieceToMove as IKing;
                        List<IMove> moves = king.Castling(move, result);
                        if (moves != null)
                        {
                            foreach (var item in moves)
                            {
                                result.GetFigureAt(item.Start).Move(item.Destination);
                            }
                            if (!result.IsCheck(pieceToMove.color))
                            {
                                result.LastMove = move;
                                return result;
                            }
                        }

                    }
                }
                else if (attackedPiece.color != pieceToMove.color)
                {
                    if (pieceToMove.IsAllowedCapture(move))
                    {
                        result.RemovePiece(attackedPiece);
                        pieceToMove.Move(move.Destination);

                        if (!result.IsCheck(pieceToMove.color))
                        {
                            result.LastMove = move;
                            return result;
                        }
                    }
                }
            }
            return null;
        }

        

        public bool IsCheck(Color color)
        {
                IPiece king = GetKing(color);
                return IsFieldAttacked(king.currentPosition, king.color); 
        }

        public bool IsFieldAttacked(IPosition field, Color Attacker)
        {
            foreach (var item in figures)
            {
                if (item.color != Attacker)
                {
                    if (!item.currentPosition.AreTheSame(field))
                    {
                        IMove move = new Move(item.currentPosition, field);
                        if (Move(move) != null)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void RemovePiece(IPiece pieceToRemove)
        {
            figures.Remove(pieceToRemove);
        }

        public void ChangePiece(IPiece toPromote, IPiece selected)
        {
            figures.Remove(toPromote);
            figures.Add(selected);
        }
    }
}
