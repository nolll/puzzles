using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler021Tests : PuzzleTest<Euler021>
{
    [Theory]
    [InlineData(220, 284)]
    [InlineData(284, 220)]
    public void Test(int input, int expected) => Sut.GetFactorialSum(input).Should().Be(expected);
}