using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.ValueObjects.Exceptions
{
    public class InvalidTellException:Exception
    {
        public InvalidTellException()
        {
        }

        public InvalidTellException(string? message) : base(message)
        {
        }

        public InvalidTellException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidTellException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
