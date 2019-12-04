using Core.Passwords;
using NUnit.Framework;

namespace Tests
{
    public class PasswordFinderTests
    {
        [TestCase(111111)]
        public void PasswordIsValid(int pwd)
        {
            var passwordValidator = new PasswordValidator();
            var result = passwordValidator.IsValid(pwd);

            Assert.That(result, Is.True);
        }

        [TestCase(223450)]
        [TestCase(123789)]
        public void PasswordIsInvalid(int pwd)
        {
            var passwordValidator = new PasswordValidator();
            var result = passwordValidator.IsValid(pwd);

            Assert.That(result, Is.False);
        }
    }
}