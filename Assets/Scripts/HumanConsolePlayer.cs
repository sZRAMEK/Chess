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
        private string input;

        public Color Color { get; }

        public HumanConsolePlayer(IBoard board, IMoveParser moveParser, ITimer timer, Color color)
        {
            this.board = board;
            this.moveParser = moveParser;
            this.timer = timer;
            this.Color = color;
            
        }



        
        
        public void Move()
        {
            timer.Start();
            
            //input = Console.ReadLine();
            IMove move = moveParser.Parse(input);
            board.Move(move);
            timer.Stop();

        }

        public int RemainingTime()
        {
            return timer.maxTime - timer.TimeFromStart(); 
        }

        public void GetInput(string input)
        {
            this.input = input;
        }
    }
}
