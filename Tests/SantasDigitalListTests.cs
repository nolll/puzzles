using Core.SantasDigitalList;
using NUnit.Framework;

namespace Tests
{
    public class SantasDigitalListTests
    {
        [Test]
        public void CharacterCountDifference()
        {
            const string input = @"
""""
""abc""
""aaa\""aaa""
""\x27""
";

            var digitalList = new DigitalList(input);

            Assert.That(digitalList.CountDiff, Is.EqualTo(12));
        }
    }
}