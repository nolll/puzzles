using Pzl.FlipFlop.Puzzles.FlipFlop2025;

namespace Tests.FlipFlop.FlipFlop2025;

public class FlipFlop202501Tests : PuzzleTest<FlipFlop202501>
{
    private const string Input = """
                                 banana
                                 banenanana
                                 bananana
                                 bananananana
                                 bananananana
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(24);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(16);

    [Fact]
    public void Part3() => Sut.Part3(Input).Should().Be(19);

}