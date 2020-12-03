using System;
using Core.NaughtyOrNice;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day05 : Day2015
    {
        public Day05() : base(5)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var evaluator = new NaughtyOrNiceEvaluator();
            var nice1Count = evaluator.GetNiceCount1(FileInput);
            Console.WriteLine($"Number of nice strings (algorithm 1): {nice1Count}");

            WritePartTitle();
            var nice2Count = evaluator.GetNiceCount2(FileInput);
            Console.WriteLine($"Number of nice strings (algorithm 2): {nice2Count}");
        }
    }
}