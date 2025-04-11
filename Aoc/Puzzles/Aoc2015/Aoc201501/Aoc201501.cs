using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201501;

[Name("Not Quite Lisp")]
public class Aoc201501 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var destination = input.ToCharArray().Sum(FloorDelta);
        return new PuzzleResult(destination, "d8ee6b0475f3971b598eab03bf31bed4");
    }

    public PuzzleResult Part2(string input)
    {
        var instructions = input.ToCharArray();
        var index = 1;
        var destination = 0;
        foreach (var c in instructions)
        {
            destination += FloorDelta(c);

            if (destination < 0)
                return new PuzzleResult(index, "eda1f9a68a0c771a5fdedc4228d1080c");

            index++;
        }

        throw new Exception("Never entered the basement");
    }
    
    private static int FloorDelta(char c) => c switch
    {
        '(' => 1,
        ')' => -1,
        _ => 0
    };
}