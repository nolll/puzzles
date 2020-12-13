using System;
using Core.WhiteElephants;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day19 : Day2016
    {
        public Day19() : base(19)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var party = new WhiteElephantParty(Input);
            var winner = party.StealFromNextElf();
            return new PuzzleResult(winner, 1_808_357);
        }

        public override PuzzleResult RunPart2()
        {
            var party = new WhiteElephantParty(Input);
            var winner = party.StealFromElfAcrossCircle();
            return new PuzzleResult(winner, 1_407_007);
        }

        private const int Input = 3001330;
    }
}