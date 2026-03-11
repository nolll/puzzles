using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202215;

[Name("Beacon Exclusion Zone")]
public class Aoc202215 : AocPuzzle
{
    [Puzzle("f81ea7aff75f183d6afc5816570af244")]
    public PuzzleResult Part1(string input)
    {
        var zone = new BeaconZone();
        var result = zone.Part1(input, 2_000_000);

        return new PuzzleResult(result);
    }
    
    [Puzzle("b4c412a68efd49876d6777a8ea4baea1")]
    public PuzzleResult Part2(string input)
    {
        var zone = new BeaconZone();
        var result = zone.Part2(input, 4_000_000);
        
        return new PuzzleResult(result);
    }
}