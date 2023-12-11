using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201823;

[Name("Experimental Emergency Teleportation")]
public class Aoc201823(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var formation = new NanobotFormation(input);
        var botCount = formation.GetBotsInRangeOfStrongestBot().Count;
        return new PuzzleResult(botCount, "1f18b10dba77e2b98fd66c448d160fe8");
    }

    protected override PuzzleResult RunPart2()
    {
        var formation = new NanobotFormation(input);
        var distanceToBestCoords = formation.FindManhattanDistanceToBestCoords();
        return new PuzzleResult(distanceToBestCoords, "63c2a383a835ff3ea383e54f860c8516");
    }
}