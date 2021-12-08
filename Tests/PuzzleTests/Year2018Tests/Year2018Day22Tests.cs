using Core.Puzzles.Year2018.Day22;
using NUnit.Framework;

namespace Tests.PuzzleTests.Year2018Tests
{
    // todo: fix test
    public class Year2018Day22Tests
    {
        private const long Depth = 510;
        private const int TargetX = 10;
        private const int TargetY = 10;

        [Test]
        public void CaveRiskLevelIsCorrect()
        {
            var caveSystem = new CaveSystem(Depth, TargetX, TargetY);

            Assert.That(caveSystem.TotalRiskLevel, Is.EqualTo(114));
        }

        [Test]
        public void ShortestTimeToResque()
        {
            var caveSystem = new CaveSystem(Depth, TargetX, TargetY);
            var time = caveSystem.ResqueMan();

            Assert.That(time, Is.EqualTo(45));
        }
    }
}