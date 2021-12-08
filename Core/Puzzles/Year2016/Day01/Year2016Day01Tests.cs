using NUnit.Framework;

namespace Core.Puzzles.Year2016.Day01
{
    public class Year2016Day01Tests
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