using ConsoleApp.Puzzles.Year2017.Day09;
using NUnit.Framework;

namespace Tests
{
    public class StreamProcessingTests
    {
        [TestCase("{}", "{}", 1, 1)]
        [TestCase("{{{}}}", "{{{}}}", 3, 6)]
        [TestCase("{{},{}}", "{{},{}}", 3, 5)]
        [TestCase("{{{},{},{{}}}}", "{{{},{},{{}}}}", 6, 16)]
        [TestCase("{<{},{},{{}}>}", "{}", 1, 1)]
        [TestCase("{<a>,<a>,<a>,<a>}", "{,,,}", 1, 1)]
        [TestCase("{{<a>},{<a>},{<a>},{<a>}}", "{{},{},{},{}}", 5, 9)]
        [TestCase("{{<!>},{<!>},{<!>},{<a>}}", "{{}}", 2, 3)]
        [TestCase("{{<!!>},{<!!>},{<!!>},{<!!>}}", "{{},{},{},{}}", 5, 9)]
        public void GroupCountAndScoreIsCorrect(string input, string expectedCleaned, int expectedCount, int expectedScore)
        {
            var processor = new StreamProcessor(input);

            Assert.That(processor.Cleaned, Is.EqualTo(expectedCleaned));
            Assert.That(processor.GroupCount, Is.EqualTo(expectedCount));
            Assert.That(processor.Score, Is.EqualTo(expectedScore));
        }

        [TestCase("{<>}", 0)]
        [TestCase("{<random characters>}", 17)]
        [TestCase("{<<<<>}", 3)]
        [TestCase("{<{!>}>}", 2)]
        [TestCase("{<!!>}", 0)]
        [TestCase("{<!!!>>}", 0)]
        [TestCase("{<{o\"i!a,<{i<a>}", 10)]
        public void GarbageCountIsCorrect(string input, int expected)
        {
            var processor = new StreamProcessor(input);

            Assert.That(processor.GarbageCount, Is.EqualTo(expected));
        }
    }
}