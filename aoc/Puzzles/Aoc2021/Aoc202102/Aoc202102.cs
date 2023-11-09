using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Aoc202102;

public class Aoc202102 : AocPuzzle
{
    public override string Name => "Dive!";

    protected override PuzzleResult RunPart1()
    {
        var control = new SubmarineControl(InputFile, false);
        control.Move();
            
        return new PuzzleResult(control.Result, "9d9dec9baf0fe61bbb7a9e95cc1ae2de");
    }

    protected override PuzzleResult RunPart2()
    {
        var control = new SubmarineControl(InputFile, true);
        control.Move();

        return new PuzzleResult(control.Result, "6b29326368c507ef0dbbe41523850cd2");
    }
}