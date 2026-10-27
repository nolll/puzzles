using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler027Tests : PuzzleTest<Euler027>
{
    [Fact]
    public void Test() => Sut.GetPrimeCount(-79, 1601).Should().Be(80);
}