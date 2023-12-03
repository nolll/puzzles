using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2021.Aoc202105;

public class Aoc202105 : AocPuzzle
{
    public override string Name => "Hydrothermal Venture";

    protected override PuzzleResult RunPart1()
    {
        var ventsMap = new VentsMap();
        var result = ventsMap.Run(InputFile, true);

        return new PuzzleResult(result, "72e2846f2036e57e75a10d9d0b5a99ad");
    }

    protected override PuzzleResult RunPart2()
    {
        var ventsMap = new VentsMap();
        var result = ventsMap.Run(InputFile, false);

        return new PuzzleResult(result, "e07b568228a7ed5a9bc9276d343e6973");
    }
}