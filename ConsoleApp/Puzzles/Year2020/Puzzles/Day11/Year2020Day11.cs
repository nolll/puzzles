﻿namespace ConsoleApp.Puzzles.Year2020.Puzzles.Day11
{
    public class Year2020Day11 : Year2020Day
    {
        public override int Day => 11;

        public override PuzzleResult RunPart1()
        {
            var simulator = new SeatingSimulatorAdjacentSeats(FileInput);
            simulator.Run();
            return new PuzzleResult(simulator.OccupiedSeatCount, 2359);
        }

        public override PuzzleResult RunPart2()
        {
            var simulator = new SeatingSimulatorVisibleSeats(FileInput);
            simulator.Run();
            return new PuzzleResult(simulator.OccupiedSeatCount, 2131);
        }
    }
}