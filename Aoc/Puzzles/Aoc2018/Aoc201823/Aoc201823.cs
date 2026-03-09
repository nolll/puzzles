using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201823;

[Name("Experimental Emergency Teleportation")]
public class Aoc201823 : AocPuzzle
{
    [Puzzle("1f18b10dba77e2b98fd66c448d160fe8")]
    public int Part1(string input) => new NanobotFormation(input).GetBotsInRangeOfStrongestBot().Count;

    [Puzzle("63c2a383a835ff3ea383e54f860c8516")]
    public int Part2(string input) => new NanobotFormation(input).FindManhattanDistanceToBestCoords();
}