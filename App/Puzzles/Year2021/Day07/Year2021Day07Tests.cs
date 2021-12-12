using NUnit.Framework;

namespace App.Puzzles.Year2021.Day07
{
    public class Year2021Day07Tests
    {
        [Test]
        public void Part1()
        {
            var crabSubmarines = new CrabSubmarines();
            var result = crabSubmarines.GetFuel1(Input, false);

            Assert.That(result, Is.EqualTo(37));
        }

        [Test]
        public void Part2()
        {
            var crabSubmarines = new CrabSubmarines();
            var result = crabSubmarines.GetFuel1(Input, true);

            Assert.That(result, Is.EqualTo(168));
        }

        [TestCase(16, 5, 11)]
        [TestCase(1, 5, 4)]
        [TestCase(2, 2, 0)]
        public void CostPart1(int a, int b, int expected)
        {
            var result = CrabSubmarines.GetCost(a, b);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(16, 5, 66)]
        [TestCase(1, 5, 10)]
        [TestCase(2, 5, 6)]
        [TestCase(0, 5, 15)]
        [TestCase(4, 5, 1)]
        [TestCase(2, 5, 6)]
        [TestCase(7, 5, 3)]
        [TestCase(1, 5, 10)]
        [TestCase(2, 5, 6)]
        [TestCase(14, 5, 45)]
        [TestCase(5, 16, 66)]
        [TestCase(5, 5, 0)]
        public void CostPart2(int a, int b, int expected)
        {
            var crabSubmarines = new CrabSubmarines();
            var result = crabSubmarines.GetCrabEnginerringCost(a, b);

            Assert.That(result, Is.EqualTo(expected));
        }

        private const string Input = "16,1,2,0,4,2,7,1,2,14";
    }
}