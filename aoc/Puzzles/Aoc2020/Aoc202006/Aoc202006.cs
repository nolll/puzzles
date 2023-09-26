using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2020.Aoc202006;

public class Aoc202006 : AocPuzzle
{
    public override string Name => "Custom Customs";

    protected override PuzzleResult RunPart1()
    {
        var reader = new DeclarationFormReader(InputFile);
        return new PuzzleResult(reader.SumOfAtLeastOneYes, 6778);
    }

    protected override PuzzleResult RunPart2()
    {
        var reader = new DeclarationFormReader(InputFile);
        return new PuzzleResult(reader.SumOfAllYes, 3406);
    }
}