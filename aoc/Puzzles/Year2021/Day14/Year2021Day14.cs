using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day14;

public class Year2021Day14 : AocPuzzle
{
    public override string Name => "Extended Polymerization";

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