namespace Pzl.Codyssi.Puzzles.Codyssi2024.Codyssi202403;

public class Codyssi202403Tests
{
    private const string Input = """
                                 100011101111110010101101110011 2
                                 83546306 10
                                 1106744474 8
                                 170209FD 16
                                 2557172641 8
                                 2B290C15 16
                                 279222446 10
                                 6541027340 8
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("78");

    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("3487996082");

    [Fact]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("30PzDC");

    private static Codyssi202403 Sut => new();
}