namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202508;

public class Codyssi202508Tests
{
    private const string Input = """
                                 tv8cmj0i2951190z5w44fe205k542l5818ds05ib425h9lj260ud38-l6a06
                                 a586m0eeuqqvt5-k-8434hb27ytha3i75-lw23-0cj856l7zn8234a05eron
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("52");

    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("18");

    [Fact]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("26");

    private static Codyssi202508 Sut => new();
}