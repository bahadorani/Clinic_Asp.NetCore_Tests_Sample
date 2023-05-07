using Clinic.Domain.Models;
using Clinic.Domain.ValueObjects.Exceptions;
using Clinic.DomainTest.Config;

namespace Clinic.DomainTest
{
    public class InsuredDomainTest
    {
        private readonly Insured _insured;
        public InsuredDomainTest()
        {
            _insured = ClinicMoq.GetInssured();
        }
        [Fact]
        public void insured_should_not_be_null()
        {
            Assert.NotNull(_insured);
        }
        [Fact]
        public void insured_should_have_title()
        {
            Assert.NotNull(_insured.Title);
        }
        [Fact]
        public void insured_should_have_tell()
        {
            Assert.NotNull(_insured.Tell);
        }
        [Fact]
        public void users_should_have_identityNumber()
        {
            Assert.NotNull(_insured.IdentityNumber);
        }

        [Fact]
        public void should_throw_exception_if_title_is_empty()
        {
            Action act = () => ClinicMoq.GetInssured("", "09132000000", "1234567890");
            var ex = Assert.Throws<InvalidNameException>(act);
            Assert.Contains("Invalid name", ex.Message);
        }
       
        [Fact]
        public void should_throw_exception_if_tell_is_empty()
        {
            Action act = () => ClinicMoq.GetInssured("Asia", "", "1234567890");
            var ex = Assert.Throws<InvalidTellException>(act);
            Assert.Contains("Invalid tell number", ex.Message);
        }
        [Fact]
        public void should_throw_exception_if_identityNumber_is_empty()
        {
            Action act = () => ClinicMoq.GetInssured("Asia", "09132000000", "");
            var ex = Assert.Throws<InvalidNumberException>(act);
            Assert.Contains("Invalid number", ex.Message);
        }
        [Theory]
        [InlineData("Na")]
        [InlineData("N")]
        public void should_throw_exception_if_title_is_less_than_three_characters(string name)
        {
            Action act = () => ClinicMoq.GetInssured(name, "09132000000", "1234567890");
            var ex = Assert.Throws<InvalidNameException>(act);
            Assert.Contains("The name should have more than 3 characters.", ex.Message);
        }
        
        [Theory]
        [InlineData("0913")]
        [InlineData("091320000")]
        public void should_throw_exception_if_tell_is_less_than_elevn_characters(string tell)
        {
            Action act = () => ClinicMoq.GetInssured("Asia", tell, "1234567890");
            var ex = Assert.Throws<InvalidTellException>(act);
            Assert.Contains("The tell number should have more than 11 characters.", ex.Message);
        }
        [Theory]
        [InlineData("1234")]
        [InlineData("1478523")]
        public void should_throw_exception_if_identityNumber_is_less_than_ten_characters(string number)
        {
            Action act = () => ClinicMoq.GetInssured("Asia", "09132000000", number);
            var ex = Assert.Throws<InvalidNumberException>(act);
            Assert.Contains("The number should have 10 characters.", ex.Message);
        }
        [Theory]
        [InlineData("123444444444")]
        [InlineData("1471472582583693")]
        public void should_throw_exception_if_identityNumber_is_more_than_ten_characters(string number)
        {
            Action act = () => ClinicMoq.GetInssured("Asia", "09132000000", number);
            var ex = Assert.Throws<InvalidNumberException>(act);
            Assert.Contains("The number should have 10 characters.", ex.Message);
        }
    }
}