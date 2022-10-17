using NUnit.Framework;

namespace Core.Puzzles.Year2020.Day12;

public class Year2020Day12Tests
{
    [Test]
    public void SimpleFerryNavigation()
    {
        const string input = @"
F10
N3
F7
R90
F11";

        var system = new SimpleFerryNavigationSystem(input.Trim());
        system.Run();
        var result = system.DistanceTravelled;

        Assert.That(result, Is.EqualTo(25));
    }

    [Test]
    public void WaypointFerryNavigation()
    {
        const string input = @"
F10
N3
F7
R90
F11";

        var system = new WaypointFerryNavigationSystem(input.Trim());
        system.Run();
        var result = system.DistanceTravelled;

        Assert.That(result, Is.EqualTo(286));
    }
}