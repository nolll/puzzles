using Pzl.Codyssi.Puzzles.Codyssi2025;

namespace Tests.Codyssi.Codyssi2025;

public class Codyssi202504Tests : PuzzleTest<Codyssi202504>
{
    private const string Input = """
                                 NNBUSSSSSDSSZZZZMMMMMMMM
                                 PWAAASYBRRREEEEEEE
                                 FBBOFFFKDDDDDDDDD
                                 VJAANCPKKLZSSSSSSSSS
                                 NNNNNNBBVVVVVVVVV
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(1247);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(219);

    [Fact]
    public void Part3() => Sut.Part3(Input).Should().Be(539);

}