using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2022.Aoc202215;

public class Year2022Day15 : AocPuzzle
{
    public override string Name => "Beacon Exclusion Zone";

    protected override PuzzleResult RunPart1()
    {
        var zone = new BeaconZone();
        var result = zone.Part1(InputFile, 2_000_000, false);

        return new PuzzleResult(result, 5_108_096);
    }

    protected override PuzzleResult RunPart2()
    {
        var zone = new BeaconZone();
        var result = zone.Part2(InputFile, 4_000_000);
        
        return new PuzzleResult(result, 10553942650264);
    }
}