using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.ValueObjects.Exceptions
{
    [Serializable]
    internal class InvalidNumberException : Exception
    {
        public InvalidNumberException()
        {
        }

        public InvalidNumberException(string? message) : base(message)
        {
        }

        public InvalidNumberException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
