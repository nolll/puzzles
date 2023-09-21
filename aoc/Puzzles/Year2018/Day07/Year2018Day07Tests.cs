using NUnit.Framework;

namespace Aoc.Puzzles.Year2018.Day07;

public class Year2018Day07Tests
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

        Assert.That(result.Order, Is.EqualTo("CABDFE"));
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

        Assert.That(result.Order, Is.EqualTo("CABFDE"));
        Assert.That(result.Time, Is.EqualTo(15));
    }
}