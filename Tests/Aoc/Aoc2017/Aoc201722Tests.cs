using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201722Tests : PuzzleTest<Aoc201722>
{
    private const string Input = """
                                 ..#
                                 #..
                                 ...
                                 """;

    [Theory]
    [InlineData(7, 5)]
    [InlineData(70, 41)]
    [InlineData(10000, 5587)]
    public void InfectionCountIsCorrectForPart1(int iterations, int expected) => 
        Sut.RunPart1(Input, iterations).Should().Be(expected);

    [Theory]
    [InlineData(100, 26)]
    [InlineData(10_000_000, 2_511_944)]
    public void InfectionCountIsCorrectForPart2(int iterations, int expected) => 
        Sut.RunPart2(Input, iterations).Should().Be(expected);
}