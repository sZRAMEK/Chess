using Scripts;
using Scripts.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    public class HumanConsolePlayer : IPlayer
    {
        ITimer timer;
        IBoard board;
        IMoveParser moveParser;
        

        public HumanConsolePlayer(IBoard board, IMoveParser moveParser, ITimer timer)
        {
            this.board = board;
            this.moveParser = moveParser;
            this.timer = timer;
            
        }


        public Color Color { get; }
        
        public void Move()
        {
            timer.Start();
            string input = "";
            input = Console.ReadLine();
            IMove move = moveParser.Parse(input);
            board.Move(move);
            timer.Stop();

        }

        public int RemainingTime()
        {
            return timer.maxTime - timer.TimeFromStart(); 
        }
    }
}
