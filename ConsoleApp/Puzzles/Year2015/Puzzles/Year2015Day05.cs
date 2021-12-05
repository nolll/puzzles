﻿using Core.NaughtyOrNice;

namespace ConsoleApp.Puzzles.Year2015.Puzzles
{
    public class Year2015Day05 : Year2015Day
    {
        public override int Day => 5;

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