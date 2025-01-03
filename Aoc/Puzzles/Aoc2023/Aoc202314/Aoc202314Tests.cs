using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202314;

public class Aoc202314Tests
{
    [Test]
    public void RollNorth()
    {
        const string input = """
                             O....#....
                             O.OO#....#
                             .....##...
                             OO.#O....O
                             .O.....O#.
                             O.#..O.#.#
                             ..O..#O..O
                             .......O..
                             #....###..
                             #OO..#....
                             """;

        var result = Aoc202314.RollNorth(input);

        result.Should().Be(136);
    }

    [Test]
    public void RunOneCycle()
    {
        const string input = """
                             O....#....
                             O.OO#....#
                             .....##...
                             OO.#O....O
                             .O.....O#.
                             O.#..O.#.#
                             ..O..#O..O
                             .......O..
                             #....###..
                             #OO..#....
                             """;

        const string expected = """
                                .....#....
                                ....#...O#
                                ...OO##...
                                .OO#......
                                .....OOO#.
                                .O#...O#.#
                                ....O#....
                                ......OOOO
                                #...O###..
                                #..OO#....
                                """;

        var result = Aoc202314.RunCycle(input, 1);

        result.Print().Should().Be(expected);
    }

    [Test]
    public void RunManyCycles()
    {
        const string input = """
                             O....#....
                             O.OO#....#
                             .....##...
                             OO.#O....O
                             .O.....O#.
                             O.#..O.#.#
                             ..O..#O..O
                             .......O..
                             #....###..
                             #OO..#....
                             """;

        var result = Aoc202314.RunManyCycles(input);

        result.Should().Be(64);
    }

    [Test]
    public void RunTwoCycles()
    {
        const string input = """
                             O....#....
                             O.OO#....#
                             .....##...
                             OO.#O....O
                             .O.....O#.
                             O.#..O.#.#
                             ..O..#O..O
                             .......O..
                             #....###..
                             #OO..#....
                             """;

        const string expected = """
                                .....#....
                                ....#...O#
                                .....##...
                                ..O#......
                                .....OOO#.
                                .O#...O#.#
                                ....O#...O
                                .......OOO
                                #..OO###..
                                #.OOO#...O
                                """;

        var result = Aoc202314.RunCycle(input, 2);

        result.Print().Should().Be(expected);
    }
}