using Core.Puzzles.Year2020.Day15;
using NUnit.Framework;

namespace Tests
{
    public class Year2020Day15Tests
    {
        [TestCase("0,3,6", 2020, 436)]
        [TestCase("1,3,2", 2020, 1)]
        [TestCase("2,1,3", 2020, 10)]
        [TestCase("1,2,3", 2020, 27)]
        [TestCase("2,3,1", 2020, 78)]
        [TestCase("3,2,1", 2020, 438)]
        [TestCase("3,1,2", 2020, 1836)]
        [TestCase("0,3,6", 30000000, 175594)]
        [TestCase("1,3,2", 30000000, 2578)]
        [TestCase("2,1,3", 30000000, 3544142)]
        [TestCase("1,2,3", 30000000, 261214)]
        [TestCase("2,3,1", 30000000, 6895259)]
        [TestCase("3,2,1", 30000000, 18)]
        [TestCase("3,1,2", 30000000, 362)]
        public void Find2020ThNumber(string input, int until, long expected)
        {
            var numbers = new MemoryGame(input);
            var result = numbers.Play(until);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}