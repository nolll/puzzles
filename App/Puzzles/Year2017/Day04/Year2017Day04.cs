using App.Platform;

namespace App.Puzzles.Year2017.Day04
{
    public class Year2017Day04 : PuzzleDay
    {
        public override PuzzleResult RunPart1()
        {
            var validator = new PassphraseValidator();
            var validCount1 = validator.GetValidCount1(FileInput);
            return new PuzzleResult(validCount1, 477);
        }

        public override PuzzleResult RunPart2()
        {
            var validator = new PassphraseValidator();
            var validCount2 = validator.GetValidCount2(FileInput);
            return new PuzzleResult(validCount2, 167);
        }
    }
}