using App.Platform;

namespace App.Puzzles.Year2020.Day06;

public class Year2020Day06 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var reader = new DeclarationFormReader(FileInput);
        return new PuzzleResult(reader.SumOfAtLeastOneYes, 6778);
    }

    public override PuzzleResult RunPart2()
    {
        var reader = new DeclarationFormReader(FileInput);
        return new PuzzleResult(reader.SumOfAllYes, 3406);
    }
}