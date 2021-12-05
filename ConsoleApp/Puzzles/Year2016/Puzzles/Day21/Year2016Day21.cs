using Core.ScrambledLetters;

namespace ConsoleApp.Puzzles.Year2016.Puzzles.Day21
{
    public class Year2016Day21 : Year2016Day
    {
        public override int Day => 21;

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