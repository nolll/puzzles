using Core.Puzzles.Year2016.Day02;
using NUnit.Framework;

namespace Tests
{
    public class BathroomSecurityTests
    {
        [Test]
        public void FindsSquareKeycode()
        {
            const string input = @"
ULL
RRDDD
LURDL
UUUUD";

            var finder = new SquareKeyCodeFinder();
            var code = finder.Find(input);

            Assert.That(code, Is.EqualTo("1985"));
        }

        [Test]
        public void FindsDiamondKeycode()
        {
            const string input = @"
ULL
RRDDD
LURDL
UUUUD";

            var finder = new DiamondKeyCodeFinder();
            var code = finder.Find(input);

            Assert.That(code, Is.EqualTo("5DB3"));
        }
    }
}