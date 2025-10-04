namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202501;

public class Codyssi202501Tests
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
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("21");

    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("23");

    [Fact]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("189");

    private static Codyssi202501 Sut => new();
}