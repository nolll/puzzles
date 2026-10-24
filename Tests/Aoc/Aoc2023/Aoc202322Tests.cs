using Pzl.Aoc.Puzzles.Aoc2023;

namespace Tests.Aoc.Aoc2023;

public class Aoc202322Tests : PuzzleTest<Aoc202322>
{
    private const string Input = """
                                 1,0,1~1,2,1
                                 0,0,2~2,0,2
                                 0,2,3~2,2,3
                                 0,0,4~0,2,4
                                 2,0,5~2,2,5
                                 0,1,6~2,1,6
                                 1,1,8~1,1,9
                                 """;

    [Fact]
    public void CountBricksThatCanBeRemoved() => Sut.CountBricksThatCanBeRemoved(Input).Should().Be(5);

    [Fact]
    public void CountTotalRemovedBricks() => Sut.CountTotalRemovedBricks(Input).Should().Be(7);
}