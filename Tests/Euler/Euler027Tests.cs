using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler027Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler027();
        var result = puzzle.GetPrimeCount(-79, 1601);

        result.Should().Be(80);
    }
}