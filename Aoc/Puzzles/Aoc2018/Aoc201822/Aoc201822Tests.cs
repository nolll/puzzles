using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201822;

public class Aoc201822Tests
{
    private const long Depth = 510;
    private const int TargetX = 10;
    private const int TargetY = 10;

    [Test]
    public void CaveRiskLevelIsCorrect()
    {
        var caveSystem = new CaveSystem(Depth, TargetX, TargetY);

        caveSystem.TotalRiskLevel.Should().Be(114);
    }

    [Test]
    public void ShortestTimeToResque()
    {
        var caveSystem = new CaveSystem(Depth, TargetX, TargetY);
        var time = caveSystem.ResqueMan();

        time.Should().Be(45);
    }
}