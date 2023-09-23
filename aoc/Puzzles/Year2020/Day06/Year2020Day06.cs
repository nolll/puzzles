using Common.Puzzles;

namespace Aoc.Puzzles.Year2020.Day06;

public class Year2020Day06 : AocPuzzle
{
    public override string Name => "Custom Customs";

    protected override PuzzleResult RunPart1()
    {
        var reader = new DeclarationFormReader(FileInput);
        return new PuzzleResult(reader.SumOfAtLeastOneYes, 6778);
    }

    protected override PuzzleResult RunPart2()
    {
        var reader = new DeclarationFormReader(FileInput);
        return new PuzzleResult(reader.SumOfAllYes, 3406);
    }
}