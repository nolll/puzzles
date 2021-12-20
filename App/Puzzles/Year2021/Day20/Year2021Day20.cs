using App.Common.Strings;
using App.Platform;

namespace App.Puzzles.Year2021.Day20;

public class Year2021Day20 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var trenchMap = new TrenchMap();
        var result = trenchMap.GetLitPixelCount(FileInput);

        return new PuzzleResult(result);
    }

    public override PuzzleResult RunPart2()
    {
        return new PuzzleResult(0);
    }
}