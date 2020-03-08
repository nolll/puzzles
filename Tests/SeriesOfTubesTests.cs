using Core.SeriesOfTubes;
using NUnit.Framework;

namespace Tests
{
    public class SeriesOfTubesTests
    {
        [Test]
        public void FindsAllCharacters()
        {
            const string input = @"
_     |          _
_     |  +--+    _
_     A  |  C    _
_ F---|----E|--+ _
_     |  |  |  D _
_     +B-+  +--+ _";

            var finder = new TubeRouteFinder(input);
            var route = finder.FindRoute();

            Assert.That(route, Is.EqualTo("ABCDEF"));
        }
    }
}