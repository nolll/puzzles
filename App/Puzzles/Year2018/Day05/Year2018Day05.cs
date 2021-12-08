using App.Platform;

namespace App.Puzzles.Year2018.Day05
{
    public class Year2018Day05 : PuzzleDay
    {
        public override PuzzleResult RunPart1()
        {
            var polymerPuzzle = new PolymerPuzzle();
            var reducedPolymer = polymerPuzzle.GetReducedPolymer(FileInput);
            return new PuzzleResult(reducedPolymer.Length, 9172);
        }

        public override PuzzleResult RunPart2()
        {
            var polymerPuzzle = new PolymerPuzzle();
            var improvedPolymer = polymerPuzzle.GetImprovedPolymer(FileInput);
            return new PuzzleResult(improvedPolymer.Length, 6550);
        }
    }
}