using System;
using Core.WhiteElephants;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Year2016Day19 : Year2016Day
    {
        public override int Day => 19;

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