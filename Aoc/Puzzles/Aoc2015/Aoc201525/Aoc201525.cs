using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201525;

[Name("Let It Snow")]
public class Aoc201525 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var p = GetParams(input);
        var codeFinder = new WeatherMachineCodeFinder();
        var code = codeFinder.FindCodeAt(p.TargetX, p.TargetY);
        return new PuzzleResult(code, "d755f54368cc6c88fb38633954dddb9f");
    }

    private static Params GetParams(string input)
    {
        var words = input.Replace(".", "").Replace(",", "").Split(' ');

        return new Params
        {
            TargetX = int.Parse(words[18]),
            TargetY = int.Parse(words[16])
        };
    }

    private class Params
    {
        public int TargetX { get; set; }
        public int TargetY { get; set; }
    }
}