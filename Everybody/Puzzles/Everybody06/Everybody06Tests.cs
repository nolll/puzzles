using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody06;

public class Everybody06Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             RR:A,B,C
                             A:D,E
                             B:F,@
                             C:G,H
                             D:@
                             E:@
                             F:@
                             G:@
                             H:@
                             """;
        
        var result = Everybody06.RunPart1(input);
        result.Should().Be($"RRB@");
    }
}