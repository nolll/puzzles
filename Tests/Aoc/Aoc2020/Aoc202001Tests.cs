using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202001Tests : PuzzleTest<Aoc202001>
{
    private const string Input = """
                                 1721
                                 979
                                 366
                                 299
                                 675
                                 1456
                                 """;
    
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(514579);
    
    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(241861950);

    private static Aoc202001 Sut => new();
}