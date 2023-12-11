using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202311;

public class Aoc202311Tests
{
    [Test]
    public void Distances1()
    {
        const string input = """
                             ...#......
                             .......#..
                             #.........
                             ..........
                             ......#...
                             .#........
                             .........#
                             ..........
                             .......#..
                             #...#.....
                             """;

        var result = Aoc202311.Distances(input, 1);

        result.Should().Be(374);
    }

    [Test]
    public void Distances2()
    {
        const string input = """
                             ...#......
                             .......#..
                             #.........
                             ..........
                             ......#...
                             .#........
                             .........#
                             ..........
                             .......#..
                             #...#.....
                             """;

        var result = Aoc202311.Distances(input, 9);

        result.Should().Be(1030);
    }
}