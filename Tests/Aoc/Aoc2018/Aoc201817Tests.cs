using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201817Tests : PuzzleTest<Aoc201817>
{
    private const string Input = """
                                 x=495, y=2..7
                                 y=7, x=495..501
                                 x=501, y=3..7
                                 x=498, y=2..4
                                 x=506, y=1..2
                                 x=498, y=10..13
                                 x=504, y=10..13
                                 y=13, x=498..504
                                 """;

    [Fact]
    public void NumberOfWaterTilesIsCorrect()
    {
        var (totalWaterTileCount, retainedWaterTileCount) = Sut.Solve(Input);

        totalWaterTileCount.Should().Be(57);
        retainedWaterTileCount.Should().Be(29);
    }
}