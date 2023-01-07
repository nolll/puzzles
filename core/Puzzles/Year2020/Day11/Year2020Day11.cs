using Core.Platform;

namespace Core.Puzzles.Year2020.Day11;

public class Year2020Day11 : Puzzle
{
    public override string Title => "Seating System";

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