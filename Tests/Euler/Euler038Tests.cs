using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler038Tests : PuzzleTest<Euler038>
{
    [Theory]
    [InlineData(9, 918273645)]
    [InlineData(192, 192384576)]
    public void GetConcatenatedProduct(int n, long expected) => Sut.GetConcatenatedProduct(n).Should().Be(expected);
}