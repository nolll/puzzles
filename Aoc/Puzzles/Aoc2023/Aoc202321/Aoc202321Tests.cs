using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202321;

public class Aoc202321Tests
{
    private const string Input = """
                                 ...........
                                 .....###.#.
                                 .###.##..#.
                                 ..#.#...#..
                                 ....#.#....
                                 .##..S####.
                                 .##..#...#.
                                 .......##..
                                 .##.#.####.
                                 .##..##.##.
                                 ...........
                                 """;

    [Test]
    public void CountPositionsAfter1() => 
        Aoc202321.CountPositionsAfter64(Input, 1).Should().Be(2);

    [Test]
    public void CountPositionsAfter2() => 
        Aoc202321.CountPositionsAfter64(Input, 2).Should().Be(4);

    [Test]
    public void CountPositionsAfter3() => 
        Aoc202321.CountPositionsAfter64(Input, 3).Should().Be(6);
}