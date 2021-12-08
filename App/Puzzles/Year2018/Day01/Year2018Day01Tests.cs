using NUnit.Framework;

namespace App.Puzzles.Year2018.Day01
{
    public class Year2018Day01Tests
    {
        [Test]
        public void HandleOneNegativeChange()
        {
            const string changes = "-1";
            var puzzle = new FrequencyPuzzle(changes);
            Assert.AreEqual(-1, puzzle.ResultingFrequency);
        }

        [Test]
        public void HandleOnePositiveChange()
        {
            const string changes = "+1";
            var puzzle = new FrequencyPuzzle(changes);
            Assert.AreEqual(1, puzzle.ResultingFrequency);
        }

        [Test]
        public void HandleTwoChanges()
        {
            const string changes = "-1\n+2";
            var puzzle = new FrequencyPuzzle(changes);
            Assert.AreEqual(1, puzzle.ResultingFrequency);
        }

        [TestCase("+1\n+1\n+1", 3)]
        [TestCase("+1\n+1\n-2", 0)]
        [TestCase("-1\n-2\n-3", -6)]
        public void HandleProvidedPart1Examples(string changes, int expected)
        {
            var puzzle = new FrequencyPuzzle(changes);
            Assert.AreEqual(expected, puzzle.ResultingFrequency);
        }

        [TestCase("+1\n-1", 0)]
        [TestCase("+3\n+3\n+4\n-2\n-4", 10)]
        [TestCase("-6\n+3\n+8\n+5\n-6", 5)]
        [TestCase("+7\n+7\n-2\n-7\n-4", 14)]
        public void HandleProvidedPart2Examples(string changes, int expected)
        {
            var puzzle = new FrequencyRepeatPuzzle(changes);
            Assert.AreEqual(expected, puzzle.FirstRepeatedFrequency);
        }
    }
}