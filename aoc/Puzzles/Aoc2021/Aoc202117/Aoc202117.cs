using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Aoc202117;

public class Aoc202117 : AocPuzzle
{
    private TrickshotResult? _result;

    public override string Name => "Trick Shot";

    protected override PuzzleResult RunPart1()
    {
        var result = Shoot();

        return new PuzzleResult(result.MaxHeight, 11175);
    }

    protected override PuzzleResult RunPart2()
    {
        var result = Shoot();

        return new PuzzleResult(result.HitCount, 3540);
    }

    private TrickshotResult Shoot()
    {
        if (_result == null)
        {
            var trickshot = new TrickShot();
            _result = trickshot.Shoot(new TrickshotTarget(81, 129, -150, -108));
        }

        return _result;
    }
}