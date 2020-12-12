using System;
using Core.TuringDiagnostics;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day25 : Day2017
    {
        public Day25() : base(25)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var turingMachine = new TuringMachine(FileInput);
            var checksum = turingMachine.Run();
            return new PuzzleResult($"Turing machine checksum: {checksum}.");
        }

        public override PuzzleResult RunPart2()
        {
            return new EmptyPuzzleResult();
        }
    }
}