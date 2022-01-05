using App.Platform;

namespace App.Puzzles.Year2021.Day14;

public class Year2021Day14 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var polymerization = new Polymerization();
        var result = polymerization.Run(FileInput, 10);

        return new PuzzleResult(result, 3247);
    }

    public override PuzzleResult RunPart2()
    {
        var polymerization = new Polymerization();
        var result = polymerization.Run(FileInput, 40);

        return new PuzzleResult(result, 4110568157153);
    }
}