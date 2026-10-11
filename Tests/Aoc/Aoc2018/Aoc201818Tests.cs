using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201818Tests : PuzzleTest<Aoc201818>
{
    private const string Input = """
                                 .#.#...|#.
                                 .....#|##|
                                 .|..|...#.
                                 ..|#.....#
                                 #.#|||#|#|
                                 ...#.||...
                                 .|....|...
                                 ||...#|.#|
                                 |.||||..|.
                                 ...#.|..|.
                                 """;

    [Fact]
    public void ResourceValueIsCorrect() => Sut.Solve(Input, 10).Should().Be(1147);
}