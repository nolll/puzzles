using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2018.Aoc201823;

public class Aoc201823 : AocPuzzle
{
    public override string Name => "Experimental Emergency Teleportation";

    protected override PuzzleResult RunPart1()
    {
        var formation = new NanobotFormation(InputFile);
        var botCount = formation.GetBotsInRangeOfStrongestBot().Count;
        return new PuzzleResult(botCount, 481);
    }

    protected override PuzzleResult RunPart2()
    {
        var formation = new NanobotFormation(InputFile);
        var distanceToBestCoords = formation.FindManhattanDistanceToBestCoords();
        return new PuzzleResult(distanceToBestCoords, 47_141_479);
    }
}