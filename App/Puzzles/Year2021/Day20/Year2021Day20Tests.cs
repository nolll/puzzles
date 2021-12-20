using NUnit.Framework;

namespace App.Puzzles.Year2021.Day20;

public class Year2021Day20Tests
{
    [Test]
    public void Part1()
    {
        var trenchMap = new TrenchMap();
        var result = trenchMap.GetLitPixelCount(Input, 2);

        Assert.That(result, Is.EqualTo(35));
    }

    [Test]
    public void Part2()
    {
        var trenchMap = new TrenchMap();
        var result = trenchMap.GetLitPixelCount(Input, 50);

        Assert.That(result, Is.EqualTo(3351));
    }

    private const string Input = @"
..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..###..######.###...####..#..#####..##..#.#####...##.#.#..#.##..#.#......#.###.######.###.####...#.##.##..#..#..#####.....#.#....###..#.##......#.....#..#..#..##..#...##.######.####.####.#.#...#.......#..#.#.#...####.##.#......#..#...##.#.##..#...##.#.##..###.#......#.#.......#.#.#.####.###.##...#.....####.#..#..#.##.#....##..#.####....##...##..#...#......#.#.......#.......##..####..#...#.#.#...##..#.#..###..#####........#..####......#..#

#..#.
#....
##..#
..#..
..###";
}