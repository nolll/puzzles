namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202001;

public class Aoc202001Tests
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
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("514579");
    
    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("241861950");

    private static Aoc202001 Sut => new();
}