using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2020.Aoc202012;

public class Aoc202012 : AocPuzzle
{
    public override string Name => "Rain Risk";

    protected override PuzzleResult RunPart1()
    {
        var system = new SimpleFerryNavigationSystem(InputFile);
        system.Run();
        return new PuzzleResult(system.DistanceTravelled, "c78da9d22889e3d4313249117e3752f4");
    }

    protected override PuzzleResult RunPart2()
    {
        var system = new WaypointFerryNavigationSystem(InputFile);
        system.Run();
        return new PuzzleResult(system.DistanceTravelled, "c0c5befc741f65a1030078ab200ffe10");
    }
}