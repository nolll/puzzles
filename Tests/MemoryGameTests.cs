using Core.ElfMemoryGame;
using NUnit.Framework;

namespace Tests
{
    public class MemoryGameTests
    {
        [TestCase("0,3,6", 436)]
        [TestCase("1,3,2", 1)]
        [TestCase("2,1,3", 10)]
        [TestCase("1,2,3", 27)]
        [TestCase("2,3,1", 78)]
        [TestCase("3,2,1", 438)]
        [TestCase("3,1,2", 1836)]
        public void Find2020ThNumber(string input, int expected)
        {
            var numbers = new MemoryGame(input);
            var result = numbers.Play();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}