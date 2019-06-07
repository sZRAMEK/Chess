using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Enums
{

    [Serializable]
    public class InvalidGameSteupException : Exception
    {
        public InvalidGameSteupException() { }
        public InvalidGameSteupException(string message) : base(message) { }
        public InvalidGameSteupException(string message, Exception inner) : base(message, inner) { }
        protected InvalidGameSteupException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    } 
    
    
}
