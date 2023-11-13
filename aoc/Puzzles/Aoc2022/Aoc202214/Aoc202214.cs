using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2022.Aoc202214;

public class Aoc202214 : AocPuzzle
{
    public override string Name => "Regolith Reservoir";

    protected override PuzzleResult RunPart1()
    {
        var fallingSand = new FallingSand();
        var result = fallingSand.Part1(InputFile);

        return new PuzzleResult(result, "8772ddaaa456233ff5c9888ae72de902");
    }

    protected override PuzzleResult RunPart2()
    {
        var fallingSand = new FallingSand();
        var result = fallingSand.Part2(InputFile);

        return new PuzzleResult(result, "a4ec5b539a3242d500f793c91d89e0d8");
    }
}