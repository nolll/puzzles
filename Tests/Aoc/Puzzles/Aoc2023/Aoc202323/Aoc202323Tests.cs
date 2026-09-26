namespace Tests.Aoc.Puzzles.Aoc2023.Aoc202323;

public class Aoc202323Tests
{
    private const string Input = """
                                 #.#####################
                                 #.......#########...###
                                 #######.#########.#.###
                                 ###.....#.>.>.###.#.###
                                 ###v#####.#v#.###.#.###
                                 ###.>...#.#.#.....#...#
                                 ###v###.#.#.#########.#
                                 ###...#.#.#.......#...#
                                 #####.#.#.#######.#.###
                                 #.....#.#.#.......#...#
                                 #.#####.#.#.#########v#
                                 #.#...#...#...###...>.#
                                 #.#.#v#######v###.###v#
                                 #...#.>.#...>.>.#.###.#
                                 #####v#.#.###v#.#.###.#
                                 #.....#...#...#.#.#...#
                                 #.#########.###.#.#.###
                                 #...###...#...#...#.###
                                 ###.###.#.###v#####v###
                                 #...#...#.#.>.>.#.>.###
                                 #.###.###.#.###.#.#v###
                                 #.....###...###...#...#
                                 #####################.#
                                 """;

    [Fact]
    public void LongestHikePart1()
    {
        var result = Pzl.Aoc.Puzzles.Aoc2023.Aoc202323.Aoc202323.LongestHike(Input, false);

        result.Should().Be(94);
    }

    [Fact]
    public void LongestHikePart2()
    {
        var result = Pzl.Aoc.Puzzles.Aoc2023.Aoc202323.Aoc202323.LongestHike(Input, true);

        result.Should().Be(154);
    }
}