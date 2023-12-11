using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202011;

[Name("Seating System")]
public class Aoc202011(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var simulator = new SeatingSimulatorAdjacentSeats(Input);
        simulator.Run();
        return new PuzzleResult(simulator.OccupiedSeatCount, "808ef3d15c0093a702b0f3d80b8108fe");
    }

    protected override PuzzleResult RunPart2()
    {
        var simulator = new SeatingSimulatorVisibleSeats(Input);
        simulator.Run();
        return new PuzzleResult(simulator.OccupiedSeatCount, "7f305c2d3f92fba8601b1e43706ebc6c");
    }
}