using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202223;

public class Aoc202223Tests
{
    [Test]
    public void Part1Small()
    {
        var puzzle = new Aoc202223(SmallInput);
        var (emptyCount, endRound) = puzzle.Run(SmallInput);

        emptyCount.Should().Be(25);
        endRound.Should().Be(4);
    }

    [Test]
    public void Part1Large()
    {
        var puzzle = new Aoc202223(LargeInput);
        var (emptyCount, endRound) = puzzle.Run(LargeInput, 10);

        emptyCount.Should().Be(110);
        endRound.Should().Be(10);
    }

    [Test]
    public void Part2()
    {
        var puzzle = new Aoc202223(LargeInput);
        var (emptyCount, endRound) = puzzle.Run(LargeInput);

        emptyCount.Should().Be(146);
        endRound.Should().Be(20);
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