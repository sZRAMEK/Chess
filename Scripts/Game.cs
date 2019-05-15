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
        private IPlayer playerWhite;
        private IPlayer playerBlack;
        private IBoard board;

        public IPlayer winer { private set; get; }

        public Game(IPlayer playerWhite, IPlayer playerBlack,IBoard board)
        {
            
            this.playerWhite = playerWhite;
            this.playerBlack = playerBlack;
            this.board = board;
            activePlayer = this.playerWhite;
        }

        public void StartGameLoop()
        {
             
            while (winer  == null)
            {
                winer = DetermineWinner();
                activePlayer.Move();
                activePlayer = NextPlayer();
                
            }
        }

        

        private IPlayer NextPlayer()
        {
            if (activePlayer == playerWhite)
                return playerBlack;
            else
                return playerWhite;
        }

        private IPlayer DetermineWinner()
        {
            if (activePlayer.RemainingTime() == 0)
                return NextPlayer();
            if (board.DetermineWinner() == activePlayer.Color)
                return activePlayer;
            return null;
        }
    }
}
