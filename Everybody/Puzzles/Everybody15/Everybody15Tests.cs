using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody15;

public class Everybody15Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             #####.#####
                             #.........#
                             #.######.##
                             #.........#
                             ###.#.#####
                             #H.......H#
                             ###########
                             """;

        Sut.Part1(input).Answer.Should().Be("26");
    }

    [Test]
    public void Part2()
    {
        const string input = """
                             ##########.##########
                             #...................#
                             #.###.##.###.##.#.#.#
                             #..A#.#..~~~....#A#.#
                             #.#...#.~~~~~...#.#.#
                             #.#.#.#.~~~~~.#.#.#.#
                             #...#.#.B~~~B.#.#...#
                             #...#....BBB..#....##
                             #C............#....C#
                             #####################
                             """;

        Sut.Part2(input).Answer.Should().Be("38");
    }

    private static Everybody15 Sut => new();
}