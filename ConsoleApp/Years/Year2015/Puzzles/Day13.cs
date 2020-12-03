using System;
using Core.KnightsOfTheDinnerTable;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day13 : Day2015
    {
        public Day13() : base(13)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var table = new DinnerTable(FileInput);
            Console.WriteLine($"Happiness change: {table.HappinessChange}");

            WritePartTitle();
            var table2 = new DinnerTable(FileInput, true);
            Console.WriteLine($"Happiness change including me: {table2.HappinessChange}");
        }
    }
}