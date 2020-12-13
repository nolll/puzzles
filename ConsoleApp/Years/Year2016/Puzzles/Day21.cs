using System;
using Core.ScrambledLetters;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day21 : Day2016
    {
        public Day21() : base(21)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var scrambler = new StringScrambler(FileInput);
            var scrambled = scrambler.Scramble("abcdefgh");
            return new PuzzleResult(scrambled, "dbfgaehc");
        }

        public override PuzzleResult RunPart2()
        {
            var scrambler = new StringScrambler(FileInput);
            var unscrambled = scrambler.Unscramble("fbgdceah");
            return new PuzzleResult(unscrambled, "aghfcdeb");
        }
    }
}