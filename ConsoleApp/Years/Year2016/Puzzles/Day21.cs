using System;
using Core.ScrambledLetters;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day21 : Day2016
    {
        public Day21() : base(21)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var scrambler = new StringScrambler(FileInput);
            var scrambled = scrambler.Scramble("abcdefgh");
            Console.WriteLine($"Scrambled string: {scrambled}");

            WritePartTitle();
            var unscrambled = scrambler.Unscramble("fbgdceah");
            Console.WriteLine($"Unscrambled string: {unscrambled}");
        }
    }
}