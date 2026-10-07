using Pzl.Everybody.Puzzles.Ece2024;

namespace Tests.Everybody.Ece2024;

public class Ece202406Tests : PuzzleTest<Ece202406>
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

}