using Core.ModeMaze;
using NUnit.Framework;

namespace Tests
{
    public class ModeMazeTests
    {
        [Test]
        public void CaveRiskLevelIsCorrect()
        {
            const long depth = 510;
            const int targetX = 10;
            const int targetY = 10;

            var caveSystem = new CaveSystem(depth, targetX, targetY);

            Assert.That(caveSystem.TotalRiskLevel, Is.EqualTo(114));
        }
    }
}