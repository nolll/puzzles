﻿using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2018.Aoc201820;

public class Aoc201820 : AocPuzzle
{
    public override string Name => "A Regular Map";

    protected override PuzzleResult RunPart1()
    {
        var navigator = new RegularMapNavigator(InputFile);
        return new PuzzleResult(navigator.MostDoors, 4050);
    }

    protected override PuzzleResult RunPart2()
    {
        var navigator = new RegularMapNavigator(InputFile);
        return new PuzzleResult(navigator.RoomsMoreThat1000DoorsAway, 8564);
    }
}