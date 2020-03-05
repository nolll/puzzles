using System;
using Core.WhiteElephants;

namespace ConsoleApp.Years.Year2016
{
    public class Day19 : Day
    {
        public Day19() : base(19)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var party = new WhiteElephantParty(Input);
            Console.WriteLine($"Elf that gets all presents: {party.Winner}");
        }

        private const int Input = 3001330;
    }
}