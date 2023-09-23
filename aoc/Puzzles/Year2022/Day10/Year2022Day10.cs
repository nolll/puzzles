using Common.Puzzles;

namespace Aoc.Puzzles.Year2022.Day10;

public class Year2022Day10 : AocPuzzle
{
    public override string Name => "Cathode-Ray Tube";

    protected override PuzzleResult RunPart1()
    {
        var tube = new CathodeRayTube();
        var (result, _, _) = tube.Run(FileInput);

        return new PuzzleResult(result, 14360);
    }

    protected override PuzzleResult RunPart2()
    {
        var tube = new CathodeRayTube();
        var (_, result, _) = tube.Run(FileInput);

        return new PuzzleResult(result, "BGKAEREZ");
    }
}