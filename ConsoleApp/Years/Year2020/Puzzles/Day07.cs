using System;
using Core.LuggageRules;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day07 : Day2020
    {
        public Day07() : base(7)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var processor = new LuggageProcessor(FileInput);
            var count1 = processor.NumberOfBagsThatCanContainGoldBags();
            Console.WriteLine($"Number of outermost bags that can contain shiny gold bags: {count1}");

            WritePartTitle();
            var count2 = processor.NumberOfBagsThatAGoldBagContains();
            Console.WriteLine($"Number of bags that shiny gold bag contains: {count2}");
        }
    }
}