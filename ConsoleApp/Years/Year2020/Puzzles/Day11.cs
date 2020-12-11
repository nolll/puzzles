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
            var simulator = new SeatingSimulatorAdjacentSeats(FileInput);
            simulator.Run();
            return new PuzzleResult($"Occupied seats with algorithm 1: {simulator.OccupiedSeatCount}");
        }

        public override PuzzleResult RunPart2()
        {
            var simulator = new SeatingSimulatorVisibleSeats(FileInput);
            simulator.Run();
            return new PuzzleResult($"Occupied seats with algorithm 2: {simulator.OccupiedSeatCount}");
        }
    }
}