using Core.Puzzles.Year2015.Day08;
using NUnit.Framework;

namespace Tests
{
    public class Year2015Day08Tests
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