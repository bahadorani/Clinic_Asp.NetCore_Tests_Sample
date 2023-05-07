using Clinic.Domain.Models;
using Clinic.Domain.ValueObjects.Exceptions;
using Clinic.DomainTest.Config;

namespace Clinic.DomainTest
{
    public class BillDomainTest
    {
        [Theory]
        [InlineData(-10)]
        [InlineData(-5600)]
        public void should_throw_exception_if_price_is_less_than_ziro_characters(decimal price)
        {
            Action act = () => ClinicMoq.GetBill(price);
            var ex = Assert.Throws<InvalidPriceException>(act);
            Assert.Contains("Invalid Price", ex.Message);
        }
    }
}