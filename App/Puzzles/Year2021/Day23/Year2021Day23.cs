using App.Platform;

namespace App.Puzzles.Year2021.Day23;

public class Year2021Day23 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var amphipods = new AmphipodsPart1();
        var result = amphipods.GetResult();

        return new PuzzleResult(result, 11120);
    }

    public override PuzzleResult RunPart2()
    {
        return new PuzzleResult(0);
    }
}