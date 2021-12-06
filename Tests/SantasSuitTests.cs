using Core.Puzzles.Year2018.Day03;
using NUnit.Framework;

namespace Tests
{
    public class SantasSuitTests
    {
        [Test]
        public void NoOverlap()
        {
            const string claims = @"#1 @ 1,1: 1x1
#2 @ 3,3: 1x1
#3 @ 5,5: 1x1";
            var puzzle = new ClaimsOverlapCountPuzzle(claims);
            Assert.AreEqual(0, puzzle.OverlapCount);
        }

        [Test]
        public void Overlap()
        {
            const string claims = @"#1 @ 1,3: 4x4
#2 @ 3,1: 4x4
#3 @ 5,5: 2x2";
            var puzzle = new ClaimsOverlapCountPuzzle(claims);
            Assert.AreEqual(4, puzzle.OverlapCount);
        }

        [Test]
        public void IdWithNoOverlap()
        {
            const string claims = @"#1 @ 1,3: 4x4
#2 @ 3,1: 4x4
#3 @ 5,5: 2x2";
            var puzzle = new ClaimThatDoesNotOverlapPuzzle(claims);
            Assert.AreEqual(3, puzzle.ClaimId);
        }
    }
}