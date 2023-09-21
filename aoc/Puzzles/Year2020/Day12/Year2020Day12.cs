using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2020.Day12;

public class Year2020Day12 : AocPuzzle
{
    public override string Title => "Rain Risk";

    public override PuzzleResult RunPart1()
    {
        var system = new SimpleFerryNavigationSystem(FileInput);
        system.Run();
        return new PuzzleResult(system.DistanceTravelled, 1424);
    }

    public override PuzzleResult RunPart2()
    {
        var system = new WaypointFerryNavigationSystem(FileInput);
        system.Run();
        return new PuzzleResult(system.DistanceTravelled, 63447);
    }
}