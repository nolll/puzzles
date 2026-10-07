using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler064Tests : PuzzleTest<Euler064>
{
    [Theory]
    [InlineData(13, "[3; (1, 1, 1, 1, 6)]")]
    [InlineData(23, "[4; (1, 3, 1, 8)]")]
    public void FractionsFor(int n, string expected)
    {
        var result = Euler064.GetContinuedFraction(n);
        var period = string.Join(", ", result.cycle);
        $"[{result.a0}; ({period})]".Should().Be(expected);
    }
}