using Core.MonorailCode;
using NUnit.Framework;

namespace Tests
{
    public class MonorailControlTests
    {
        [Test]
        public void RegisterIsCorrect()
        {
            const string input = @"
cpy 41 a
inc a
inc a
dec a
jnz a 2
dec a";

            var control = new MonorailControl(input);

            Assert.That(control.ValueA, Is.EqualTo(42));
        }
    }
}