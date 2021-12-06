using Core.Platform;

namespace Core.Puzzles.Year2017.Day06
{
    public class Year2017Day06 : Year2017Day
    {
        public override int Day => 6;

        public override PuzzleResult RunPart1()
        {
            var reallocator = new MemoryReallocator(FileInput);
            reallocator.Run();
            return new PuzzleResult(reallocator.Steps, 6681);
        }

        public override PuzzleResult RunPart2()
        {
            var reallocator = new MemoryReallocator(FileInput);
            reallocator.Run();
            return new PuzzleResult(reallocator.LoopSize, 2392);
        }
    }
}