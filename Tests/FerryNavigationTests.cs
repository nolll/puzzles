using ConsoleApp.Puzzles.Year2020.Day12;
using NUnit.Framework;

namespace Tests
{
    public class FerryNavigationTests
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

            var system = new SimpleFerryNavigationSystem(input);
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

            var system = new WaypointFerryNavigationSystem(input);
            system.Run();
            var result = system.DistanceTravelled;

            Assert.That(result, Is.EqualTo(286));
        }
    }
}