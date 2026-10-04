using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201712Tests : PuzzleTest<Aoc201712>
{
    [Fact]
    public void GroupCounts()
    {
        const string input = """
                             0 <-> 2
                             1 <-> 1
                             2 <-> 0, 3, 4
                             3 <-> 2, 4
                             4 <-> 2, 3, 6
                             5 <-> 6
                             6 <-> 4, 5
                             """;

        var pipes = new Aoc201712.Pipes(input.Trim());

        pipes.PipesInGroupZero.Should().Be(6);
        pipes.GroupCount.Should().Be(2);
    }
}