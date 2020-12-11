using Core.NaughtyOrNice;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day05 : Day2015
    {
        public Day05() : base(5)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var evaluator = new NaughtyOrNiceEvaluator();
            var nice1Count = evaluator.GetNiceCount1(FileInput);
            return new PuzzleResult($"Number of nice strings (algorithm 1): {nice1Count}");
        }

        public override PuzzleResult RunPart2()
        {
            var evaluator = new NaughtyOrNiceEvaluator();
            var nice2Count = evaluator.GetNiceCount2(FileInput);
            return new PuzzleResult($"Number of nice strings (algorithm 2): {nice2Count}");
        }
    }
}