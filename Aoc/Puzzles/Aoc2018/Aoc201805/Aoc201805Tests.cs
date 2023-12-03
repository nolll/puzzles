using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aoc.Puzzles.Aoc2018.Aoc201805;

public class Aoc201805Tests
{
    [Test]
    public void FullPolymer()
    {
        const string input = "dabAcCaCBAcCcaDA";

        var puzzle = new PolymerPuzzle();
        var reducedPolymer = puzzle.GetReducedPolymer(input);
        reducedPolymer.Should().Be("dabCBAcaDA");
    }

    [Test]
    public void ImprovedPolymer()
    {
        const string input = "dabAcCaCBAcCcaDA";

        var puzzle = new PolymerPuzzle();
        var improvedPolymer = puzzle.GetImprovedPolymer(input);
        improvedPolymer.Should().Be("daDA");
    }
}