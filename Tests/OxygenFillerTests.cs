using Core.Oxygen;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
    // todo: fix test
    public class OxygenFillerTests
    {
        [Test]
        public void Returns4Minutes()
        {
            var map = @"
_ ##   _
_#..## _
_#.#..#_
_#.O.# _
_ ###  _";
            var filler = new OxygenFiller(map);
            var result = filler.Fill();

            Assert.That(result, Is.EqualTo(4));
        }
    }
}