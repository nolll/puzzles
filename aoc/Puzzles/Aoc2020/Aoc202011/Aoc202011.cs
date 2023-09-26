using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2020.Aoc202011;

public class Aoc202011 : AocPuzzle
{
    public override string Name => "Seating System";

    protected override PuzzleResult RunPart1()
    {
        var simulator = new SeatingSimulatorAdjacentSeats(InputFile);
        simulator.Run();
        return new PuzzleResult(simulator.OccupiedSeatCount, 2359);
    }

    protected override PuzzleResult RunPart2()
    {
        var simulator = new SeatingSimulatorVisibleSeats(InputFile);
        simulator.Run();
        return new PuzzleResult(simulator.OccupiedSeatCount, 2131);
    }
}