using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202119;

[Name("Beacon Scanner")]
public class Aoc202119 : AocPuzzle
{
    private BeaconSystemResult? _result;

    [Puzzle("a6668fd005e7ebda4e124253eea1e56e")]
    public PuzzleResult Part1(string input)
    {
        var result = GetResult(input);

        return new PuzzleResult(result.BeaconCount);
    }

    [Puzzle("ce2bc05651a369b5171388ec7e4f2438")]
    public PuzzleResult Part2(string input)
    {
        var result = GetResult(input);

        return new PuzzleResult(result.MaxDistance);
    }

    private BeaconSystemResult GetResult(string input)
    {
        if (_result != null)
            return _result;
        
        var system = new BeaconSystem();
        _result = system.GetResult(input);

        return _result;
    }
}