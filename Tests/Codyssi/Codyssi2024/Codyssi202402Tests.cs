using Pzl.Codyssi.Puzzles.Codyssi2024;

namespace Tests.Codyssi.Codyssi2024;

public class Codyssi202402Tests : PuzzleTest<Codyssi202402>
{
    private const string Input = """
                                 TRUE
                                 FALSE
                                 TRUE
                                 FALSE
                                 FALSE
                                 FALSE
                                 TRUE
                                 TRUE
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(19);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(2);

    [Fact]
    public void Part3() => Sut.Part3(Input).Should().Be(7);

}