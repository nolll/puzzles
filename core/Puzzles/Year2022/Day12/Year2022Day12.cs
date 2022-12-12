using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems.CoordinateSystem2D;
using Core.Platform;

namespace Core.Puzzles.Year2022.Day12;

public class Year2022Day12 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var hillClimbing = new HillClimbing();
        var result = hillClimbing.Part1(FileInput);

        return new PuzzleResult(result);
    }

    public override PuzzleResult RunPart2()
    {
        var hillClimbing = new HillClimbing();
        var result = hillClimbing.Part2(FileInput);

        return new PuzzleResult(result);
    }
}