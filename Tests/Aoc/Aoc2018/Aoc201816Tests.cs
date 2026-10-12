using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201816Tests : PuzzleTest<Aoc201816>
{
    [Fact]
    public void FindThreeMathingOperations()
    {
        var before = new long[] { 3, 2, 1, 1 };
        var after = new long[] { 3, 2, 2, 1 };

        var computer = new Aoc201816.Computer();
        var matchingOperations = computer.GetMatchingOperations(before, after, 2, 1, 2);

        matchingOperations.Count.Should().Be(3);
    }
}