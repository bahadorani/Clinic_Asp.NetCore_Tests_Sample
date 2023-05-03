using Clinic.Domain.ValueObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.ValueObjects
{
    public class Mobile:ValueObject
    {
        protected Mobile()
        {
        }

        public Mobile(string value)
        {
            ValidateName(value);
            Value = value;
        }

        public string Value { get; set; }

        private void ValidateName(string value)
        {
            value = value.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidTellException("Invalid tell number");
            }

            if (value.Length < 11)
                throw new InvalidTellException("The tell number should have more than 11 characters.");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
