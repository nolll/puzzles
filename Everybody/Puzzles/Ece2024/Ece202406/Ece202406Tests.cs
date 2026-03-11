namespace Pzl.Everybody.Puzzles.Ece2024.Ece202406;

public class Ece202406Tests
{
    private const string Input = """
                                 RR:A,B,C
                                 A:D,E
                                 B:F,@
                                 C:G,H
                                 D:@
                                 E:@
                                 F:@
                                 G:@
                                 H:@
                                 BUG:ANT
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be("RRB@");

    [Fact]
    public void Part2And3() => Sut.Part2(Input).Should().Be("RB@");

    private static Ece202406 Sut => new();
}