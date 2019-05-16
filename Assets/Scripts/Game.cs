using Assets.Enums;
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
        private IPlayer activePlayer;
        private IPlayer player1;
        private IPlayer player2;
        private IBoard board;

        public IPlayer winer { private set; get; }

        public Game(IPlayer player1, IPlayer player2,IBoard board)
        {
            if (player1.Color == player2.Color)
            {
                throw new InvalidGameSteupException(); 
            }
            this.player1 = player1;
            this.player2 = player2;
            this.board = board;


            if (player1.Color == Color.White)
            activePlayer = this.player1;
            else
            activePlayer = this.player2;
        }

        public void GameLoop(string input)
        {
            activePlayer.GetInput(input);
            if (winer  == null)
            {
                winer = DetermineWinner();
                activePlayer.Move();
                activePlayer = NextPlayer();
                
          
            }
        }

        private IPlayer NextPlayer()
        {
            if (activePlayer == player1)
                return player2;
            else
                return player1;
        }

        private IPlayer DetermineWinner()
        {
            if (activePlayer.RemainingTime() == 0)
                return NextPlayer();
            if (board.DetermineWinner() == activePlayer.Color)
                return activePlayer;
            return null;
        }

        public string GetBoardDescription()
        {
           return  board.BoardToString();
        }
    }
}
