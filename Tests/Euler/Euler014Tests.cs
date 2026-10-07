using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler014Tests : PuzzleTest<Euler014>
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler014();
        var result = puzzle.GenerateCollatzSequence(13);

        result.Count().Should().Be(10);
    }
}