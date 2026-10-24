using Pzl.Aoc.Puzzles.Aoc2023;

namespace Tests.Aoc.Aoc2023;

public class Aoc202311Tests : PuzzleTest<Aoc202311>
{
    private const string Input = """
                                 ...#......
                                 .......#..
                                 #.........
                                 ..........
                                 ......#...
                                 .#........
                                 .........#
                                 ..........
                                 .......#..
                                 #...#.....
                                 """;

    [Fact]
    public void Distances1() => Sut.Solve(Input, 2).Should().Be(374);

    [Fact]
    public void Distances2() => Sut.Solve(Input, 10).Should().Be(1030);
}