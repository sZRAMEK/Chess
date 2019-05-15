using Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class MoveParser : IMoveParser
    {
        public IMove Parse(string input)
        {
            input = input.Replace(" ","");
            string[] strings = input.Split(',');
            IPosition From = new Position((int)Enum.Parse(typeof(xLabels), strings[0][0].ToString()),int.Parse(strings[0][1].ToString()));
            IPosition to = new Position((int)Enum.Parse(typeof(xLabels), strings[1][0].ToString()), int.Parse(strings[1][1].ToString()));
            return new Move(From, to);
        }

        enum xLabels
        {
            A,B,C,D,E,F,G,H
        }
    }
}
