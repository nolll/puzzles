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
    }
}