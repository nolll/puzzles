using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2022.Aoc202210;

public class Aoc202210 : AocPuzzle
{
    public override string Name => "Cathode-Ray Tube";

    protected override PuzzleResult RunPart1()
    {
        var tube = new CathodeRayTube();
        var (result, _, _) = tube.Run(InputFile);

        return new PuzzleResult(result, 14360);
    }

    protected override PuzzleResult RunPart2()
    {
        var tube = new CathodeRayTube();
        var (_, result, _) = tube.Run(InputFile);

        return new PuzzleResult(result, "BGKAEREZ");
    }
}