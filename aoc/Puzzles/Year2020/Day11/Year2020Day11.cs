using Common.Puzzles;

namespace Aoc.Puzzles.Year2020.Day11;

public class Year2020Day11 : AocPuzzle
{
    public override string Name => "Seating System";

    protected override PuzzleResult RunPart1()
    {
        var simulator = new SeatingSimulatorAdjacentSeats(FileInput);
        simulator.Run();
        return new PuzzleResult(simulator.OccupiedSeatCount, 2359);
    }

    protected override PuzzleResult RunPart2()
    {
        var simulator = new SeatingSimulatorVisibleSeats(FileInput);
        simulator.Run();
        return new PuzzleResult(simulator.OccupiedSeatCount, 2131);
    }
}