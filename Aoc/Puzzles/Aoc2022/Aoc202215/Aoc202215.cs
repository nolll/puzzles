using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202215;

[IsSlow]
[Name("Beacon Exclusion Zone")]
public class Aoc202215 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var zone = new BeaconZone();
        var result = zone.Part1(input, 2_000_000, false);

        return new PuzzleResult(result, "f81ea7aff75f183d6afc5816570af244");
    }

    public PuzzleResult RunPart2(string input)
    {
        var zone = new BeaconZone();
        var result = zone.Part2(input, 4_000_000);
        
        return new PuzzleResult(result, "b4c412a68efd49876d6777a8ea4baea1");
    }
}