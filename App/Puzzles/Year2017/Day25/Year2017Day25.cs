using App.Platform;

namespace App.Puzzles.Year2017.Day25
{
    public class Year2017Day25 : PuzzleDay
    {
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