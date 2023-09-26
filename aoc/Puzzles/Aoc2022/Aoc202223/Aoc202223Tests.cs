using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2022.Aoc202223;

public class Aoc202223Tests
{
    [Test]
    public void Part1Small()
    {
        var puzzle = new Aoc202223();
        var (emptyCount, endRound) = puzzle.Run(SmallInput);

        Assert.That(emptyCount, Is.EqualTo(25));
        Assert.That(endRound, Is.EqualTo(4));
    }

    [Test]
    public void Part1Large()
    {
        var puzzle = new Aoc202223();
        var (emptyCount, endRound) = puzzle.Run(LargeInput, 10);

        Assert.That(emptyCount, Is.EqualTo(110));
        Assert.That(endRound, Is.EqualTo(10));
    }

    [Test]
    public void Part2()
    {
        var puzzle = new Aoc202223();
        var (emptyCount, endRound) = puzzle.Run(LargeInput);

        Assert.That(emptyCount, Is.EqualTo(146));
        Assert.That(endRound, Is.EqualTo(20));
    }

    private const string SmallInput = """
.....
..##.
..#..
.....
..##.
.....
""";

    private const string LargeInput = """
..............
..............
.......#......
.....###.#....
...#...#.#....
....#...##....
...#.###......
...##.#.##....
....#..#......
..............
..............
..............
""";
}