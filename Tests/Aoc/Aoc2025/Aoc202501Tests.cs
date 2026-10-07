using Pzl.Aoc.Puzzles.Aoc2025;

namespace Tests.Aoc.Aoc2025;

public class Aoc202501Tests : PuzzleTest<Aoc202501>
{
    private const string Input = """
                                 L68
                                 L30
                                 R48
                                 L5
                                 R60
                                 L55
                                 L1
                                 L99
                                 R14
                                 L82
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(3);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(6);

}