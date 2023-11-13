using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2021.Aoc202111;

public class Aoc202111Tests
{
    [Test]
    public void Part1()
    {
        var flasher = new OctopusFlasher(Input);
        var result = flasher.Run(100);

        result.Should().Be(1656);
    }

    [Test]
    public void Part2()
    {
        var flasher = new OctopusFlasher(Input);
        var result = flasher.Run();

        result.Should().Be(195);
    }

    private const string Input = """
5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526
""";
}