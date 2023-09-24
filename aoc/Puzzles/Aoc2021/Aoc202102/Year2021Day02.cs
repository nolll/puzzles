using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Day02;

public class Year2021Day02 : AocPuzzle
{
    public override string Name => "Dive!";

    protected override PuzzleResult RunPart1()
    {
        var control = new SubmarineControl(InputFile, false);
        control.Move();
            
        return new PuzzleResult(control.Result, 1580000);
    }

    protected override PuzzleResult RunPart2()
    {
        var control = new SubmarineControl(InputFile, true);
        control.Move();

        return new PuzzleResult(control.Result, 1251263225);
    }
}