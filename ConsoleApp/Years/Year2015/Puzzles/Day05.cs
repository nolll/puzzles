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
            var niceCount = evaluator.GetNiceCount1(FileInput);
            return new PuzzleResult(niceCount, 255);
        }

        public override PuzzleResult RunPart2()
        {
            var evaluator = new NaughtyOrNiceEvaluator();
            var niceCount = evaluator.GetNiceCount2(FileInput);
            return new PuzzleResult(niceCount, 55);
        }
    }
}