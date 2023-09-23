using Aoc.Platform;
using Common.Puzzles;

namespace Aoc.Puzzles.Year2018.Day23;

public class Year2018Day23 : AocPuzzle
{
    public override string Name => "Experimental Emergency Teleportation";

    protected override PuzzleResult RunPart1()
    {
        var formation = new NanobotFormation(FileInput);
        var botCount = formation.GetBotsInRangeOfStrongestBot().Count;
        return new PuzzleResult(botCount, 481);
    }

    protected override PuzzleResult RunPart2()
    {
        var formation = new NanobotFormation(FileInput);
        var distanceToBestCoords = formation.FindManhattanDistanceToBestCoords();
        return new PuzzleResult(distanceToBestCoords, 47_141_479);
    }
}