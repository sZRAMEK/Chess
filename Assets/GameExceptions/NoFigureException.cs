using System;
using System.Runtime.Serialization;

namespace Scripts
{
    [Serializable]
    internal class NoFigureException : Exception
    {
        public NoFigureException()
        {
        }

        public NoFigureException(string message) : base(message)
        {
        }

        public NoFigureException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoFigureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}