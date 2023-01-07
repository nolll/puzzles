using Core.Platform;

namespace Core.Puzzles.Year2022.Day14;

public class Year2022Day14 : Puzzle
{
    public override string Title => "Regolith Reservoir";

    public override PuzzleResult RunPart1()
    {
        var fallingSand = new FallingSand();
        var result = fallingSand.Part1(FileInput);

        return new PuzzleResult(result, 745);
    }

    public override PuzzleResult RunPart2()
    {
        var fallingSand = new FallingSand();
        var result = fallingSand.Part2(FileInput);

        return new PuzzleResult(result, 27_551);
    }
}