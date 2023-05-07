using Clinic.Domain.Models;
using Clinic.Domain.ValueObjects.Exceptions;
using Clinic.DomainTest.Config;

namespace Clinic.DomainTest
{
    public class UserDomainTest
    {
        private readonly User _user;
        public UserDomainTest()
        {
            _user = ClinicMoq.GetUser();
        }
        [Fact]
        public void users_should_not_be_null()
        {
            Assert.NotNull(_user);
        }
        [Fact]
        public void users_should_have_firstname()
        {
            Assert.NotNull(_user.Name);
        }
        [Fact]
        public void users_should_have_lastname()
        {
            Assert.NotNull(_user.Family);
        }
        [Fact]
        public void users_should_have_tell()
        {
            Assert.NotNull(_user.Tell);
        }

        [Fact]
        public void should_throw_exception_if_firstname_is_empty()
        {
            Action act = () => ClinicMoq.GetUser("", "Najafi","09132000000");
            var ex = Assert.Throws<InvalidNameException>(act);
            Assert.Contains("Invalid name", ex.Message);
        }
        [Fact]
        public void should_throw_exception_if_family_is_empty()
        {
            Action act = () => ClinicMoq.GetUser("Ali", "", "09132000000");
            var ex = Assert.Throws<InvalidNameException>(act);
            Assert.Contains("Invalid name", ex.Message);
        }
        [Fact]
        public void should_throw_exception_if_tell_is_empty()
        {
            Action act = () => ClinicMoq.GetUser("Ali", "Najafi", "");
            var ex = Assert.Throws<InvalidTellException>(act);
            Assert.Contains("Invalid tell number", ex.Message);
        }
        [Theory]
        [InlineData("Na")]
        [InlineData("N")]
        public void should_throw_exception_if_firstName_is_less_than_three_characters(string name)
        {
            Action act = () => ClinicMoq.GetUser(name, "Najafi", "09132000000");
            var ex = Assert.Throws<InvalidNameException>(act);
            Assert.Contains("The name should have more than 3 characters.", ex.Message);
        }
        [Theory]
        [InlineData("Na")]
        [InlineData("N")]
        public void should_throw_exception_if_lastname_is_less_than_three_characters(string lastName)
        {
            Action act = () => ClinicMoq.GetUser("Alz", lastName, "09132000000");
            var ex = Assert.Throws<InvalidNameException>(act);
            Assert.Contains("The name should have more than 3 characters.", ex.Message);
        }
        [Theory]
        [InlineData("0913")]
        [InlineData("091320000")]
        public void should_throw_exception_if_tell_is_less_than_elevn_characters(string tell)
        {
            Action act = () => ClinicMoq.GetUser("Alz", "Najafi", tell);
            var ex = Assert.Throws<InvalidTellException>(act);
            Assert.Contains("The tell number should have more than 11 characters.", ex.Message);
        }
    }
}