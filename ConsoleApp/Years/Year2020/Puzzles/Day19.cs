using Core.MathHomework;
using Core.MonsterImages;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day19 : Day2020
    {
        public Day19() : base(19)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var validator = new MonsterImageValidator(FileInput);
            var result = validator.ValidCount();
            return new PuzzleResult(result);
        }

        public override PuzzleResult RunPart2()
        {
            var input = FileInput
                .Replace("8: 42", "8: 42 | 42 8")
                .Replace("11: 42 31", "11: 42 31 | 42 11 31");
            var validator = new MonsterImageValidator(input);
            var result = validator.ValidCount();
            return new PuzzleResult(result);
        }
    }
}