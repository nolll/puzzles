using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler037Tests : PuzzleTest<Euler037>
{
    [Theory]
    [InlineData(1061, false)]
    [InlineData(3797, true)]
    public void IsTruncatable(int n, bool expected) => Sut.IsTruncatable(n).Should().Be(expected);
}