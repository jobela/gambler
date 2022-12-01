using System.Runtime.Serialization;

namespace Gambler.PoC.Services
{
    [Serializable]
    internal class ThrottlingException : Exception
    {
        public ThrottlingException()
        {
        }

        public ThrottlingException(string? message) : base(message)
        {
        }

        public ThrottlingException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ThrottlingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}