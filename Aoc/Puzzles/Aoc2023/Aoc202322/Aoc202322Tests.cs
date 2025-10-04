namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202322;

public class Aoc202322Tests
{
    [Fact]
    public void CountBricksThatCanBeRemoved()
    {
        const string input = """
                             1,0,1~1,2,1
                             0,0,2~2,0,2
                             0,2,3~2,2,3
                             0,0,4~0,2,4
                             2,0,5~2,2,5
                             0,1,6~2,1,6
                             1,1,8~1,1,9
                             """;

        var result = Aoc202322.CountBricksThatCanBeRemoved(input);

        result.Should().Be(5);
    }

    [Fact]
    public void CountTotalRemovedBricks()
    {
        const string input = """
                             1,0,1~1,2,1
                             0,0,2~2,0,2
                             0,2,3~2,2,3
                             0,0,4~0,2,4
                             2,0,5~2,2,5
                             0,1,6~2,1,6
                             1,1,8~1,1,9
                             """;

        var result = Aoc202322.CountTotalRemovedBricks(input);

        result.Should().Be(7);
    }
}