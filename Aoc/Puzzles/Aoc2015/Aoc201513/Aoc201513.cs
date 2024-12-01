using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201513;

[Name("Knights of the Dinner Table")]
public class Aoc201513 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var table = new DinnerTable(input);
        return new PuzzleResult(table.HappinessChange, "dc9344b26ae0a5267f6fed8baed68a66");
    }

    public PuzzleResult RunPart2(string input)
    {
        var table = new DinnerTable(input, true);
        return new PuzzleResult(table.HappinessChange, "a65dc47bae92b7cf052aa4311e6a429a");
    }
}