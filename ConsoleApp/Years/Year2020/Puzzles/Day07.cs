using System;
using Core.LuggageRules;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day07 : Day2020
    {
        public Day07() : base(7)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var processor = new LuggageProcessor(FileInput);
            var count1 = processor.NumberOfBagsThatCanContainGoldBags();
            return new PuzzleResult(count1, 272);
        }

        public override PuzzleResult RunPart2()
        {
            var processor = new LuggageProcessor(FileInput);
            var count2 = processor.NumberOfBagsThatAGoldBagContains();
            return new PuzzleResult(count2, 172246);
        }
    }
}