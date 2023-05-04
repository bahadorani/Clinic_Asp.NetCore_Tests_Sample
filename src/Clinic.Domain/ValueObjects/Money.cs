using Clinic.Domain.ValueObjects.Exceptions;

namespace Clinic.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        protected Money()
        {
        }
        public Money(decimal? value)
        {
            ValidateMoney(value);
            Value = value;
        }

        public decimal? Value { get; set; }

        private void ValidateMoney(decimal? value)
        {
            if (value!=null && value < 0)
            {
                throw new InvalidPriceException("Invalid Price");
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
