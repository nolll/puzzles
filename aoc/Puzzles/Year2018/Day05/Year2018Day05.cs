using Common.Puzzles;

namespace Aoc.Puzzles.Year2018.Day05;

public class Year2018Day05 : AocPuzzle
{
    public override string Name => "Alchemical Reduction";

    protected override PuzzleResult RunPart1()
    {
        var polymerPuzzle = new PolymerPuzzle();
        var reducedPolymer = polymerPuzzle.GetReducedPolymer(FileInput);
        return new PuzzleResult(reducedPolymer.Length, 9172);
    }

    protected override PuzzleResult RunPart2()
    {
        var polymerPuzzle = new PolymerPuzzle();
        var improvedPolymer = polymerPuzzle.GetImprovedPolymer(FileInput);
        return new PuzzleResult(improvedPolymer.Length, 6550);
    }
}