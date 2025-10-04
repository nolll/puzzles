namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202504;

public class Codyssi202504Tests
{
    private const string Input = """
                                 NNBUSSSSSDSSZZZZMMMMMMMM
                                 PWAAASYBRRREEEEEEE
                                 FBBOFFFKDDDDDDDDD
                                 VJAANCPKKLZSSSSSSSSS
                                 NNNNNNBBVVVVVVVVV
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("1247");

    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("219");

    [Fact]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("539");

    private static Codyssi202504 Sut => new();
}