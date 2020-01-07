using Core.SecurityDoor;
using NUnit.Framework;

namespace Tests
{
    public class SecurityDoorTests
    {
        [Test]
        public void GeneratesPasswordWithFirstAlgorithm()
        {
            const string input = "abc";
            var generator = new PasswordGenerator();
            var pwd = generator.Generate1(input);

            Assert.That(pwd, Is.EqualTo("18f47a30"));
        }

        [Test]
        public void GeneratesPasswordWithSecondAlgorithm()
        {
            const string input = "abc";
            var generator = new PasswordGenerator();
            var pwd = generator.Generate2(input);

            Assert.That(pwd, Is.EqualTo("05ace8e3"));
        }
    }
}