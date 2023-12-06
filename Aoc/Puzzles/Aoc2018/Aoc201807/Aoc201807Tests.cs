using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201807;

public class Aoc201807Tests
{
    [Test]
    public void FindsOrder()
    {
        const string input = """
Step C must be finished before step A can begin.
Step C must be finished before step F can begin.
Step A must be finished before step B can begin.
Step A must be finished before step D can begin.
Step B must be finished before step E can begin.
Step D must be finished before step E can begin.
Step F must be finished before step E can begin.
""";

        var assembler = new SleighAssembler(input.Trim(), 1, 0);
        var result = assembler.Assemble();

        result.Order.Should().Be("CABDFE");
    }

    [Test]
    public void FindsOrderConcurrently()
    {
        const string input = """
Step C must be finished before step A can begin.
Step C must be finished before step F can begin.
Step A must be finished before step B can begin.
Step A must be finished before step D can begin.
Step B must be finished before step E can begin.
Step D must be finished before step E can begin.
Step F must be finished before step E can begin.
""";

        var assembler = new SleighAssembler(input.Trim(), 2, 0);
        var result = assembler.Assemble();

        result.Order.Should().Be("CABFDE");
        result.Time.Should().Be(15);
    }
}