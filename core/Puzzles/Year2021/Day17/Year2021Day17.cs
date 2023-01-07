using Core.Platform;

namespace Core.Puzzles.Year2021.Day17;

public class Year2021Day17 : Puzzle
{
    private TrickshotResult _result;

    public override string Title => "Trick Shot";

    public override PuzzleResult RunPart1()
    {
        var result = Shoot();

        return new PuzzleResult(result.MaxHeight, 11175);
    }

    public override PuzzleResult RunPart2()
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