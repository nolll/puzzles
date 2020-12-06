using System;
using Core.WhiteElephants;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day19 : Day2016
    {
        public Day19() : base(19)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var party = new WhiteElephantParty(Input);
            var winner1 = party.StealFromNextElf();
            Console.WriteLine($"Elf that gets all presents: {winner1}");

            WritePartTitle();
            var winner2 = party.StealFromElfAcrossCircle();
            Console.WriteLine($"Elf that gets all presents: {winner2}");
        }

        private const int Input = 3001330;
    }
}