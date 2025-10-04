namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201624;

public class Aoc201624Tests
{
    [Fact]
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

        shortestPath.Should().Be(14);
    }

    [Fact]
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

        shortestPath.Should().Be(20);
    }
}