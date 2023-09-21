using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day19;

public class Year2021Day19 : AocPuzzle
{
    private BeaconSystemResult _result;

    public override string Title => "Beacon Scanner";

    public override PuzzleResult RunPart1()
    {
        var result = GetResult();

        return new PuzzleResult(result.BeaconCount, 353);
    }

    public override PuzzleResult RunPart2()
    {
        var result = GetResult();

        return new PuzzleResult(result.MaxDistance, 10832);
    }

    private BeaconSystemResult GetResult()
    {
        if(_result == null)
        {
            var system = new BeaconSystem();
            _result = system.GetResult(FileInput);
        }

        return _result;
    }
}