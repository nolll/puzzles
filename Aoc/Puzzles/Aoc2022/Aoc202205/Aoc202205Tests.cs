using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202205;

public class Aoc202205Tests
{
    [Test]
    public void Part1()
    {
        var crane = new CargoCrane(Input);
        crane.Run1();
        var result = crane.Message;

        result.Should().Be("CMZ");
    }

    [Test]
    public void Part2()
    {
        var crane = new CargoCrane(Input);
        crane.Run2();
        var result = crane.Message;

        result.Should().Be("MCD");
    }

    private const string Input = """
                                     [D]
                                 [N] [C]
                                 [Z] [M] [P]
                                  1   2   3

                                 move 1 from 2 to 1
                                 move 3 from 1 to 3
                                 move 2 from 2 to 1
                                 move 1 from 1 to 2
                                 """;
}