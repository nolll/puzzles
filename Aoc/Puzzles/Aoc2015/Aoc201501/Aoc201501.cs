using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201501;

[Name("Not Quite Lisp")]
public class Aoc201501(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var navigator = new FloorNavigator(input);

        return new PuzzleResult(navigator.DestinationFloor, "d8ee6b0475f3971b598eab03bf31bed4");
    }

    protected override PuzzleResult RunPart2()
    {
        var navigator = new FloorNavigator(input);
            
        return new PuzzleResult(navigator.FirstBasementInstruction, "eda1f9a68a0c771a5fdedc4228d1080c");
    }
}