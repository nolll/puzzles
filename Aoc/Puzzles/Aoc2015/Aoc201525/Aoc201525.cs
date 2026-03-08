using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201525;

[Name("Let It Snow")]
public class Aoc201525 : AocPuzzle
{
    [Puzzle("d755f54368cc6c88fb38633954dddb9f")]
    public long Part1(string input)
    {
        var p = GetParams(input);
        return new WeatherMachineCodeFinder().FindCodeAt(p.TargetX, p.TargetY);
    }

    private static Params GetParams(string input)
    {
        var words = input.Replace(".", "").Replace(",", "").Split(' ');
        return new Params(int.Parse(words[18]), int.Parse(words[16]));
    }

    private record Params(int TargetX, int TargetY);
}