using Core.Bitmasking;
using NUnit.Framework;

namespace Tests
{
    public class BitmaskingTests
    {
        [Test]
        public void SumIsCorrect()
        {
            const string input = @"
mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
mem[8] = 11
mem[7] = 101
mem[8] = 0";

            var system = new BitmaskSystem();
            var sum = system.Run(input);

            Assert.That(sum, Is.EqualTo(165));
        }
    }
}