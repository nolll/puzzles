using App.Platform;

namespace App.Puzzles.Year2017.Day14
{
    public class Year2017Day14 : PuzzleDay
    {
        public override PuzzleResult RunPart1()
        {
            var defragmenter = new DiskDefragmenter(Input);
            return new PuzzleResult(defragmenter.UsedCount, 8222);
        }

        public override PuzzleResult RunPart2()
        {
            var defragmenter = new DiskDefragmenter(Input);
            return new PuzzleResult(defragmenter.RegionCount, 1086);
        }

        private const string Input = "amgozmfv";
    }
}