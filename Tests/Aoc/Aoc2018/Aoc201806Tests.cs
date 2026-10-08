using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201806Tests : PuzzleTest<Aoc201806>
{
    private const string Input = """
                                 1, 1
                                 1, 6
                                 8, 3
                                 3, 4
                                 5, 5
                                 8, 9
                                 """;

    [Fact]
    public void FindsLargestArea() => Sut.GetSizeOfLargestArea(Input).Should().Be(17);

    [Fact]
    public void FindsAreaOfCentralArea() => Sut.GetSizeOfCentralArea(Input, 32).Should().Be(16);
}