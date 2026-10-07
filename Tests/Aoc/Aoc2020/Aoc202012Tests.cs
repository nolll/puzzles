using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202012Tests : PuzzleTest<Aoc202012>
{
    [Fact]
    public void SimpleFerryNavigation()
    {
        const string input = """
                             F10
                             N3
                             F7
                             R90
                             F11
                             """;

        var system = new Aoc202012.SimpleFerryNavigationSystem(input);
        system.Run();
        var result = system.DistanceTravelled;

        result.Should().Be(25);
    }

    [Fact]
    public void WaypointFerryNavigation()
    {
        const string input = """
                             F10
                             N3
                             F7
                             R90
                             F11
                             """;

        var system = new Aoc202012.WaypointFerryNavigationSystem(input);
        system.Run();
        var result = system.DistanceTravelled;

        result.Should().Be(286);
    }
}