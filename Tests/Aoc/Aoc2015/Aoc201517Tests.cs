using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

public class Aoc201517Tests : PuzzleTest<Aoc201517>
{
    [Fact]
    public void NumberOfCombinationsIsCorrect()
    {
        const string input = """
                             20
                             15
                             10
                             5
                             5
                             """;

        var containers = new Aoc201517.EggnogContainers(input.Trim());
        var combinations = containers.GetCombinations(25);

        combinations.Count.Should().Be(4);
    }
}