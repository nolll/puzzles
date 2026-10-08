using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201807Tests : PuzzleTest<Aoc201807>
{
    [Fact]
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

        var (order, _) = Sut.Solve(input, 1, 0);
        order.Should().Be("CABDFE");
    }

    [Fact]
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

        var (order, time) = Sut.Solve(input, 2, 0);
        order.Should().Be("CABFDE");
        time.Should().Be(15);
    }
}