using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202003Tests : PuzzleTest<Aoc202003>
{
    private const string Input = """
                                 ..##.......
                                 #...#...#..
                                 .#....#..#.
                                 ..#.#...#.#
                                 .#...##..#.
                                 ..#.##.....
                                 .#.#.#....#
                                 .#........#
                                 #.##...#...
                                 #...##....#
                                 .#..#...#.#
                                 """;

    [Fact]
    public void TreeCount_3_1_IsCorrect() => Sut.GetTreeCount(Input, new Aoc202003.TreeTrajectory(3, 1)).Should().Be(7);

    [Fact]
    public void TreeCount_1_2_IsCorrect() => Sut.GetTreeCount(Input, new Aoc202003.TreeTrajectory(1, 2)).Should().Be(2);

    [Fact]
    public void TreeCountsAreCorrect() => Sut.Part2(Input).Should().Be(336);
}