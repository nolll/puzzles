using System;
using Core.TuringLock;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day23 : Day2015
    {
        public Day23() : base(23)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var computer1 = new ChristmasComputer();
            computer1.Run(FileInput);
            return new PuzzleResult(computer1.RegisterB, 307);
        }

        public override PuzzleResult RunPart2()
        {
            var computer = new ChristmasComputer();
            computer.Run(FileInput, 1);
            return new PuzzleResult(computer.RegisterB, 160);
        }
    }
}