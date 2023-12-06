using Pzl.Tools.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202106;

public class Aoc202106 : AocPuzzle
{
    public override string Name => "Lanternfish";

    protected override PuzzleResult RunPart1()
    {
        var fishCounter = new FishCounter(InputFile);
        var result = fishCounter.FishCountAfter(80);
        return new PuzzleResult(result, "f41058112a3490c1842a14e75ebfef8c");
    }

    protected override PuzzleResult RunPart2()
    {
        var fishCounter = new FishCounter(InputFile);
        var result = fishCounter.FishCountAfter(256);
        return new PuzzleResult(result, "d49cf732d5285745340ba70c6a3ddc15");
    }
}