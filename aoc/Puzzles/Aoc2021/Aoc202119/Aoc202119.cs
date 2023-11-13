using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2021.Aoc202119;

public class Aoc202119 : AocPuzzle
{
    private BeaconSystemResult? _result;

    public override string Name => "Beacon Scanner";

    protected override PuzzleResult RunPart1()
    {
        var result = GetResult();

        return new PuzzleResult(result.BeaconCount, "a6668fd005e7ebda4e124253eea1e56e");
    }

    protected override PuzzleResult RunPart2()
    {
        var result = GetResult();

        return new PuzzleResult(result.MaxDistance, "ce2bc05651a369b5171388ec7e4f2438");
    }

    private BeaconSystemResult GetResult()
    {
        if(_result == null)
        {
            var system = new BeaconSystem();
            _result = system.GetResult(InputFile);
        }

        return _result;
    }
}