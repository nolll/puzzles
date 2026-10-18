using Pzl.Aoc.Puzzles.Aoc2021;

namespace Tests.Aoc.Aoc2021;

public class Aoc202106Tests : PuzzleTest<Aoc202106>
{
    [Theory]
    [InlineData(18, 26)]
    [InlineData(80, 5934)]
    [InlineData(256, 26_984_457_539)]
    public void Test(int days, long expected) => Sut.Solve("3,4,3,1,2", days).Should().Be(expected);
}