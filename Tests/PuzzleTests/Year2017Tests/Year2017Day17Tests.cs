using Core.Puzzles.Year2017.Day17;
using NUnit.Framework;

namespace Tests.PuzzleTests.Year2017Tests
{
    public class Year2017Day17Tests
    {
        [Test]
        public void NextValueIsCorrect()
        {
            const int input = 3;
            var runner = new SpinlockRunnerPart1(input);
            runner.Run(2017);

            Assert.That(runner.NextValue, Is.EqualTo(638));
            Assert.That(runner.SecondValue, Is.EqualTo(1226));
        }

        [Test]
        public void SecondValueIsCorrect()
        {
            const int input = 3;
            var runner = new SpinlockRunnerPart2(input);
            runner.Run(2017);

            Assert.That(runner.SecondValue, Is.EqualTo(1226));
        }
    }
}