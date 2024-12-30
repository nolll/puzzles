using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202119;

[Name("Beacon Scanner")]
public class Aoc202119 : AocPuzzle
{
    private BeaconSystemResult? _result;

    public PuzzleResult RunPart1(string input)
    {
        var result = GetResult(input);

        return new PuzzleResult(result.BeaconCount, "a6668fd005e7ebda4e124253eea1e56e");
    }

    public PuzzleResult RunPart2(string input)
    {
        var result = GetResult(input);

        return new PuzzleResult(result.MaxDistance, "ce2bc05651a369b5171388ec7e4f2438");
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