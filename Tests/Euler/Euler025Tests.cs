using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler025Tests : PuzzleTest<Euler025>
{
    [Fact]
    public void Test() => Sut.Run(3).Should().Be(12);
}