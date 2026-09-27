namespace Tests.Euler.Puzzles.Euler014;

public class Euler014Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Pzl.Euler.Puzzles.Euler014.Euler014();
        var result = puzzle.GenerateCollatzSequence(13);

        result.Count().Should().Be(10);
    }
}