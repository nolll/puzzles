using Pzl.FlipFlop.Puzzles.FlipFlop2025;

namespace Tests.FlipFlop.FlipFlop2025;

public class FlipFlop202504Tests : PuzzleTest<FlipFlop202504>
{
    private const string Input = """
                                 3,3
                                 9,9
                                 6,6
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(24);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(12);

    [Fact]
    public void Part3() => Sut.Part3(Input).Should().Be(9);

}