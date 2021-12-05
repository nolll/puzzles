using Core.DigitalPlumber;

namespace ConsoleApp.Puzzles.Year2017.Day12
{
    public class Year2017Day12 : Year2017Day
    {
        public override int Day => 12;

        public override PuzzleResult RunPart1()
        {
            var pipes = new Pipes(FileInput);
            return new PuzzleResult(pipes.PipesInGroupZero, 145);
        }

        public override PuzzleResult RunPart2()
        {
            var pipes = new Pipes(FileInput);
            return new PuzzleResult(pipes.GroupCount, 207);
        }
    }
}