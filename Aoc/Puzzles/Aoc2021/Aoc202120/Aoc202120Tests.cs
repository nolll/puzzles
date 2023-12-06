using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202120;

public class Aoc202120Tests
{
    [Test]
    public void Part1()
    {
        var trenchMap = new TrenchMap();
        var result = trenchMap.GetLitPixelCount(Input, 2);

        result.Should().Be(35);
    }

    [Test]
    public void Part2()
    {
        var trenchMap = new TrenchMap();
        var result = trenchMap.GetLitPixelCount(Input, 50);

        result.Should().Be(3351);
    }

    private const string Input = """
..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..###..######.###...####..#..#####..##..#.#####...##.#.#..#.##..#.#......#.###.######.###.####...#.##.##..#..#..#####.....#.#....###..#.##......#.....#..#..#..##..#...##.######.####.####.#.#...#.......#..#.#.#...####.##.#......#..#...##.#.##..#...##.#.##..###.#......#.#.......#.#.#.####.###.##...#.....####.#..#..#.##.#....##..#.####....##...##..#...#......#.#.......#.......##..####..#...#.#.#...##..#.#..###..#####........#..####......#..#

#..#.
#....
##..#
..#..
..###
""";
}