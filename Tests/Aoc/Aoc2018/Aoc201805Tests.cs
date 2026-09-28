using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201805Tests
{
    [Fact]
    public void FullPolymer()
    {
        const string input = "dabAcCaCBAcCcaDA";

        var puzzle = new Aoc201805.PolymerPuzzle();
        var reducedPolymer = puzzle.GetReducedPolymer(input);
        reducedPolymer.Should().Be("dabCBAcaDA");
    }

    [Fact]
    public void ImprovedPolymer()
    {
        const string input = "dabAcCaCBAcCcaDA";

        var puzzle = new Aoc201805.PolymerPuzzle();
        var improvedPolymer = puzzle.GetImprovedPolymer(input);
        improvedPolymer.Should().Be("daDA");
    }
}