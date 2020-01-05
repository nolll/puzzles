using Core.EasterbunnyHq;
using NUnit.Framework;

namespace Tests
{
    public class EasterbunnyHqTests
    {
        [TestCase("R2, L3", 5)]
        [TestCase("R2, R2, R2", 2)]
        [TestCase("R5, L5, R5, R3", 12)]
        public void ManhattanDistanceToTargetIsCorrect(string input, int expected)
        {
            var calc = new EasterbunnyDistanceCalculator();
            calc.Go(input);

            Assert.That(calc.DistanceToTarget, Is.EqualTo(expected));
        }
    }
}