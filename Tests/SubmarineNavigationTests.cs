using Core.SeaDepth;
using NUnit.Framework;

namespace Tests
{
    public class SubmarineNavigationTests
    {
        [Test]
        public void Part1()
        {
            var validator = new SubmarineNavigation(false);
            var result = validator.Move(Input);

            Assert.That(result, Is.EqualTo(150));
        }

        [Test]
        public void Part2()
        {
            var validator = new SubmarineNavigation(true);
            var result = validator.Move(Input);

            Assert.That(result, Is.EqualTo(900));
        }

        private const string Input = @"
forward 5
down 5
forward 8
up 3
down 8
forward 2";
    }
}