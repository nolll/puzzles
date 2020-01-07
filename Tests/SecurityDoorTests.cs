using Core.SecurityDoor;
using NUnit.Framework;

namespace Tests
{
    public class SecurityDoorTests
    {
        [Test]
        public void GeneratesPassword()
        {
            const string input = "abc";
            var generator = new PasswordGenerator();
            var pwd = generator.Generate(input);

            Assert.That(pwd, Is.EqualTo("18f47a30"));
        }
    }
}