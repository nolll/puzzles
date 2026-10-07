using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201822Tests : PuzzleTest<Aoc201822>
{
    private const long Depth = 510;
    private const int TargetX = 10;
    private const int TargetY = 10;

    [Fact]
    public void CaveRiskLevelIsCorrect()
    {
        var caveSystem = new Aoc201822.CaveSystem(Depth, TargetX, TargetY);

        caveSystem.TotalRiskLevel.Should().Be(114);
    }

    [Fact]
    public void ShortestTimeToResque()
    {
        var caveSystem = new Aoc201822.CaveSystem(Depth, TargetX, TargetY);
        var time = caveSystem.ResqueMan();

        time.Should().Be(45);
    }
}