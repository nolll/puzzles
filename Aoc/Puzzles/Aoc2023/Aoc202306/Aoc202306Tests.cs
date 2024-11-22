using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202306;

public class Aoc202306Tests
{
    [Test]
    public void BoatRace1()
    {
        const string input = """
                             Time:      7  15   30
                             Distance:  9  40  200
                             """;

        var result = Aoc202306.BoatRace1(input);

        result.Should().Be(288);
    }

    [Test]
    public void BoatRace2()
    {
        const string input = """
                             Time:      7  15   30
                             Distance:  9  40  200
                             """;

        var result = Aoc202306.BoatRace2(input);

        result.Should().Be(71503);
    }
}