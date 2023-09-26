using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2018.Aoc201805;

public class Aoc201805 : AocPuzzle
{
    public override string Name => "Alchemical Reduction";

    protected override PuzzleResult RunPart1()
    {
        var polymerPuzzle = new PolymerPuzzle();
        var reducedPolymer = polymerPuzzle.GetReducedPolymer(InputFile);
        return new PuzzleResult(reducedPolymer.Length, 9172);
    }

    protected override PuzzleResult RunPart2()
    {
        var polymerPuzzle = new PolymerPuzzle();
        var improvedPolymer = polymerPuzzle.GetImprovedPolymer(InputFile);
        return new PuzzleResult(improvedPolymer.Length, 6550);
    }
}