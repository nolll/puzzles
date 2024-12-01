using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202011;

[Name("Seating System")]
public class Aoc202011 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var simulator = new SeatingSimulatorAdjacentSeats(input);
        simulator.Run();
        return new PuzzleResult(simulator.OccupiedSeatCount, "808ef3d15c0093a702b0f3d80b8108fe");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var simulator = new SeatingSimulatorVisibleSeats(input);
        simulator.Run();
        return new PuzzleResult(simulator.OccupiedSeatCount, "7f305c2d3f92fba8601b1e43706ebc6c");
    }
}