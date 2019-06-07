using Assets.Enums;
using Assets.Scripts;
using Scripts.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    public class Game : IGame
    {
        private IBoard board;

        

        public Game(IBoard board)
        {
            this.board = board;
        }

        public void MakeMove(string input)
        {
            IPawn toPromote = board.PromotionRequired() as IPawn;
            if (toPromote == null)
            {
                MoveParser parser = new MoveParser();
                IMove move = parser.Parse(input);
                IPiece toMove = board.GetFigureAt(move.Start);
                if (toMove != null && board.CurrentTurn()== toMove.color)
                {
                    IBoard newBoard = board.Move(move);
                    if (newBoard != null)
                        board = newBoard;
                }
            }
            else
            {
                Promote(input);
            }
        }

        public string GetBoardDescription()
        {
            string result = board.CurrentTurn() + "/" + board.BoardToString() + "/";
            if (board.isCheckMate(board.CurrentTurn()))
            {

                if (board.CurrentTurn() == Color.White)
                    result += Color.Black;
                else
                    result += Color.White;

            }
            else
            {
                if (board.isTie(board.CurrentTurn()))
                {
                    result += "Tie";
                }
            }
            result += "/";
            IPiece toPromote = board.PromotionRequired();
            if (toPromote!=null) 
                result += toPromote.currentPosition.AsString();

            return result;
        }




        



        private void Promote(string input)
        {
            IPiece toPromote = board.PromotionRequired(); 
            IPiece selected = null;
            switch (input)
            {
                case "Queen":
                    selected = new Queen(toPromote.currentPosition, toPromote.color);
                    break;
                case "Rock":
                    selected = new Rock(toPromote.currentPosition, toPromote.color);
                    break;
                case "Bishop":
                    selected = new Bishop(toPromote.currentPosition, toPromote.color);
                    break;
                case "Knight":
                    selected = new Knight(toPromote.currentPosition, toPromote.color);
                    break;
                default:
                    throw new ArgumentException();

            }

            board.ChangePiece(toPromote, selected);
              
        }
    }
}
