using Core.Frequencies;
using NUnit.Framework;

namespace Tests
{
    public class FrequencyTests
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
        public void HandleProvidedExamples(string changes, int expected)
        {
            var puzzle = new FrequencyPuzzle(changes);
            Assert.AreEqual(expected, puzzle.ResultingFrequency);
        }
    }
}