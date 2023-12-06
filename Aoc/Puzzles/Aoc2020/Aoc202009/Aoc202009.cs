using Pzl.Tools.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202009;

public class Aoc202009 : AocPuzzle
{
    public override string Name => "Encoding Error";

    protected override PuzzleResult RunPart1()
    {
        var port = new XmasPort(InputFile, 25);
        var invalidNumber = port.FindFirstInvalidNumber();
        return new PuzzleResult(invalidNumber, "6c1a0cf69a058bbc7f0efbe438d2f8e7");
    }

    protected override PuzzleResult RunPart2()
    {
        var port = new XmasPort(InputFile, 25);
        var weakness = port.FindWeakness();
        return new PuzzleResult(weakness, "b6c20cca8f108e6c19637716982ff96f");
    }
}