using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day25;

public class Year2015Day25 : AocPuzzle
{
    public override string Name => "Let It Snow";

    protected override PuzzleResult RunPart1()
    {
        var p = GetParams();
        var codeFinder = new WeatherMachineCodeFinder();
        var code = codeFinder.FindCodeAt(p.TargetX, p.TargetY);
        return new PuzzleResult(code, 2_650_453);
    }

    protected override PuzzleResult RunPart2() => PuzzleResult.Empty;

    private Params GetParams()
    {
        var words = FileInput.Replace(".", "").Replace(",", "").Split(' ');

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