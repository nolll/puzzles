﻿using Aoc.Platform;
using Common.Puzzles;

namespace Aoc.Puzzles.Year2020.Day12;

public class Year2020Day12 : AocPuzzle
{
    public override string Name => "Rain Risk";

    protected override PuzzleResult RunPart1()
    {
        var system = new SimpleFerryNavigationSystem(FileInput);
        system.Run();
        return new PuzzleResult(system.DistanceTravelled, 1424);
    }

    protected override PuzzleResult RunPart2()
    {
        var system = new WaypointFerryNavigationSystem(FileInput);
        system.Run();
        return new PuzzleResult(system.DistanceTravelled, 63447);
    }
}