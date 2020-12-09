using System;
using Core.TuringDiagnostics;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day25 : Day2017
    {
        public Day25() : base(25)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var turingMachine = new TuringMachine(FileInput);
            var checksum = turingMachine.Run();
            Console.WriteLine($"Turing machine checksum: {checksum}.");
        }
    }
}