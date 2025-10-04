namespace Pzl.Codyssi.Puzzles.Codyssi2024.Codyssi202402;

public class Codyssi202402Tests
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
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("19");

    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("2");

    [Fact]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("7");

    private static Codyssi202402 Sut => new();
}