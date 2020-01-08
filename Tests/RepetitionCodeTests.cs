using Core.RepetitionCode;
using NUnit.Framework;

namespace Tests
{
    public class RepetitionCodeTests
    {
        [Test]
        public void MessageIsCorrect()
        {
            const string input = @"
eedadn
drvtee
eandsr
raavrd
atevrs
tsrnev
sdttsa
rasrtv
nssdts
ntnada
svetve
tesnvt
vntsnd
vrdear
dvrsen
enarar";

            var reader = new RepetitionCodeReader();
            var coin = reader.Read(input);

            Assert.That(coin, Is.EqualTo("easter"));
        }
    }
}