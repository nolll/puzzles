using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202117;

[Name("Trick Shot")]
public class Aoc202117 : AocPuzzle
{
    private TrickshotResult? _result;

    [Puzzle("375d1d4838312873a7516c061904317c")]
    public int Part1(string input) => Shoot().MaxHeight;

    [Puzzle("25eea3cce163ac31e5c10a5df5210cee")]
    public int Part2(string input) => Shoot().HitCount;

    private TrickshotResult Shoot() => _result ??= new TrickShot().Shoot(new TrickshotTarget(81, 129, -150, -108));
}