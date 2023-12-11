using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201805;

[Name("Alchemical Reduction")]
public class Aoc201805(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var polymerPuzzle = new PolymerPuzzle();
        var reducedPolymer = polymerPuzzle.GetReducedPolymer(Input);
        return new PuzzleResult(reducedPolymer.Length, "b0180e8fdf70d1a6cb40a7e588873a5f");
    }

    protected override PuzzleResult RunPart2()
    {
        var polymerPuzzle = new PolymerPuzzle();
        var improvedPolymer = polymerPuzzle.GetImprovedPolymer(Input);
        return new PuzzleResult(improvedPolymer.Length, "923436b9c396a53a404f30f51617b9d9");
    }
}