using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201715Tests : PuzzleTest<Aoc201715>
{
    private const string Input = """
                                 Generator A starts with 65
                                 Generator B starts with 8921
                                 """;

    [Theory]
    [InlineData(5, 1)]
    [InlineData(40_000_000, 588)]
    public void Part1_MatchCountIsOneAfter5Runs(int iterations, int expected) => 
        Sut.Run(Input, iterations).Should().Be(expected);

    [Fact]
    public void Part2_Finds309PairsIn5Runs() => Sut.Run2(Input, 5_000_000).Should().Be(309);
}