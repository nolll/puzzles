using Core.Puzzles.Year2019.Day15;
using NUnit.Framework;

namespace Tests
{
    public class Year2019Day15Tests
    {
        [Test]
        public void Returns4Minutes()
        {
            const string map = @"
_ ##   _
_#..## _
_#.#..#_
_#.X.# _
_ ###  _";
            var filler = new OxygenFiller(map);
            var result = filler.Fill();

            Assert.That(result, Is.EqualTo(4));
        }
    }
}