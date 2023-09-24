using NUnit.Framework;

namespace Aoc.Puzzles.Year2016.Day24;

public class Year2016Day24Tests
{
    [Test]
    public void FindsClosestRoute()
    {
        const string input = """
###########
#0.1.....2#
#.#######.#
#4.......3#
###########
""";

        var navigator = new AirDuctNavigator(input);
        var shortestPath = navigator.Run(false);

        Assert.That(shortestPath, Is.EqualTo(14));
    }

    [Test]
    public void FindsClosestRouteAndGoesBackToStart()
    {
        const string input = """
###########
#0.1.....2#
#.#######.#
#4.......3#
###########
""";

        var navigator = new AirDuctNavigator(input);
        var shortestPath = navigator.Run(true);

        Assert.That(shortestPath, Is.EqualTo(20));
    }
}