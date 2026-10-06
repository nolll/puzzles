using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201714Tests : PuzzleTest<Aoc201714>
{
    private const string Input = "flqrgnkx";

    [Fact]
    public void UsedSquaresAreCorrect() => Sut.Part1(Input).Should().Be(8108);

    [Fact]
    public void FindsRegions() => Sut.Part2(Input).Should().Be(1242);
}