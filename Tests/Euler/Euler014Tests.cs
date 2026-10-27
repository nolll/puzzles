using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler014Tests : PuzzleTest<Euler014>
{
    [Fact]
    public void Test() => Sut.GenerateCollatzSequence(13).Count().Should().Be(10);
}