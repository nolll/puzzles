using Core.Polymers;

namespace ConsoleApp.Puzzles.Year2018.Puzzles.Day05
{
    public class Year2018Day05 : Year2018Day
    {
        public override int Day => 5;

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