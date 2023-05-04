
using Clinic.Domain.ValueObjects.Exceptions;

namespace Clinic.Domain.ValueObjects
{
    public class Number : ValueObject
    {
        protected Number()
        {
        }

        public Number(string value)
        {
            ValidateNumber(value);
            Value = value;
        }

        public string Value { get; set; }

        private void ValidateNumber(string value)
        {
            value = value.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidNumberException("Invalid number");
            }

            if (value.Length != 10 )
                throw new InvalidNumberException("The number should have 10 characters.");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
