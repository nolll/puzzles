using System;
using Core.WaitingAreaSeating;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day11 : Day2020
    {
        public Day11() : base(11)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var simulator = new SeatingSimulator(FileInput);
            simulator.RunUntilStable();
            return new PuzzleResult($"Occupied seats: {simulator.OccupiedSeatCount}");
        }

        protected override void RunDay()
        {
            throw new NotImplementedException();
        }
    }
}