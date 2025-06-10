using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202415;

public class Ece202415Tests
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
    
    [Test]
    public void Part3()
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

        Sut.Part3(input).Answer.Should().Be("38");
    }

    private static Ece202415 Sut => new();
}