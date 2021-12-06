using Core.Platform;

namespace Core.Puzzles.Year2017.Day25
{
    public class Year2017Day25 : Year2017Day
    {
        public override int Day => 25;

        public override PuzzleResult RunPart1()
        {
            var turingMachine = new TuringMachine(FileInput);
            var checksum = turingMachine.Run();
            return new PuzzleResult(checksum, 4387);
        }

        public override PuzzleResult RunPart2()
        {
            return new EmptyPuzzleResult();
        }
    }
}