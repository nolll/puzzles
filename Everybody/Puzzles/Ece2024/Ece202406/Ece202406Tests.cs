using FluentAssertions;
using NUnit.Framework;

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

    [Test]
    public void Part1()
    {
        var result = Sut.RunPart1(Input);
        result.Answer.Should().Be("RRB@");
    }
    
    [Test]
    public void Part2And3()
    {
        var result = Sut.RunPart2(Input);
        result.Answer.Should().Be("RB@");
    }
    
    private static Ece202406 Sut => new();
}