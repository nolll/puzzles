using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202012;

public class Aoc202012Tests
{
    [Test]
    public void SimpleFerryNavigation()
    {
        const string input = """
                             F10
                             N3
                             F7
                             R90
                             F11
                             """;

        var system = new SimpleFerryNavigationSystem(input.Trim());
        system.Run();
        var result = system.DistanceTravelled;

        result.Should().Be(25);
    }

    [Test]
    public void WaypointFerryNavigation()
    {
        const string input = """
                             F10
                             N3
                             F7
                             R90
                             F11
                             """;

        var system = new WaypointFerryNavigationSystem(input.Trim());
        system.Run();
        var result = system.DistanceTravelled;

        result.Should().Be(286);
    }
}