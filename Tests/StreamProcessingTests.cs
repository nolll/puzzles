using Core.StreamProcessing;
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
        public void GroupCountIsCorrect(string input, string expectedCleaned, int expectedCount, int expectedScore)
        {
            var processor = new StreamProcessor(input);
            
            Assert.That(processor.Cleaned, Is.EqualTo(expectedCleaned));
            Assert.That(processor.GroupCount, Is.EqualTo(expectedCount));
            Assert.That(processor.Score, Is.EqualTo(expectedScore));
        }
    }
}