using Core.MonsterImages;

namespace ConsoleApp.Puzzles.Year2020.Puzzles
{
    public class Year2020Day19 : Year2020Day
    {
        public override int Day => 19;

        public override PuzzleResult RunPart1()
        {
            var validator = new MonsterImageValidator(FileInput);
            var result = validator.ValidCount();
            return new PuzzleResult(result, 122);
        }

        public override PuzzleResult RunPart2()
        {
            var validator = new MonsterImageValidator(FileInput, true);
            var result = validator.ValidCount();
            return new PuzzleResult(result, 287);
        }
    }
}