using System.Runtime.Serialization;

namespace Clinic.Persistence.Exceptions
{
    [Serializable]
    public class FailedToFindEntityByIdException : Exception
    {
        public string Value;

        public FailedToFindEntityByIdException(string? message) : base(message)
        {
        }

        public FailedToFindEntityByIdException(string? message, string value) : this(message)
        {
            Value = value;
        }

        public FailedToFindEntityByIdException(string? message, Exception? innerException, string value) : base(message, innerException)
        {
            Value = value;
        }

        protected FailedToFindEntityByIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
