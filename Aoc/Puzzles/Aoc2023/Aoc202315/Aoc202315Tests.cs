using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202315;

public class Aoc202315Tests
{
    [Test]
    public void HashScore()
    {
        var result = Aoc202315.HashScore("HASH");

        result.Should().Be(52);
    }
    
    [Test]
    public void Part1()
    {
        var result = new Aoc202315("rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7").RunFunctions.First()();

        result.Answer.Should().Be("1320");
    }

    [Test]
    public void Part2()
    {
        var result = new Aoc202315("rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7").RunFunctions.Last()();

        result.Answer.Should().Be("145");
    }
}