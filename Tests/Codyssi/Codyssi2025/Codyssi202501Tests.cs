using Pzl.Codyssi.Puzzles.Codyssi2025;

namespace Tests.Codyssi.Codyssi2025;

public class Codyssi202501Tests : PuzzleTest<Codyssi202501>
{
    private const string Input = """
                                 8
                                 1
                                 5
                                 5
                                 7
                                 6
                                 5
                                 4
                                 3
                                 1
                                 -++-++-++
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(21);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(23);

    [Fact]
    public void Part3() => Sut.Part3(Input).Should().Be(189);

}