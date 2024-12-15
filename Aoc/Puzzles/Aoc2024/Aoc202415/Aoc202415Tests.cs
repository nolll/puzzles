using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202415;

public class Aoc202415Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             ########
                             #..O.O.#
                             ##@.O..#
                             #...O..#
                             #.#.O..#
                             #...O..#
                             #......#
                             ########
                             
                             <^^>>>vv<v>>v<<
                             """;

        Sut.Part1(input).Answer.Should().Be("2028");
    }

    [Test]
    public void Part2_1()
    {
        const string input = """
                             #######
                             #...#.#
                             #.....#
                             #..OO@#
                             #..O..#
                             #.....#
                             #######
                             
                             <vv<<^^<<^^
                             """;

        Sut.Part2(input).Answer.Should().Be("618");
    }
    
    [Test]
    public void Part2_2()
    {
        const string input = """
                             ##########
                             #..O..O.O#
                             #......O.#
                             #.OO..O.O#
                             #..O@..O.#
                             #O#..O...#
                             #O..O..O.#
                             #.OO.O.OO#
                             #....O...#
                             ##########

                             <vv>^<v^>v>^vv^v>v<>v^v<v<^vv<<<^><<><>>v<vvv<>^v^>^<<<><<v<<<v^vv^v>^
                             vvv<<^>^v^^><<>>><>^<<><^vv^^<>vvv<>><^^v>^>vv<>v<<<<v<^v>^<^^>>>^<v<v
                             ><>vv>v^v^<>><>>>><^^>vv>v<^^^>>v^v^<^^>v^^>v^<^v>v<>>v^v^<v>v^^<^^vv<
                             <<v<^>>^^^^>>>v^<>vvv^><v<<<>^^^vv^<vvv>^>v<^^^^v<>^>vvvv><>>v^<<^^^^^
                             ^><^><>>><>^^<<^^v>>><^<v>^<vv>>v>>>^v><>^v><<<<v>>v<v<v>vvv>^<><<>^><
                             ^>><>^v<><^vvv<^^<><v<<<<<><^v<<<><<<^^<v<^^^><^>>^<v^><<<^>>^v<v^v<v^
                             >^>>^v>vv>^<<^v<>><<><<v<<v><>v<^vv<<<>^^v^>^^>>><<^v>>v^v><^^>>^<>vv^
                             <><^^>^^^<><vvvvv^v<v<<>^v<v>v<<^><<><<><<<^^<<<^<<>><<><^^^>^^<>^>v<>
                             ^^>vv<^v^v<vv>^<><v<^v>^^^>>>^^vvv^>vvv<>>>^<^>>>>>^<<^v>^vvv<>^<><<v>
                             v^^>>><<^^<>>^v^<v^vv<>v^<<>^<^v^v><^<<<><<^<v><v<>vv>>v><v^<vv<>v^<<^
                             """;

        Sut.Part2(input).Answer.Should().Be("9021");
    }

    private static Aoc202415 Sut => new();
}