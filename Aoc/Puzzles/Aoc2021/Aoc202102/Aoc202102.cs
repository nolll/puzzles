using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202102;

[Name("Dive!")]
public class Aoc202102(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var control = new SubmarineControl(input, false);
        control.Move();
            
        return new PuzzleResult(control.Result, "9d9dec9baf0fe61bbb7a9e95cc1ae2de");
    }

    protected override PuzzleResult RunPart2()
    {
        var control = new SubmarineControl(input, true);
        control.Move();

        return new PuzzleResult(control.Result, "6b29326368c507ef0dbbe41523850cd2");
    }
}