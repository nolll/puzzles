using Core.Boxes;
using NUnit.Framework;

namespace Tests
{
    public class BoxChecksumTests
    {
        [Test]
        public void HandleProvidedExample()
        {
            const string ids = "abcdef\nbababc\nabbcde\nabcccd\naabcdd\nabcdee\nababab";
            var puzzle = new BoxChecksumPuzzle(ids);
            Assert.AreEqual(12, puzzle.Checksum);
        }
    }
}