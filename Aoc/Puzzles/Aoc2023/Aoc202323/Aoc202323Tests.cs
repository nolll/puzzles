using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202323;

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

    [Test]
    public void LongestHikePart1()
    {
        var result = Aoc202323.LongestHike(Input, false);

        result.Should().Be(94);
    }

    [Test]
    public void LongestHikePart2()
    {
        var result = Aoc202323.LongestHike(Input, true);

        result.Should().Be(154);
    }
}