using Pzl.Tools.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201525;

public class Aoc201525 : AocPuzzle
{
    public override string Name => "Let It Snow";

    protected override PuzzleResult RunPart1()
    {
        var p = GetParams();
        var codeFinder = new WeatherMachineCodeFinder();
        var code = codeFinder.FindCodeAt(p.TargetX, p.TargetY);
        return new PuzzleResult(code, "d755f54368cc6c88fb38633954dddb9f");
    }

    protected override PuzzleResult RunPart2() => PuzzleResult.Empty;

    private Params GetParams()
    {
        var words = InputFile.Replace(".", "").Replace(",", "").Split(' ');

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