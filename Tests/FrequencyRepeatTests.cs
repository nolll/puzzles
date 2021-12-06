using ConsoleApp.Puzzles.Year2018.Day01;
using NUnit.Framework;

namespace Tests
{
    public class FrequencyRepeatTests
    {
        [TestCase("+1\n-1", 0)]
        [TestCase("+3\n+3\n+4\n-2\n-4", 10)]
        [TestCase("-6\n+3\n+8\n+5\n-6", 5)]
        [TestCase("+7\n+7\n-2\n-7\n-4", 14)]
        public void HandleProvidedExamples(string changes, int expected)
        {
            var puzzle = new FrequencyRepeatPuzzle(changes);
            Assert.AreEqual(expected, puzzle.FirstRepeatedFrequency);
        }
    }
}