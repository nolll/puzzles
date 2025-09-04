using Pzl.Common;

namespace Pzl.Everybody.Puzzles.Ecs02.Ecs0202;

[Name("The Pocket-Money Popper")]
public class Ecs0202 : EverybodyStoryPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var i = 0;
        var arrowIndex = 0;
        char[] arrows = ['R', 'G', 'B'];
        while (i < input.Length)
        {
            while (i < input.Length && input[i] == arrows[arrowIndex % arrows.Length])
                i++;

            arrowIndex++;
            i++;
        }
        
        return new PuzzleResult(arrowIndex, "4648ca473c884f7676991b343c2db8e0");
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}