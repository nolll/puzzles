using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day02;

public class Year2021Day02 : AocPuzzle
{
    public override string Name => "Dive!";

    public override PuzzleResult RunPart1()
    {
        var control = new SubmarineControl(FileInput, false);
        control.Move();
            
        return new PuzzleResult(control.Result, 1580000);
    }

    public override PuzzleResult RunPart2()
    {
        var control = new SubmarineControl(FileInput, true);
        control.Move();

        return new PuzzleResult(control.Result, 1251263225);
    }
}