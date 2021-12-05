using ConsoleApp.Puzzles.Year2019.Puzzles.Day01;
using NUnit.Framework;

namespace Tests
{
    public class SumFinderTests
    {
        [Test]
        public void FindTwoNumbers()
        {
            const string input = @"
1721
979
366
299
675
1456";

            var sumFinder = new SumFinder(input);
            var numbers = sumFinder.FindNumbersThatAddUpTo(2020, 2);

            Assert.That(numbers[0], Is.EqualTo(1721));
            Assert.That(numbers[1], Is.EqualTo(299));
        }

        [Test]
        public void FindThreeNumbers()
        {
            const string input = @"
1721
979
366
299
675
1456";

            var sumFinder = new SumFinder(input);
            var numbers = sumFinder.FindNumbersThatAddUpTo(2020, 3);

            Assert.That(numbers[0], Is.EqualTo(979));
            Assert.That(numbers[1], Is.EqualTo(366));
            Assert.That(numbers[2], Is.EqualTo(675));
        }
    }
}