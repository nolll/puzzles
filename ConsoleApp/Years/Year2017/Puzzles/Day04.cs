using System;
using Core.UniqueWordPasswords;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day04 : Day2017
    {
        public Day04() : base(4)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var validator = new PassphraseValidator();
            var validCount1 = validator.GetValidCount1(FileInput);
            return new PuzzleResult($"Valid passphrases 1: {validCount1}");
        }

        public override PuzzleResult RunPart2()
        {
            var validator = new PassphraseValidator();
            var validCount2 = validator.GetValidCount2(FileInput);
            return new PuzzleResult($"Valid passphrases 2: {validCount2}");
        }
    }
}