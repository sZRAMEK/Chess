using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Enums
{

    [Serializable]
    public class InvalidMoveException : Exception
    {
        public InvalidMoveException() { }
        public InvalidMoveException(string message) : base(message) { }
        public InvalidMoveException(string message, Exception inner) : base(message, inner) { }
        protected InvalidMoveException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
