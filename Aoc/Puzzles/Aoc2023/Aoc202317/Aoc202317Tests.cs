using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202317;

public class Aoc202317Tests
{
    [Test]
    public void LeastHeatPart1()
    {
        const string input = """
                             2413432311323
                             3215453535623
                             3255245654254
                             3446585845452
                             4546657867536
                             1438598798454
                             4457876987766
                             3637877979653
                             4654967986887
                             4564679986453
                             1224686865563
                             2546548887735
                             4322674655533
                             """;

        var result = Aoc202317.LeastHeatPart1(input);

        result.Should().Be(102);
    }

    [Test]
    public void LeastHeatPart2_1()
    {
        const string input = """
                             2413432311323
                             3215453535623
                             3255245654254
                             3446585845452
                             4546657867536
                             1438598798454
                             4457876987766
                             3637877979653
                             4654967986887
                             4564679986453
                             1224686865563
                             2546548887735
                             4322674655533
                             """;

        var result = Aoc202317.LeastHeatPart2(input);

        result.Should().Be(94);
    }

    [Test]
    public void LeastHeatPart2_2()
    {
        const string input = """
                             111111111111
                             999999999991
                             999999999991
                             999999999991
                             999999999991
                             """;

        var result = Aoc202317.LeastHeatPart2(input);

        result.Should().Be(71);
    }
}