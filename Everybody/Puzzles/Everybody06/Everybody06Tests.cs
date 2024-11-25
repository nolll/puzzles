using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody06;

public class Everybody06Tests
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

    [Test]
    public void Part1()
    {
        var result = Everybody06.RunPart1(Input);
        result.Should().Be("RRB@");
    }
    
    [Test]
    public void Part2And3()
    {
        var result = Everybody06.RunPart2And3(Input);
        result.Should().Be("RB@");
    }
}