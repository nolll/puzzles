using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2022.Aoc202214;

public class Year2022Day14 : AocPuzzle
{
    public override string Name => "Regolith Reservoir";

    protected override PuzzleResult RunPart1()
    {
        var fallingSand = new FallingSand();
        var result = fallingSand.Part1(InputFile);

        return new PuzzleResult(result, 745);
    }

    protected override PuzzleResult RunPart2()
    {
        var fallingSand = new FallingSand();
        var result = fallingSand.Part2(InputFile);

        return new PuzzleResult(result, 27_551);
    }
}