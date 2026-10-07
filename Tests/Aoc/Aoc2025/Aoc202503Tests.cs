using Pzl.Aoc.Puzzles.Aoc2025;

namespace Tests.Aoc.Aoc2025;

public class Aoc202503Tests : PuzzleTest<Aoc202503>
{
    private const string Input = """
                                 987654321111111
                                 811111111111119
                                 234234234234278
                                 818181911112111
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(357);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(3121910778619);

}