using System;
using System.Runtime.Serialization;

namespace Crocodal.Transpiler
{
    public class UnsupportedNodeException : Exception
    {
        public UnsupportedNodeException()
        {
        }

        public UnsupportedNodeException(string message) : base(message)
        {
        }

        public UnsupportedNodeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnsupportedNodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
