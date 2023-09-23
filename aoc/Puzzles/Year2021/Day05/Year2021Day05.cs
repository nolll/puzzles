using Aoc.Platform;
using Common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day05;

public class Year2021Day05 : AocPuzzle
{
    public override string Name => "Hydrothermal Venture";

    protected override PuzzleResult RunPart1()
    {
        var ventsMap = new VentsMap();
        var result = ventsMap.Run(FileInput, true);

        return new PuzzleResult(result, 4728);
    }

    protected override PuzzleResult RunPart2()
    {
        var ventsMap = new VentsMap();
        var result = ventsMap.Run(FileInput, false);

        return new PuzzleResult(result, 17717);
    }
}