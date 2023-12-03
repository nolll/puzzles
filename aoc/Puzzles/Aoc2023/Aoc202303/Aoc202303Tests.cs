using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2023.Aoc202303;

public class Aoc202303Tests
{
    private const string Input = """
                                 467..114..
                                 ...*......
                                 ..35..633.
                                 ......#...
                                 617*......
                                 .....+.58.
                                 ..592.....
                                 ......755.
                                 ...$.*....
                                 .664.598..
                                 """;

    [Test]
    public void EngineParts()
    {
        var result = Aoc202303.Run(Input);

        result.EngineParts.Should().Be(4361);
    }

    [Test]
    public void GearRatios()
    {
        var result = Aoc202303.Run(Input);

        result.GearRatios.Should().Be(467835);
    }
}