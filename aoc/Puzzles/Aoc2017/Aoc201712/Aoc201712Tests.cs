using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2017.Aoc201712;

public class Aoc201712Tests
{
    [Test]
    public void GroupCounts()
    {
        const string input = """
0 <-> 2
1 <-> 1
2 <-> 0, 3, 4
3 <-> 2, 4
4 <-> 2, 3, 6
5 <-> 6
6 <-> 4, 5
""";

        var pipes = new Pipes(input.Trim());

        pipes.PipesInGroupZero.Should().Be(6);
        pipes.GroupCount.Should().Be(2);
    }
}