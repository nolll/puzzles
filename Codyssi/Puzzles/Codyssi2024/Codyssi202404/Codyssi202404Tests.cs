namespace Pzl.Codyssi.Puzzles.Codyssi2024.Codyssi202404;

public class Codyssi202404Tests
{
    private const string Input = """
                                 ADB <-> XYZ
                                 STT <-> NYC
                                 PLD <-> XYZ
                                 ADB <-> NYC
                                 JLI <-> NYC
                                 PTO <-> ADB
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("7");

    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("6");

    [Fact]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("15");

    private static Codyssi202404 Sut => new();
}