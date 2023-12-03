using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2020.Aoc202011;

public class Aoc202011 : AocPuzzle
{
    public override string Name => "Seating System";

    protected override PuzzleResult RunPart1()
    {
        var simulator = new SeatingSimulatorAdjacentSeats(InputFile);
        simulator.Run();
        return new PuzzleResult(simulator.OccupiedSeatCount, "808ef3d15c0093a702b0f3d80b8108fe");
    }

    protected override PuzzleResult RunPart2()
    {
        var simulator = new SeatingSimulatorVisibleSeats(InputFile);
        simulator.Run();
        return new PuzzleResult(simulator.OccupiedSeatCount, "7f305c2d3f92fba8601b1e43706ebc6c");
    }
}