using ConsoleApp.Puzzles.Year2017.Puzzles.Day03;
using NUnit.Framework;

namespace Tests
{
    public class SpiralMemoryTests
    {
        [TestCase(1, 0)]
        [TestCase(12, 3)]
        [TestCase(23, 2)]
        [TestCase(1024, 31)]
        public void NumberOfStepsIsCorrect(int targetSquare, int expectedSteps)
        {
            var spiralMemory = new SpiralMemory(targetSquare, SpiralMemoryMode.RunToTarget);

            Assert.That(spiralMemory.Distance, Is.EqualTo(expectedSteps));
        }
    }
}