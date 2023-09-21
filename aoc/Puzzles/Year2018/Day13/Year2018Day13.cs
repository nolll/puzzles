﻿using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2018.Day13;

public class Year2018Day13 : AocPuzzle
{
    public override string Title => "Mine Cart Madness";

    public override PuzzleResult RunPart1()
    {
        var detector = new CollisionDetector(FileInput);
        detector.RunCarts();
        var firstCollisionCoords = detector.LocationOfFirstCollision;
        var firstCollition = $"{firstCollisionCoords.X},{firstCollisionCoords.Y}";
        return new PuzzleResult(firstCollition, "118,112");
    }

    public override PuzzleResult RunPart2()
    {
        var detector = new CollisionDetector(FileInput);
        detector.RunCarts();
        var lastCartCoords = detector.LocationOfLastCart;
        var lastCart = $"{lastCartCoords.X},{lastCartCoords.Y}";
        return new PuzzleResult(lastCart, "50,21");
    }
}