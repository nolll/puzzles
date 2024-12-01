using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201625;

[Name("Clock Signal")]
public class Aoc201625 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var generator = new ClockSignalGenerator();
        return new PuzzleResult(generator.LowestA, "5523923bd52d76e1c1d68b1cfdff95b5");
    }

    protected override PuzzleResult RunPart2(string input) => PuzzleResult.Empty;
}