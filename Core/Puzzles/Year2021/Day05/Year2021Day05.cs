using Core.Platform;

namespace Core.Puzzles.Year2021.Day05
{
    public class Year2021Day05 : Year2021Day
    {
        public override int Day => 5;

        public override PuzzleResult RunPart1()
        {
            var ventsMap = new VentsMap();
            var result = ventsMap.Run(FileInput, true);

            return new PuzzleResult(result, 4728);
        }

        public override PuzzleResult RunPart2()
        {
            var ventsMap = new VentsMap();
            var result = ventsMap.Run(FileInput, false);

            return new PuzzleResult(result, 17717);
        }
    }
}