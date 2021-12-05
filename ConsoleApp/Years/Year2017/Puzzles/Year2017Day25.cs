using System;
using Core.TuringDiagnostics;

namespace ConsoleApp.Years.Year2017.Puzzles
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