using Clinic.Domain.Models;
using Clinic.Domain.ValueObjects.Exceptions;
using Clinic.DomainTest.Config;

namespace Clinic.DomainTest
{
    public class PatientDomainTest
    {
        [Fact]
        public void should_throw_exception_if_identityCart_is_empty()
        {
            Action act = () => ClinicMoq.GetPatient("");
            var ex = Assert.Throws<InvalidNumberException>(act);
            Assert.Contains("Invalid number", ex.Message);
        }
        [Theory]
        [InlineData("123")]
        [InlineData("14785")]
        public void should_throw_exception_if_identityCart_is_less_than_ten_characters(string number)
        {
            Action act = () => ClinicMoq.GetPatient(number);
            var ex = Assert.Throws<InvalidNumberException>(act);
            Assert.Contains("The number should have 10 characters.", ex.Message);
        }
        [Theory]
        [InlineData("123123456789")]
        [InlineData("1478526688556")]
        public void should_throw_exception_if_identityCart_is_more_than_ten_characters(string number)
        {
            Action act = () => ClinicMoq.GetPatient(number);
            var ex = Assert.Throws<InvalidNumberException>(act);
            Assert.Contains("The number should have 10 characters.", ex.Message);
        }
    }
}