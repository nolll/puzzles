using Core.GiftWrapping;
using NUnit.Framework;

namespace Tests
{
    public class GiftWrappingTests
    {
        [TestCase("2x3x4", 58)]
        [TestCase("1x1x10", 43)]
        public void CorrectSquareFeetForSingleGift(string input, int expected)
        {
            var calc = new WrappingPaperCalculator();
            var result = calc.GetRequiredPaperForOneBox(input);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CorrectSquareFeetForMultipleGifts()
        {
            const string input = @"
2x3x4
1x1x10";
            const int expected = 101;

            var calc = new WrappingPaperCalculator();
            var result = calc.GetRequiredPaper(input);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}