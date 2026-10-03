using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201624Tests :  PuzzleTest<Aoc201624>
{
    private const string Input = """
                                 ###########
                                 #0.1.....2#
                                 #.#######.#
                                 #4.......3#
                                 ###########
                                 """;

    [Fact]
    public void FindsClosestRoute() => Sut.Solve(Input, false).Should().Be(14);

    [Fact]
    public void FindsClosestRouteAndGoesBackToStart() => Sut.Solve(Input, true).Should().Be(20);
}