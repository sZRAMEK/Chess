using System;
using System.Runtime.Serialization;

namespace Scripts
{
    [Serializable]
    public class OutOfBoundaryException : Exception
    {
        public OutOfBoundaryException()
        {
        }

        public OutOfBoundaryException(string message) : base(message)
        {
        }

        public OutOfBoundaryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OutOfBoundaryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}