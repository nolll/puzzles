using System;
using Core.UniqueWordPasswords;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day04 : Day2017
    {
        public Day04() : base(4)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var validator = new PassphraseValidator();
            var validCount1 = validator.GetValidCount1(FileInput);
            Console.WriteLine($"Valid passphrases 1: {validCount1}");

            WritePartTitle();
            var validCount2 = validator.GetValidCount2(FileInput);
            Console.WriteLine($"Valid passphrases 2: {validCount2}");
        }
    }
}