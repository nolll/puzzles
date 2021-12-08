using App.Platform;

namespace App.Puzzles.Year2017.Day23
{
    public class Year2017Day23 : PuzzleDay
    {
        public override PuzzleResult RunPart1()
        {
            var processor1 = new CoProcessor(FileInput);
            processor1.Run();
            return new PuzzleResult(processor1.MulCount, 4225);
        }

        public override PuzzleResult RunPart2()
        {
            var processor2 = new OptimizedCoProcessor();
            processor2.Run();
            return new PuzzleResult(processor2.H, 905);
        }
    }
}