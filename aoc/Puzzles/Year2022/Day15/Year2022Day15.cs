using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2022.Day15;

public class Year2022Day15 : AocPuzzle
{
    public override string Title => "Beacon Exclusion Zone";

    public override PuzzleResult RunPart1()
    {
        var zone = new BeaconZone();
        var result = zone.Part1(FileInput, 2_000_000, false);

        return new PuzzleResult(result, 5_108_096);
    }

    public override PuzzleResult RunPart2()
    {
        var zone = new BeaconZone();
        var result = zone.Part2(FileInput, 4_000_000);
        
        return new PuzzleResult(result, 10553942650264);
    }
}