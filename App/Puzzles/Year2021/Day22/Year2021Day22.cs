using App.Platform;

namespace App.Puzzles.Year2021.Day22;

public class Year2021Day22 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var reactor = new SubmarineReactor();
        var result = reactor.Reboot(FileInput);

        return new PuzzleResult(result, 588200);
    }

    public override PuzzleResult RunPart2()
    {
        return new PuzzleResult(0);
    }
}