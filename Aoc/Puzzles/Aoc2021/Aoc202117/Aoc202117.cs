using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202117;

[Name("Trick Shot")]
public class Aoc202117 : AocPuzzle
{
    private TrickshotResult? _result;

    public PuzzleResult RunPart1(string input)
    {
        var result = Shoot();

        return new PuzzleResult(result.MaxHeight, "375d1d4838312873a7516c061904317c");
    }

    public PuzzleResult RunPart2(string input)
    {
        var result = Shoot();

        return new PuzzleResult(result.HitCount, "25eea3cce163ac31e5c10a5df5210cee");
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