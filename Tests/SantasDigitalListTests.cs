using ConsoleApp.Puzzles.Year2015.Day08;
using NUnit.Framework;

namespace Tests
{
    public class SantasDigitalListTests
    {
        [Test]
        public void CodeToMemoryDifference()
        {
            const string input = @"
""""
""abc""
""aaa\""aaa""
""\x27""
";

            var digitalList = new DigitalList(input);

            Assert.That(digitalList.CodeMinusMemoryDiff, Is.EqualTo(12));
        }

        [Test]
        public void EncodedToCodeDifference()
        {
            const string input = @"
""""
""abc""
""aaa\""aaa""
""\x27""
";

            var digitalList = new DigitalList(input);

            Assert.That(digitalList.EncodedMinusCodeDiff, Is.EqualTo(19));
        }
    }
}