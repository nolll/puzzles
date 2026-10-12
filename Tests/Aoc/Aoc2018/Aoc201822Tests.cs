using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201822Tests : PuzzleTest<Aoc201822>
{
    private const string Input = """
                                 depth: 510
                                 target: 10,10
                                 """;
    
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(114);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(45);
}