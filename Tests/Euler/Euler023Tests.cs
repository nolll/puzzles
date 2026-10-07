using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler023Tests : PuzzleTest<Euler023>
{
    [Fact]
    public void Test()
    {
        var result = Euler023.FindAbundantNumbers(13);

        result.Count().Should().Be(1);
    }
}