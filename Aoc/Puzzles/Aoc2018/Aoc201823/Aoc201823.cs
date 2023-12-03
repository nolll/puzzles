﻿using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2018.Aoc201823;

public class Aoc201823 : AocPuzzle
{
    public override string Name => "Experimental Emergency Teleportation";

    protected override PuzzleResult RunPart1()
    {
        var formation = new NanobotFormation(InputFile);
        var botCount = formation.GetBotsInRangeOfStrongestBot().Count;
        return new PuzzleResult(botCount, "1f18b10dba77e2b98fd66c448d160fe8");
    }

    protected override PuzzleResult RunPart2()
    {
        var formation = new NanobotFormation(InputFile);
        var distanceToBestCoords = formation.FindManhattanDistanceToBestCoords();
        return new PuzzleResult(distanceToBestCoords, "63c2a383a835ff3ea383e54f860c8516");
    }
}