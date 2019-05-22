using Assets.Enums;
using Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class MoveParser : IMoveParser
    {
        public IMove Parse(string input)
        {
            input = input.ToUpper();
            input = input.Replace(" ","");
            if (input.Length > 5) { throw new InvalidInputException("Input is to long"); }
            if (input.Length < 5) { throw new InvalidInputException("Input is to short"); }

           
            string[] strings = input.Split(',');
            try
            {
                Enum.Parse(typeof(xLabels), strings[0][0].ToString());
            }
            catch (Exception)
            {

                throw new InvalidInputException("Cant parse coordinates ");
            }
            
            if (strings.Length != 2) { throw new InvalidInputException($"Input need 1 coma separator was: {strings.Length - 1}"); };


            IPosition From;
            IPosition to;
            
            
                if (Enum.IsDefined(typeof(xLabels), strings[0][0].ToString()))
                {
                try
                {

                
                    From = new Position((int)Enum.Parse(typeof(xLabels), strings[0][0].ToString()), int.Parse(strings[0][1].ToString()) - 1);
                    if (Enum.IsDefined(typeof(xLabels), strings[1][0].ToString()))
                    {
                        to = new Position((int)Enum.Parse(typeof(xLabels), strings[1][0].ToString()), int.Parse(strings[1][1].ToString()) - 1);
                        return new Move(From, to);
                    }
                }
                catch (Exception ex)
                {

                    throw new InvalidInputException("Cant parse coordinates "+ ex.Message);
                }
            }
            
            

                throw new InvalidInputException("Cant parse coordinates ");
            

            
        }

        enum xLabels
        {
            A,B,C,D,E,F,G,H
        }
    }
}
