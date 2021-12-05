using Core.Bingo;
using Core.UnderwaterVents;

namespace ConsoleApp.Years.Year2021.Puzzles
{
    public class Day05 : Day2021
    {
        public Day05() : base(5)
        {
        }

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